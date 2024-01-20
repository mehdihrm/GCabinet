using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class MyDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring
           (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
                (@"Data Source=Localhost\SQLEXPRESS;Initial Catalog=GCabinetDB;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");
        }
    }
}
