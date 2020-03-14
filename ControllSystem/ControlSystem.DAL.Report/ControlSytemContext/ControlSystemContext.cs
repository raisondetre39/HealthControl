using ControlSystem.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using System;

namespace ControlSystem.DAL.ControlSystemContext
{
    public class ControlSystemContext : DbContext //, IControlSystemContext
    {
        private readonly string CONNECTION = "Server=health-control.cmhkqigvllj1.us-east-1.rds.amazonaws.com;Database=health_control;Uid=admin;Pwd=mTq5KM8MDFCi4ZJvhAgu;";

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
