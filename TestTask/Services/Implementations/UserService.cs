using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations;

public class UserService : IUserService
{
    private readonly ApplicationDbContext _dbContext;

    public UserService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<User> GetUser()
    {
        return await _dbContext.Users
            .AsNoTracking()
            .Include(u => u.Orders)
            .OrderByDescending(u => u.Orders
                .Where(o => o.CreatedAt.Year == 2003)
                .Sum(o => o.Price * o.Quantity))
            .FirstAsync();
    }

    public async Task<List<User>> GetUsers()
    {
        return await _dbContext.Users
            .AsNoTracking()
            .Include(u => u.Orders)
            .OrderByDescending(u => u.Orders.Where(o => o.CreatedAt.Year == 2010))
            .ToListAsync();
    }
}