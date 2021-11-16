using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CSharp.Models
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Order> Orders { get; set; }
    }
}
