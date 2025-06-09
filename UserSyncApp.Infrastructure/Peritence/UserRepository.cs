using Microsoft.EntityFrameworkCore;
using UserSyncApp.Domain.Entities;
using UserSyncApp.Domain.Interfaces;

namespace UserSyncApp.Infrastructure.Peritence;

public class UserRepository(AppDbContext context) : IUserRepository
{
    public async Task<IEnumerable<User>> GetAllAsync() => await context.Users.ToListAsync();

    public async Task<User?> GetByEmailAsync(string email) =>
        await context.Users.FirstOrDefaultAsync(u => u.Email == email);

    public async Task AddAsync(User user)
    {
        context.Users.Add(user);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(User user)
    {
        context.Users.Update(user);
        await context.SaveChangesAsync();
    }
}