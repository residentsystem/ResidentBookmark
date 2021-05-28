using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using ResidentBookmark.Models;
using ResidentSystemLibrary.Database;

namespace ResidentBookmark.Data
{
    public class ResidentBookmarkContext : DbContext
    {
        private IConfiguration _configuration;
        
        private IDatabaseConnection _database;

        public ResidentBookmarkContext(IConfiguration configuration, IDatabaseConnection database)
        {
            _configuration = configuration;
            _database = database;
        }

        // The context has two DbSet properties. The DbSet classes maps to a table in the database.
        public DbSet<Website> Websites { get; set; }

        public DbSet<Label> Labels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {

            // Bind the content of default configuration file "bookmarksettings.json" to an instance of DatabaseSettings. 
            DatabaseEnvironment connectionstring = _configuration.GetSection("ConnectionString").Get<DatabaseEnvironment>();

            // optionsBuilder.UseMySql(_database.GetConnectionString(connectionstring),
            // new MySqlServerVersion(new Version(8, 0, 19)), 
            // mySqlOptions => mySqlOptions.CharSetBehavior(CharSetBehavior.NeverAppend));

            optionsBuilder.UseSqlite(_database.GetConnectionString(connectionstring));

            // optionsBuilder.UseSqlServer(_database.GetConnectionString());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Website>()
            .HasOne<Label>(l => l.Label)
            .WithMany(w => w.Websites)
            .HasForeignKey(l => l.LabelId)
            .IsRequired(true);

            modelBuilder.Entity<Website>().HasIndex(l => l.LabelId).HasDatabaseName("Website_LabelId");

            modelBuilder.Entity<Website>(website =>
            {
                website.Property(w => w.Name).HasColumnType("varchar(50)").IsRequired(true);
                website.Property(w => w.Location).HasColumnType("varchar(200)").IsRequired(true);
                website.Property(w => w.Note).HasColumnType("varchar(60)").IsRequired(false);
            });

            modelBuilder.Entity<Label>(label =>
            {
                label.Property(l => l.Name).HasColumnType("varchar(50)").IsRequired(true);
                label.Property(l => l.Description).HasColumnType("varchar(60)").IsRequired(false);
            });
        }
    }
}