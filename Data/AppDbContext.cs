using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp_DataBinding_EF.Models;

namespace WpfApp_DataBinding_EF.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=sql.ects;Database=UsersDb_Eremeev;User Id=student_06;Password=student_06;TrustServerCertificate=True;");
        }
    }
}
