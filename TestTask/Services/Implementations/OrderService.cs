using TestTask.Data;
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
    
    public Task<Order> GetOrder()
    {
        throw new NotImplementedException();
    }

    public Task<List<Order>> GetOrders()
    {
        throw new NotImplementedException();
    }
}