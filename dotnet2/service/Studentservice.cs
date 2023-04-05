using System;
using context;
using dotnet2.Models;
using Microsoft.EntityFrameworkCore;
namespace service
{
    public class Studentservice : IStudentservice
    {
        DataContext _dataContext = null;

        public Studentservice(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public List<Students> GetStudents(string name)
        {
            return _dataContext.Students!.FromSqlRaw($"getstudent {name}").ToList();
        }

        public void SaveOrUpdate(Students students)
        {
             _dataContext.Database.ExecuteSqlRaw($"saveorupdate {students.StudentID}, {students.StudentName}, {students.Studetntage}");
            //test
             var test = _dataContext.Students!.ToList();
        }

        public void StudentDelete(int id)
        {
            _dataContext.Database.ExecuteSqlRaw($"deletestudent {id}");
        }
    }
}