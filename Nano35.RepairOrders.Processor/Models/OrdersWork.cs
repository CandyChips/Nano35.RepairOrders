using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Nano35.RepairOrders.Processor.Models
{
    public class OrdersWork
    {
        public Guid Id { get; set; }
        
        public Guid RepairOrderId { get; set; }
        public Guid WorkId { get; set; }
        public Guid WorkerId { get; set; }
        public string Comment { get; set; }
        public double Price { get; set; }
        public bool IsDeleted { get; set; }
        
        // Foreign keys
        public RepairOrder RepairOrder { get; set; }
        public Work Work { get; set; }
        public ICollection<OrdersWorkState> OrdersWorkStates { get; set; }

        public OrdersWork()
        {
            OrdersWorkStates = new List<OrdersWorkState>();
        }
    }

    public class OrdersWorkFluentContext
    {
        public void Configure(ModelBuilder modelBuilder)
        {
            // Primary key
            modelBuilder.Entity<OrdersWork>()
                .HasKey(u => new {u.Id});  
            
            // Data
            modelBuilder.Entity<OrdersWork>()
                .Property(b => b.RepairOrderId)
                .IsRequired();
            modelBuilder.Entity<OrdersWork>()
                .Property(b => b.WorkId)
                .IsRequired();
            modelBuilder.Entity<OrdersWork>()
                .Property(b => b.WorkerId)
                .IsRequired();
            modelBuilder.Entity<OrdersWork>()
                .Property(b => b.Comment)
                .IsRequired();
            modelBuilder.Entity<OrdersWork>()
                .Property(b => b.Price)
                .IsRequired();
            modelBuilder.Entity<OrdersWork>()
                .Property(b => b.IsDeleted)
                .IsRequired();
            
            // Foreign keys
            modelBuilder.Entity<OrdersWork>()
                .HasOne(p => p.RepairOrder)
                .WithMany(p => p.OrdersWorks)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(p => new {p.RepairOrderId});
            
            modelBuilder.Entity<OrdersWork>()
                .HasOne(p => p.Work)
                .WithMany(p => p.OrdersWorks)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(p => new {p.WorkId});
        }
    }
}