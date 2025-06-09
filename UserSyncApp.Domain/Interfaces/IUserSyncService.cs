namespace UserSyncApp.Domain.Interfaces;

public interface IUserSyncService
{
    Task SyncUsersAsync();
}