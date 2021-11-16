using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharp.Models;
using Microsoft.EntityFrameworkCore;

namespace CSharp.Models.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderContext _context;

        public OrderRepository(OrderContext context)
        {
            _context = context;
        }
        public async Task<Order> Create(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return order;
        }

        public async Task Delete(int id)
        {
            var orderCancel = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(orderCancel);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Order>> Get()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order> Get(int id)
        {
            return await _context.Orders.FindAsync(id);
        }

        public async Task Update(Order order)
        {
            _context.Entry(order).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
