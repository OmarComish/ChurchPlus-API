using System;
using ChurchPlus_v1._0.AuthService;
using ChurchPlus_v1._0.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Pomelo.EntityFrameworkCore.MySql.Internal;

namespace ChurchPlus_v1._0.DAL
{
    public class DataContext : DbContext
    {
        private CryptoSecureSignin _securesignin = new CryptoSecureSignin();
        public DbSet<AppLogs> AppLogs { get; set; }
        public DbSet<CauseCategory> CauseCategory { get; set; }
        public DbSet<Expense> Expense { get; set; }
        public DbSet<Offering> Offerings { get; set; }
        public DbSet<OfferingGroup> OfferingGroup { get; set; }
        public DbSet<Pledge> Pledge {get;set;}
        public DbSet<Receipts> Receipts{ get; set; }
        public DbSet<RecordStatus> RecordStatus { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseMySql(configuration.GetConnectionString("DataContext"),
            new MySqlServerVersion(new Version(8,0,35)),MySqlOptions=>MySqlOptions.CharSetBehavior(CharSetBehavior.NeverAppend));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
               modelBuilder
                .Entity<User>()
                .HasData(
                    new User
                    {
                        Id = 1,
                        UserName = "admin",
                        Password = _securesignin.Encrypt("Password123"),
                        Email = "admin@codaflem.com",
                        CreatedBy = 1,
                        DateCreated = DateTime.Now,
                        CumulativeLogin = 0,
                        Status = 1,
                        LastSignedOn = DateTime.Now,
                        ModifiedBy = 2,
                        RoleId = 1,
                        MobileNumber = "0999349649",
                        FirstName = "Comish",
                        LastName = "Omar"
                    }
                );
               modelBuilder
                .Entity<UserRole>()
                .HasData(
                    new UserRole
                    {
                        Id = 1,
                        Name = "Admin",
                        DateCreated = DateTime.Now,
                        CreatedBy = 1,
                    },
                    new UserRole
                    {
                        Id = 2,
                        Name = "Trustee",
                        CreatedBy = 1,
                        DateCreated = DateTime.Now
                    },
                     new UserRole
                    {
                        Id = 3,
                        Name = "Treasurer",
                        CreatedBy = 1,
                        DateCreated = DateTime.Now
                    }
                );
                modelBuilder
                .Entity<CauseCategory>()
                .HasData(
                    new CauseCategory{Id = 1, CauseName="Project", CreatedBy = 1, DateCreated =DateTime.Now, Status = 1},
                    new CauseCategory{Id = 2, CauseName="Charity", CreatedBy = 1, DateCreated =DateTime.Now, Status = 1},
                    new CauseCategory{Id = 3, CauseName="Church service", CreatedBy = 1, DateCreated =DateTime.Now, Status = 1},
                    new CauseCategory{Id = 4, CauseName="Other event", CreatedBy = 1, DateCreated =DateTime.Now, Status = 1}
                );
                modelBuilder
                .Entity<OfferingGroup>()
                .HasData( 
                    new OfferingGroup {Id = 1, GroupName = "Sunday service", CreatedBy = 1, DateCreated =DateTime.Now,},
                    new OfferingGroup {Id = 2, GroupName = "Wednesday service", CreatedBy = 1, DateCreated =DateTime.Now,},
                    new OfferingGroup {Id = 3, GroupName = "Friday service", CreatedBy = 1, DateCreated =DateTime.Now,}
                );

                modelBuilder
                .Entity<RecordStatus>()
                .HasData(
                    new RecordStatus {Id = 1, Name ="Active", CreatedBy = 1, DateCreated = DateTime.Now},
                    new RecordStatus {Id = 2, Name ="Discarded", CreatedBy = 1, DateCreated = DateTime.Now},
                    new RecordStatus {Id = 3, Name ="Disabled", CreatedBy = 1, DateCreated = DateTime.Now},
                    new RecordStatus {Id = 4, Name ="Approved", CreatedBy = 1, DateCreated = DateTime.Now},
                    new RecordStatus {Id = 5, Name ="Declined", CreatedBy = 1, DateCreated = DateTime.Now},
                    new RecordStatus {Id = 6, Name ="Pending", CreatedBy = 1, DateCreated = DateTime.Now}
                );

        }
    }
}