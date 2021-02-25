using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Nano35.RepairOrders.Processor.Models
{
    public class Work
    {
        public Guid Id { get; set; }
        
        public Guid InstanceId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<OrdersWork> OrdersWorks { get; set; }

        public Work()
        {
            OrdersWorks = new List<OrdersWork>();
        }
    }

    public class WorkFluentContext
    {
        public void Configure(ModelBuilder modelBuilder)
        {
            // Primary key
            modelBuilder.Entity<Work>()
                .HasKey(u => new {u.Id});  
            
            // Data
            modelBuilder.Entity<Work>()
                .Property(b => b.InstanceId)
                .IsRequired();
            modelBuilder.Entity<Work>()
                .Property(b => b.Name)
                .IsRequired();
            modelBuilder.Entity<Work>()
                .Property(b => b.Price)
                .IsRequired();
            modelBuilder.Entity<Work>()
                .Property(b => b.IsDeleted)
                .IsRequired();
        }
    }
}