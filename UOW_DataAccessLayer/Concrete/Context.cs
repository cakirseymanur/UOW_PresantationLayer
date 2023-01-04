using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UOW_EntityLayer.Concrete;

namespace UOW_DataAccessLayer.Concrete
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;initial catalog=DbUOWProject;integrated security=true");
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<ProcessDetail> ProcessDetails { get; set; }
    }
}
