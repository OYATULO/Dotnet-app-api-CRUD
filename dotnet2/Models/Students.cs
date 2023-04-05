using System;
using System.ComponentModel.DataAnnotations;
namespace dotnet2.Models
{
    public class Students
    {
        [Key]
        public int StudentID { get; set; } = 0 ;
        public string StudentName { get; set; } ="";
        public int Studetntage {get;set;}=0;
    }
}