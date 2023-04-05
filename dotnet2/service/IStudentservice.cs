using System;
using dotnet2.Models;

namespace service
{
    public interface IStudentservice
    {
        void StudentDelete(int id );
        void SaveOrUpdate(Students students);
        List<Students> GetStudents(string name);
    }
}