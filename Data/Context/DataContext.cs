using Data.Types;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Product> Products { get; set; }
<<<<<<< HEAD
        public DbSet<Payment> Payments { get; set; }
=======
        public DbSet<RequestHistory> RequestsHistory { get; set; }
>>>>>>> e19fb1081680dae65a198c10cbb697f25b217d75

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientMap());
            modelBuilder.ApplyConfiguration(new ItemMap());
            modelBuilder.ApplyConfiguration(new RequestMap());
<<<<<<< HEAD
            modelBuilder.ApplyConfiguration(new Stores());
            modelBuilder.ApplyConfiguration(new PaymentMap());
=======
            modelBuilder.ApplyConfiguration(new StoreMap());
            modelBuilder.ApplyConfiguration(new RequestHistoryMap());
>>>>>>> e19fb1081680dae65a198c10cbb697f25b217d75
        }

    }
}