namespace WebApi.Trabalhadores
{
    public class AquecimentoTrabalhador : BackgroundService
    {
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (true)
            {
               Thread.Sleep(1000);
            }
        }
    }
}
