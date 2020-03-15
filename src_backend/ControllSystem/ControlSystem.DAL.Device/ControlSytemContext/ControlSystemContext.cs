using ControlSystem.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ControlSystem.DAL.Device.ControlSystemContext
{
    public class ControlSystemContext : DbContext
    {
        //private readonly string CONNECTION = "Server=health-control.cmhkqigvllj1.us-east-1.rds.amazonaws.com;Database=health_control;Uid=admin;Pwd=mTq5KM8MDFCi4ZJvhAgu;";
        private readonly string CONNECTION = "Server=localhost;Database=health_control;Uid=admin;Pwd=root;";

        public DbSet<Contracts.Entities.Device> Devices { get; set; }
        public DbSet<Indicator> Indicators { get; set; }
        public DbSet<User> Users { get; set; }

        public ControlSystemContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql(CONNECTION);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
               .HasOne(s => s.Device)
               .WithOne(ad => ad.User)
               .HasForeignKey<Contracts.Entities.Device>(ad => ad.UserId);

            modelBuilder.Entity<Contracts.Entities.User>()
                .HasOne(s => s.Disease)
                .WithMany(ad => ad.Users)
                .HasForeignKey(ad => ad.DiseaseId);

            modelBuilder.Entity<DeviceInicator>()
                .HasAlternateKey(sc => new { sc.IndicatorId, sc.DeviceId });

            modelBuilder.Entity<IndicatorValue>()
                .HasOne(iv => iv.DeviceInicator)
                .WithMany(i => i.IndicatorValues)
                .HasForeignKey(ind => ind.DeviceIndicatorId);
        }
    }
}
