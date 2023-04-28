using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserSample.Data.Service.Entities;

namespace UserSample.Data.Service.EF
{
    public class UserSampleContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<User> Users { get; set; }
        public UserSampleContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(a =>
            {
                a.ToTable("Users").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                //a.Property(p => p.IsActive).HasColumnName("IsActive");
                //a.Property(p => p.ModifiedDate).HasColumnName("ModifiedDate");
                a.Property(p => p.CreatedDate).HasColumnName("ModifiedDate");
            });



            User[] users = { new() { Id = Guid.NewGuid(),Name ="test",Surname="test",TCKNumber=1111111111, BirthDate=DateTime.Now,CreatedDate=DateTime.Now,IsActive=true },
            new() { Id=  Guid.NewGuid(),Name="test1",Surname="test1",TCKNumber=1111111112, BirthDate=DateTime.Now,CreatedDate=DateTime.Now,IsActive=true }
            };
            modelBuilder.Entity<User>().HasData(users);

        }
    }
}
