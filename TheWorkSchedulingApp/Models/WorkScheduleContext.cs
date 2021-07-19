using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TheWorkSchedulingApp.Models
{
    public class WorkScheduleContext : DbContext
    {
        public WorkScheduleContext(DbContextOptions<WorkScheduleContext> options)
            : base(options)
        { }

        public DbSet<Day> Days { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Position> Positions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DayConfig());
            modelBuilder.ApplyConfiguration(new WorkerConfig());
            modelBuilder.ApplyConfiguration(new PositionConfig());
        }

    }
}
