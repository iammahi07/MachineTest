using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MachineTest.Models;

namespace MachineTest.Data
{
    public class MachineTestContext : DbContext
    {
        public MachineTestContext (DbContextOptions<MachineTestContext> options)
            : base(options)
        {
        }

        public DbSet<MachineTest.Models.Category> Category { get; set; } = default!;
        public DbSet<Product> Products { get; set; }
    }
}
