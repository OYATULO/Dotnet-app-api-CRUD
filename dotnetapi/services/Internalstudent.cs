using System;
using context;
using Models;
using Microsoft.EntityFrameworkCore;
namespace services
{
    internal static class Internalstudent
    {
        
        //get data from sql server With internal Class 

        internal async static Task<List<Student>> GetStudentsAsync(){
            using (var db = new  dataContext())
            {   
                return await db.Students.ToListAsync();
            }
        }
        internal async static Task<bool> InsertStudent(Student student){
            using ( var db = new dataContext())
            {
                try
                {
                    await db.AddAsync(student);
                    return await db.SaveChangesAsync()>=1;
                }
                catch (System.Exception)
                {
                     return false;
                }
            }
        }
        internal async static Task<bool> UdateStudentByid(Student student){
            using (var db = new dataContext())
            {
                try
                {
                       db.Update(student);
                       return await db.SaveChangesAsync()>=1;
                 }
                catch (System.Exception)
                {
                    return false;
                }    
            }
        }
        // get with stote procedure
        internal async static Task<List<Student>> GetStudents(string name){
            using (var db =  new dataContext())
            {
                return await db.Students.FromSqlRaw($"getstudent {name}").ToListAsync();
            }
        }

        internal async static Task<Student> GetStudentById(int id){
            using (var db= new dataContext()) {
                return await db.Students.FirstAsync(x=>x.StudentID == id);
            }
        }
        internal async static Task<bool> SaveOrUpdate(Student student){
            using (var db = new dataContext())
            {
                try
                {
                    await db.Database.ExecuteSqlRawAsync($"saveorupdate {student.StudentID}, {student.StudentName}, {student.Studetntage}");
                    return await db.SaveChangesAsync()>=1;
                }
                catch (System.Exception)
                {
                    return false;
                }
            }
        }
        internal async static Task<bool> DeleteById(int id){
            using (var db = new dataContext())
            {
                try
                {
                    var stid=  await GetStudentById(id);
                    db.Remove(stid);
                    return await db.SaveChangesAsync()>=1;
                }
                catch (System.Exception)
                {
                   return false;
                }
                
            }
        }


    }
}