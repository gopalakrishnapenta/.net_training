using QuickBite.Domain.Entities;

namespace QuickBite.Application.Orchestrators;

public class KitchenOrchestrator
{
    public async Task CookAsync(CustomerOrder order, CancellationToken ct)
    {
        var tasks = order.Items.Select(i =>
            Task.Delay(i.CookTime, ct));

        await Task.WhenAll(tasks);
    }
}
