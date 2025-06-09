using UserSyncApp.Domain.Entities;
using UserSyncApp.Domain.VOs;

namespace UserSyncApp.Application.DTOs;

public class RandomUserResponse
{
    public List<RandomUser> Results { get; set; }  = [];
}

public class RandomUser
{
    public string Email { get; set; } = string.Empty;
    public Name Name { get; set; }
}