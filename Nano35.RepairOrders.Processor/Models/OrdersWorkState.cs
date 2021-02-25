using System;
using Microsoft.EntityFrameworkCore;

namespace Nano35.RepairOrders.Processor.Models
{
    public enum OrdersWorkStateType
    {
        Created = 0,
        InWork = 1,
        Completed = 2,
        Stopped = 3,
        OnWait = 4
    }
    
    public class OrdersWorkState
    {
        public Guid Id { get; set; }
        
        public Guid OrdersWorkId { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        public bool IsDeleted { get; set; }
        public int Type { get; set; }
        
        // Foreign keys
        public OrdersWork OrdersWork { get; set; }
    }

    public class OrdersWorkStateFluentContext
    {
        public void Configure(ModelBuilder modelBuilder)
        {
            // Primary key
            modelBuilder.Entity<OrdersWorkState>()
                .HasKey(u => new {u.Id});  
            
            // Data
            modelBuilder.Entity<OrdersWorkState>()
                .Property(b => b.OrdersWorkId)
                .IsRequired();
            modelBuilder.Entity<OrdersWorkState>()
                .Property(b => b.Date)
                .IsRequired();
            modelBuilder.Entity<OrdersWorkState>()
                .Property(b => b.Comment)
                .IsRequired();
            modelBuilder.Entity<OrdersWorkState>()
                .Property(b => b.IsDeleted)
                .IsRequired();
            modelBuilder.Entity<OrdersWorkState>()
                .Property(b => b.Type)
                .IsRequired();
        }
    }
}