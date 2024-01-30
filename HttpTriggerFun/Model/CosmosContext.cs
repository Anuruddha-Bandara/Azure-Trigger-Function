using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HttpTriggerFun.Model
{
    public class CosmosContext : DbContext
    {

        private readonly FunctionConfiguration _config;

        public DbSet<Book> Books { get; set; }

        public CosmosContext(FunctionConfiguration config)
        {
            _config = config;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
            .ToContainer("Books")  // Replace with your actual container name
            .HasNoDiscriminator()
            .HasPartitionKey(a => a.category);  // Assuming 'Id' is used as the partition key


            modelBuilder.Entity<Book>().OwnsMany(b => b.Authors);

            //  below code is working OK
            //modelBuilder.Entity<Book>().Ignore(b => b.Authors)
            //            .ToContainer("Books")
            //            .HasNoDiscriminator()
            //            .HasPartitionKey(x => x.category).HasKey(x => x.Id);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseCosmos(
                accountEndpoint: _config.CosmosAccountEndpoint,
                accountKey: _config.CosmosAccountKey,
                databaseName: _config.CosmosDatabaseName);
        }
    }
}

