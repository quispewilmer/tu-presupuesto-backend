using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BTuPresupuesto.Models;
using Microsoft.EntityFrameworkCore;

namespace BTuPresupuesto
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Expenditure> Expenditure { get; set; }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options): base(options)
        {

        }
    }
}
