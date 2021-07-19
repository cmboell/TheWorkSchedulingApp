using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheWorkSchedulingApp.Models
{
    public interface IWorkScheduleUnitOfWork
    {
        public IRepository<Day> Days { get; }
        public IRepository<Worker> Workers { get; }
        public IRepository<Position> Positions { get; }

        public void Save();
    }
}