using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Demo
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Employee> Employee { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder
       optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Server=KISHAN\SQLEXPRESS;Database=StudentMaster;
            Trusted_Connection=True");
        }
    }

}
