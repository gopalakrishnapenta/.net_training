using QuickBite.Application.Results;
using QuickBite.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace QuickBite.Application.Interfaces
{
    public interface IRestaurantService
    {
        Task<RestaurantAcceptance> AcceptOrderAsync(
            CustomerOrder order,
            CancellationToken ct);

        Task<PreparationProgress> GetPreparationProgressAsync(
            string orderId,
            CancellationToken ct);

        Task<bool> CancelOrderAsync(
            string orderId,
            string reason,
            CancellationToken ct);

        IAsyncEnumerable<KitchenUpdate> StreamKitchenUpdates(
            string orderId,
            CancellationToken ct);
    }
}
