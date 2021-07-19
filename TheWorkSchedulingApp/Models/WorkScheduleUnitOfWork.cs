using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheWorkSchedulingApp.Models
{
    public class WorkScheduleUnitOfWork : IWorkScheduleUnitOfWork
    {
        private WorkScheduleContext context { get; set; }
        public WorkScheduleUnitOfWork(WorkScheduleContext ctx) => context = ctx;

        private IRepository<Day> dayData;
        public IRepository<Day> Days
        {
            get
            {
                if (dayData == null)
                    dayData = new Repository<Day>(context);
                return dayData;
            }
        }

        private IRepository<Worker> workerData;
        public IRepository<Worker> Workers
        {
            get
            {
                if (workerData == null)
                    workerData = new Repository<Worker>(context);
                return workerData;
            }
        }

        private IRepository<Position> positionData;
        public IRepository<Position> Positions
        {
            get
            {
                if (positionData == null)
                    positionData = new Repository<Position>(context);
                return positionData;
            }
        }

        public void Save() => context.SaveChanges();
    }
}
