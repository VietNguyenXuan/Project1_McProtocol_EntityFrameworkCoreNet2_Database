using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models
{
  internal class ApplicationDbContext:DbContext
  {
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlite("Data Source=D:\\McProtocol_EntityFrameworkCoreNet2_Database\\DB\\Database.db");
    }
    public DbSet<Student> Students { get; set; }
  }
}
