using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ScrumDbContext : DbContext
    {
        public ScrumDbContext(DbContextOptions<ScrumDbContext> options) : base(options)
        {

        }


        public DbSet<TFSUser> TFSUsers { get; set; }
        public DbSet<Squad> Squads { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<SystemConfig> SystemConfigs { get; set; }
        public DbSet<AbsenceTypes> AbsentTypes { get; set; }
        public DbSet<EmployeeAbsence> EmployeeAbsences { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        //    base.OnConfiguring(optionsBuilder);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TFSUser>()
                .HasOne(e => e.Creator)
                .WithMany()
                .HasForeignKey(e => e.CreatedBy);

            modelBuilder.Entity<TFSUser>()
                .HasOne(x => x.Squad)
                .WithMany(x => x.TFSUsers)
                .OnDelete(DeleteBehavior.SetNull);

            base.OnModelCreating(modelBuilder);

            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
