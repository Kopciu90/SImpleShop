﻿using SimpleShop.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleShop.Application.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUserByIdAsync(int id);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);
    }
}
