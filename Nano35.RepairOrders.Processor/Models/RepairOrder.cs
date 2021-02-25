using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Nano35.RepairOrders.Processor.Models
{
    public class RepairOrder
    {
        public Guid Id { get; set; }
        
        public Guid ClientId { get; set; }
        public Guid ManagerId { get; set; }
        public Guid ArticleId { get; set; }
        public Guid PaymentId { get; set; }
        public string Serial { get; set; }
        public string Condition { get; set; }
        public string Trouble { get; set; }
        public string Complication { get; set; }
        public double Rate { get; set; }
        public ICollection<OrdersWork> OrdersWorks { get; set; }
        
        public ICollection<ChatMessage> ChatMessages { get; set; }

        public RepairOrder()
        {
            OrdersWorks = new List<OrdersWork>();
            ChatMessages = new List<ChatMessage>();
        }
    }

    public class RepairOrderFluentContext
    {
        public void Configure(ModelBuilder modelBuilder)
        {
            // Primary key
            modelBuilder.Entity<RepairOrder>()
                .HasKey(u => new {u.Id});  
            
            // Data
            modelBuilder.Entity<RepairOrder>()
                .Property(b => b.ClientId)
                .IsRequired();
            modelBuilder.Entity<RepairOrder>()
                .Property(b => b.ManagerId)
                .IsRequired();
            modelBuilder.Entity<RepairOrder>()
                .Property(b => b.ArticleId)
                .IsRequired();
            modelBuilder.Entity<RepairOrder>()
                .Property(b => b.Condition)
                .IsRequired();
            modelBuilder.Entity<RepairOrder>()
                .Property(b => b.Trouble)
                .IsRequired();
            modelBuilder.Entity<RepairOrder>()
                .Property(b => b.Complication)
                .IsRequired();
            modelBuilder.Entity<RepairOrder>()
                .Property(b => b.Rate)
                .IsRequired();
            modelBuilder.Entity<RepairOrder>()
                .Property(b => b.PaymentId);
            modelBuilder.Entity<RepairOrder>()
                .Property(b => b.Serial);
        }
    }
}