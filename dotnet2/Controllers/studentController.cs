using Microsoft.AspNetCore.Mvc;
using dotnet2.Models;
using service;
using System.Linq;

namespace dotnet2.Controllers;

public class  StudentController: Controller
{
    
    IStudentservice _istudentservice = null;
    public StudentController(IStudentservice istudentservice)
    {
        _istudentservice = istudentservice;
    }
    [Route("student/get")]
    public List<Students> GetStudents(string name){
      return _istudentservice.GetStudents(name);
    }
    [Route("student/insup")]    
    public void SaveOrUpdate(Students students ){
         _istudentservice.SaveOrUpdate(students);
    }
    [Route("student/del")]
    public void delete(int id){
        _istudentservice.StudentDelete(id);
    }
    public ActionResult<List<Students>> Index(){
        var list = GetStudents("");
            return View(list);
    }
    public  ActionResult<Students> Update(int StudentID){
       var list = GetStudents("").Where(s=>s.StudentID==StudentID).FirstOrDefault();
       return View(list);
    }
    [Route("student/delete")]
    public ActionResult Deletebyid(int id){
        _istudentservice.StudentDelete(id);
        return Redirect("~/Student");
    }

   
}
