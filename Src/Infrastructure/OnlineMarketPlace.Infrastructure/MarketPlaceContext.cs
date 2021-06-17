using Microsoft.EntityFrameworkCore;
using OnlineMarketPlace.Domain;
using OnlineMarketPlace.Domain.DatabaseEntities;

namespace OnlineMarketPlace.Infrastructure
{
    public class MarketPlaceContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<AttributeType> AttributeTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<AttributeValue> AttributeValues { get; set; }
        public DbSet<Message> Messages { get; set; }

        public MarketPlaceContext(DbContextOptions<MarketPlaceContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // one to many user - product
            modelBuilder.Entity<Product>()
                .HasOne(x => x.User)
                .WithMany(x => x.Products)
                .OnDelete(DeleteBehavior.Cascade);

            // one to many object type - product

            modelBuilder.Entity<Product>()
                .HasOne(x => x.ProductType)
                .WithMany(x => x.Products)
                .OnDelete(DeleteBehavior.NoAction);

            // one to many attribute type - attribute value
            modelBuilder.Entity<AttributeValue>()
                .HasOne(x => x.AttributeType)
                .WithMany(x => x.AttributeValues)
                .OnDelete(DeleteBehavior.Cascade);

            // one to many object for sale - attribute value
            modelBuilder.Entity<AttributeValue>()
                .HasOne(x => x.Product)
                .WithMany(x => x.AttributeValues)
                .OnDelete(DeleteBehavior.Cascade);

            // one to many object type - attribute type
            modelBuilder.Entity<AttributeType>()
                .HasOne(x => x.ProductType)
                .WithMany(x => x.AttributeTypes)
                .OnDelete(DeleteBehavior.Cascade);

            // one to many message - receiver
            modelBuilder.Entity<Message>()
                .HasOne(x => x.Receiver)
                .WithMany(x => x.MessagesReceived)
                .OnDelete(DeleteBehavior.NoAction);

            // one to many message - sender
            modelBuilder.Entity<Message>()
                .HasOne(x => x.Sender)
                .WithMany(x => x.MessagesSend)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<User>().HasData(
                new User { 
                    Id = 1, 
                    Username = "Admin User", 
                    Email = "adminuser@gmail.com", 
                    Role = Role.Admin, 
                    Password = "10000.QB2xn83lcGu5WMJGUkvxKg==.nlr0JBDwzVh7U0AxC7wubrhjw9y69jFmDE1kb2e5aVA=", 
                    ColorCode = "#651e3e" }
            );
        }         
    }
}
