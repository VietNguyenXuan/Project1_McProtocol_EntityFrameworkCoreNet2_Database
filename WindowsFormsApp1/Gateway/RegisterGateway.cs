using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1.Gateway
{
  public class RegisterGateway
  {
    ApplicationDbContext _dbContext = new ApplicationDbContext();

    public bool Add(Student student)
    {
      _dbContext.Students.Add(student);
      return _dbContext.SaveChanges() > 0;
    }

    internal List<Student> GetAll()
    {
      return _dbContext.Students.ToList();
    }
  }
}
