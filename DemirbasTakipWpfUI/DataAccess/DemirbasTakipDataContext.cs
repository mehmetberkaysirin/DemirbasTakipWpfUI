using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemirbasTakipWpfUI.Entities;

namespace DemirbasTakipWpfUI.DataAccess
{
    public class DemirbasTakipDataContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Departmant> Departmants { get; set; }
        public DbSet<Personnel> Personnels { get; set; }

        public DbSet<Allocation> Allocations { get; set; }
    }
}
