using System;
using Models;

namespace services
{
    public interface IServices
    {
       Task<List<Student>> GetStudents(string name);
       Task SaveOrUpdate(Student student);
       Task DeleteByid(int id);
    }
}