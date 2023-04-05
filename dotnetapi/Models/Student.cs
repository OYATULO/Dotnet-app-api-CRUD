using System;
using System.ComponentModel.DataAnnotations;
namespace Models
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; } = 0 ;
        public string StudentName { get; set; } ="";
        public int Studetntage {get;set;}=0;
    }
} 