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
    
    public Task<User> GetUser()
    {
        throw new NotImplementedException();
    }

    public Task<List<User>> GetUsers()
    {
        throw new NotImplementedException();
    }
}