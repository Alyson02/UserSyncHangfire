using Hangfire;
using UserSyncApp.Application.UseCases;

namespace UserSyncApp.Infrastructure.Jobs;

public static class JobScheduler
{
    public static void Register()
    {
        RecurringJob.AddOrUpdate<UserSyncJob>(
            "sync-mock-usuarios",
            job => job.RunAsync(),
            Cron.Minutely);
    }
}