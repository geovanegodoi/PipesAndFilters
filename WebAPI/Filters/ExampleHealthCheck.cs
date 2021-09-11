using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Filters
{
    public class ExampleHealthCheck : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            var applicationIsHealthy = (DateTime.Now.Second % 2) == 0;

            var healthCheckResult = applicationIsHealthy ?
                HealthCheckResult.Healthy("A healthy result.") :
                new HealthCheckResult(context.Registration.FailureStatus, "An unhealthy result.");

            return Task.FromResult(healthCheckResult);
        }
    }
}
