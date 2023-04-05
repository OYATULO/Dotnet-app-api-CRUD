using System;
using services;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace dotnetapi.StudentController
{
    [Route("api/controller")]
    [ApiController]
    public class StudentController: ControllerBase
    {
      private  readonly IServices  _iservices;

        public StudentController(IServices iservices)
        {
            _iservices = iservices;
        }
        [HttpGet("getdata")]
        public async Task<List<Student>> GetStudents(string name=""){
            return await _iservices.GetStudents(name);
        }
        [HttpPost("insup")]
        public async Task SaveOrupdate(Student student){
            await _iservices.SaveOrUpdate(student);
        }

        [HttpGet("intget")]
        public async Task<List<Student>> IntGet(string name=""){
            return await Internalstudent.GetStudents(name);
        }
        [HttpGet("intgetas")]
        public async Task<List<Student>> Intgetas(){
            return await Internalstudent.GetStudentsAsync();
        }

        [HttpPost("intpost")]
        public async Task<IResult> intpost(Student student){
            bool t= await Internalstudent.InsertStudent(student);
            if (t)
            {
                return Results.Ok("inserted successfull");
            }
            else 
                return Results.BadRequest("no inserted");
        }
    }
}