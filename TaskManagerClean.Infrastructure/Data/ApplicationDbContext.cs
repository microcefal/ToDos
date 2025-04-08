using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerClean.Domain.Models;

namespace TaskManagerClean.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
      public  DbSet<TodoTask> Tasks { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) 
        {
            Database.Migrate();
        }
    }
}
