using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _order;

        public OrderService(ApplicationDbContext order)
        {
            _order = order;
        }

        public async Task<Order> GetOrder()
        {
            return await _order.Orders.FirstOrDefaultAsync();
        }

        public async Task<IList<Order>> GetOrders()
        {
            return await _order.Orders.ToListAsync();
        }

        public Order GetOrderWithHighestTotalAmount()
        {
            var orderWithHighestTotalAmount = _order.Orders
                .OrderByDescending(o => o.Price * o.Quantity)
                .FirstOrDefault();

            return orderWithHighestTotalAmount;
        }

        public List<Order> GetOrdersWithQuantityGreaterThan(int quantity)
        {
            var ordersWithQuantityGreaterThan = _order.Orders
                .Where(o => o.Quantity > quantity)
                .ToList();

            return ordersWithQuantityGreaterThan;
        }

    }
}
