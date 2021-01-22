using EatPizza.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace EatPizza.Infrastructure.Context
{
    public class EatPizzaContext : DbContext
    {
        public EatPizzaContext(DbContextOptions<EatPizzaContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDelivery> OrderDeliveries { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<OrderItemSplit> OrderItemSplits { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedData.Seed(modelBuilder);
        }
    }
}
