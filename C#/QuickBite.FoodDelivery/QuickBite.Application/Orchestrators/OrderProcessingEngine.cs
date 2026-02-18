using QuickBite.Application.Interfaces;
using QuickBite.Domain.Entities;
using QuickBite.Domain.Enums;
using QuickBite.Domain.Results;

namespace QuickBite.Application.Orchestrators;

public class OrderProcessingEngine
{
    private readonly IPaymentService _payment;
    private readonly IRestaurantService _restaurant;
    private readonly KitchenOrchestrator _kitchen;
    private readonly DriverMatcher _driverMatcher;

    public OrderProcessingEngine(
        IPaymentService payment,
        IRestaurantService restaurant,
        KitchenOrchestrator kitchen,
        DriverMatcher driverMatcher)
    {
        _payment = payment;
        _restaurant = restaurant;
        _kitchen = kitchen;
        _driverMatcher = driverMatcher;
    }

    public async Task<OrderProcessingResult> ProcessAsync(
        CustomerOrder order,
        CancellationToken ct)
    {
        try
        {
            order.Status = OrderStatus.PaymentProcessing;

            if (!await _payment.ProcessPaymentAsync(order.TotalAmount, ct))
                throw new Exception("Payment failed");

            order.Status = OrderStatus.PaymentSuccessful;

            if (!await _restaurant.AcceptOrderAsync(order, ct))
                throw new Exception("Restaurant rejected");

            order.Status = OrderStatus.RestaurantPreparing;
            await _kitchen.CookAsync(order, ct);

            order.AssignedDriver =
                await _driverMatcher.MatchAsync(order.OrderId, ct);

            order.Status = OrderStatus.Delivered;

            return new OrderProcessingResult
            {
                IsSuccess = true,
                OrderId = order.OrderId
            };
        }
        catch (Exception ex)
        {
            order.Status = OrderStatus.Cancelled;
            return new OrderProcessingResult
            {
                IsSuccess = false,
                OrderId = order.OrderId,
                ErrorMessage = ex.Message
            };
        }
    }
}
