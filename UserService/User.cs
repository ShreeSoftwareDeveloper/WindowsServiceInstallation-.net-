using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserService
{
    public class User : BackgroundService
    {
        private readonly ILogger<User> logger;
        public User(ILogger<User> _logger)
        {
            logger = _logger;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while(!stoppingToken.IsCancellationRequested)
            {
                logger.LogInformation("Execution Started");
                try
                {
                    // write logic
                   
                }
                catch(Exception ex)
                {
                    logger.LogError(ex, ex.Message); ;
                }
                await Task.Delay(1000*15, stoppingToken);
            }
        }
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation("Service Started");
            return base.StartAsync(cancellationToken);
        }
        public override Task StopAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation("Service Stopped");
            return base.StopAsync(cancellationToken);
        }
    }
}
