using Microsoft.Extensions.Logging;
using Quartz;
using System.Threading.Tasks;

namespace WebFactoryPattern.Infrastructure.Utilities
{
    [DisallowConcurrentExecution] //This attribute prevents Quartz.NET from trying to run the same job concurrently. 
    public class HelloMehdiJob : IJob
    {
        private readonly ILogger<HelloMehdiJob> _logger;

        public HelloMehdiJob(ILogger<HelloMehdiJob> logger)
        {
            _logger = logger;
        }

        public Task Execute(IJobExecutionContext context)
        {
            _logger.LogInformation("Hello world!");
            return Task.CompletedTask;
        }

    }
}
