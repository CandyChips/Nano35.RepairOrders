using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nano35.RepairOrders.Processor.Models;

namespace Nano35.RepairOrders.Processor.Services
{
    public class ApplicationContext : DbContext
    {
        
        public DbSet<OrdersWork> OrdersWorks {get;set;}
        public DbSet<OrdersWorkState> OrdersWorkStates {get;set;}
        public DbSet<RepairOrder> RepairOrders {get;set;}
        public DbSet<Work> Works {get;set;}
        public DbSet<ChatMessage> ChatMessages {get;set;}
        public DbSet<WorkersChatMessage> WorkersChatMessages {get;set;}
        public DbSet<ClientsChatMessage> ClientsChatMessages {get;set;}
        
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
            Update();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new OrdersWorkFluentContext().Configure(modelBuilder);
            new OrdersWorkStateFluentContext().Configure(modelBuilder);
            new RepairOrderFluentContext().Configure(modelBuilder);
            new WorkFluentContext().Configure(modelBuilder);
            new ChatMessageFluentContext().Configure(modelBuilder);
            
            base.OnModelCreating(modelBuilder);
        }
        public void Update()
        {
            OrdersWorks.Load();
            OrdersWorkStates.Load();
            RepairOrders.Load();
            Works.Load();
            ChatMessages.Load();
            WorkersChatMessages.Load();
            ClientsChatMessages.Load(); 
        }
    }
    public class DataInitializer
    {
        public static async Task InitializeRolesAsync(
            ApplicationContext modelBuilder)
        {
            
        }
    }
}
