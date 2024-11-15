﻿using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Enums;
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
            .OrderByDescending(u => u.Orders
                .Where(o => o.CreatedAt.Year == 2003 && o.Status == OrderStatus.Delivered) 
                .Sum(o => o.Price * o.Quantity))
            .FirstAsync();
    }

    public async Task<List<User>> GetUsers()
    {
        return await _dbContext.Users
            .AsNoTracking()
            .Select(u => new 
            {
                User = u,
                OrderCountIn2010 = u.Orders
                    .Count(o => o.CreatedAt.Year == 2010 && o.Status == OrderStatus.Paid)
            })
            .OrderByDescending(u => u.OrderCountIn2010)
            .Select(u => u.User) 
            .ToListAsync();
    }
}