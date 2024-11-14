using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Enums;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations;

public class OrderService : IOrderService
{
    private readonly ApplicationDbContext _dbContext;

    public OrderService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Order> GetOrder()
    {
        return await _dbContext.Orders
            .AsNoTracking()
            .OrderByDescending(o => o.CreatedAt) 
            .FirstAsync(o => o.Quantity > 1);
    }

    public async Task<List<Order>> GetOrders()
    {
        return await _dbContext.Orders
            .AsNoTracking()
            .Where(o => o.User.Status == UserStatus.Active)
            .OrderByDescending(o => o.CreatedAt)
            .ToListAsync();
    }
}