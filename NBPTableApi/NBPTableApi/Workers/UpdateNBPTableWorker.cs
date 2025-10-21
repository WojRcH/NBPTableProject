using NBPTableApi.Services;

namespace NBPTableApi.Workers
{
    public class NBPWorker : BackgroundService
    {
        private readonly IServiceProvider serviceProvider;
        private readonly TimeSpan interval;

        public NBPWorker(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            this.serviceProvider = serviceProvider;
            int seconds = configuration.GetValue<int?>("NBPWorker:IntervalSeconds") ?? 60;
            interval = TimeSpan.FromSeconds(seconds);
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    using var scope = serviceProvider.CreateScope();
                    var nbpService = scope.ServiceProvider.GetRequiredService<INBPService>();

                    var records = await nbpService.UpdateNBPTable()
                                   ?? throw new Exception("Not found data from NBP");

                    Console.WriteLine($"[{DateTime.Now}] Updated {records.Count} rates from NBP.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error updating table NBP: {ex.Message}");
                }

                await Task.Delay(interval, cancellationToken);
            }
        }
    }

}
