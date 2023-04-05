using System;
using Microsoft.EntityFrameworkCore;
using Models;

namespace context
{
    public class dataContext : DbContext
    {
      
      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){

            string connection = "Data Source=localhost,1433; Initial Catalog=SchoolDB; User ID=sa; Password=SLA_affeASwqwrjkxcWkjlasdf; Encrypt=false";
            optionsBuilder.UseSqlServer(connection);
      }
      public DbSet<Student>   Students{get;set;}
    }
}