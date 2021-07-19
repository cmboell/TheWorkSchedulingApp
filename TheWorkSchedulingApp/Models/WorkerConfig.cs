using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TheWorkSchedulingApp.Models
{
    internal class WorkerConfig : IEntityTypeConfiguration<Worker>
    {
        public void Configure(EntityTypeBuilder<Worker> entity)
        {
            entity.HasData(
               new Worker { WorkerId = 1, FirstName = "Colby", LastName = "Boell" },
               new Worker { WorkerId = 2, FirstName = "Asa", LastName = "Hoffman" },
               new Worker { WorkerId = 3, FirstName = "Joe", LastName = "Hanson" },
               new Worker { WorkerId = 4, FirstName = "Jon", LastName = "Crook" }
            );
        }
    }

}
