using QuiSNCF.Repository;

namespace QuiSNCF.Service;

public class MidnightPickerService(IServiceScopeFactory scopeFactory, ILogger<MidnightPickerService> logger) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var delay = TimeUntilNextMidnight();
            logger.LogInformation("Prochain tirage dans {Delay}", delay);

            await Task.Delay(delay, stoppingToken);

            await RunPickAsync();
        }   
    }
    
    private async Task RunPickAsync()
    {
        using var scope = scopeFactory.CreateScope();
        var service = scope.ServiceProvider.GetRequiredService<IStationRepository>();

        try
        {
            var item = await service.GetRandomStation();
            logger.LogInformation("Item du jour sélectionné : {Name}", item?.Name ?? "aucun");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Erreur lors du tirage quotidien");
        }
    }
    
    private static TimeSpan TimeUntilNextMidnight()
    {
        var now = DateTime.Now;
        var nextMidnight = now.Date.AddDays(1);
        return nextMidnight - now;
    }
}