using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Enums;
using TestTask.Models;
using TestTask.Services.Implementations;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations
{
    public class UserService : IUserService
    {

        private readonly ApplicationDbContext _user;

        public UserService(ApplicationDbContext user)
        {
            _user = user;
        }
        public async Task<User> GetUser()
        {
            return await _user.Users.FirstOrDefaultAsync();
        }

        public async Task<IList<User>> GetUsers()
        {
            return await _user.Users.ToListAsync();
        }

        public User GetUserWithMostOrders()
        {
            var userWithMostOrders = _user.Users
                .OrderByDescending(u => u.Orders.Count)
                .FirstOrDefault();

            return userWithMostOrders;
        }

        public List<User> GetInactiveUsers()
        {
            var inactiveUsers = _user.Users
                .Where(u => u.Status == UserStatus.Inactive)
                .ToList();

            return inactiveUsers;
        }
    }
}
