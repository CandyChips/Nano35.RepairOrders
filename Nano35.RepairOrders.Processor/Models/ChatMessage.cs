using System;
using Microsoft.EntityFrameworkCore;

namespace Nano35.RepairOrders.Processor.Models
{
    public class ChatMessage
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public Guid RepairOrderId { get; set; }
        public DateTime Date { get; set; }
        
        public RepairOrder RepairOrder { get; set; }
    }

    public class WorkersChatMessage :
        ChatMessage
    {
        public Guid WorkerId { get; set; }
    }

    public class ClientsChatMessage :
        ChatMessage
    {
        public Guid ClientId { get; set; }
    }

    public class ChatMessageFluentContext
    {
        public void Configure(ModelBuilder modelBuilder)
        {
            // Primary key
            modelBuilder.Entity<ChatMessage>()
                .HasKey(u => new {u.Id});  
            
            // Data
            modelBuilder.Entity<ChatMessage>()
                .Property(b => b.Message)
                .IsRequired();
            modelBuilder.Entity<ChatMessage>()
                .Property(b => b.RepairOrderId)
                .IsRequired();
            modelBuilder.Entity<ChatMessage>()
                .Property(b => b.Date)
                .IsRequired();
            
            // Foreign keys
            modelBuilder.Entity<WorkersChatMessage>()
                .Property(b => b.WorkerId)
                .IsRequired();
            
            modelBuilder.Entity<ClientsChatMessage>()
                .Property(b => b.ClientId)
                .IsRequired();

            modelBuilder.Entity<ChatMessage>()
                .HasOne(p => p.RepairOrder)
                .WithMany(p => p.ChatMessages)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(p => new {p.RepairOrderId});
        }
    }
}