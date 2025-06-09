using Hangfire;
using UserSyncApp.Domain.Interfaces;

namespace UserSyncApp.Application.UseCases;

public class UserSyncJob
{
    private readonly IUserSyncService _syncService;

    public UserSyncJob(IUserSyncService syncService)
    {
        _syncService = syncService;
    }

    [AutomaticRetry(Attempts = 3)]
    public async Task RunAsync() => await _syncService.SyncUsersAsync();
}