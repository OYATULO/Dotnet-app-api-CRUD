using System;
using context;
using Microsoft.EntityFrameworkCore;
using Models;

namespace services
{
    public class Services : IServices
    {
        dataContext _dataContext= null;

        public Services(dataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<List<Student>> GetStudents(string name)
        {
           return await _dataContext.Students.FromSqlRaw($"getstudent {name}").ToListAsync(); 
        }
        public async Task DeleteByid(int id)
        {
            await _dataContext.Database.ExecuteSqlRawAsync($"deletestudent {id}");
        }
        public async Task SaveOrUpdate(Student student)
        {
            await _dataContext.Database.ExecuteSqlRawAsync($"saveorupdate {student.StudentID}, {student.StudentName}, {student.Studetntage}");
            //test get data 
            var list = await _dataContext.Students.ToListAsync();
        }
    }
}