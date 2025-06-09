using System.Net.Http.Json;
using UserSyncApp.Application.DTOs;
using UserSyncApp.Domain.Entities;
using UserSyncApp.Domain.Interfaces;

namespace UserSyncApp.Application.Services;

public class UserSyncService(IUserRepository repository, HttpClient httpClient) : IUserSyncService
{
    public async Task SyncUsersAsync()
    {
        var externalUsers = await httpClient.GetFromJsonAsync<RandomUserResponse>("https://randomuser.me/api/?results=2000");

        var users = externalUsers?.Results.Select(x => new User
        {
            Email = x.Email,
            Name = x.Name.ToString(),
            Status = "Active"
        });
        
        if (users is null) return;

        foreach (var user in users)
        {
            var existing = await repository.GetByEmailAsync(user.Email);
            if (existing == null)
                await repository.AddAsync(user);
            else
            {
                existing.Name = user.Name;
                existing.Status = user.Status;
                await repository.UpdateAsync(existing);
            }
        }
    }
}