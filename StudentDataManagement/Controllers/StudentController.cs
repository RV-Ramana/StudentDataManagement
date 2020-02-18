using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StudentDataManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        List<Student> Students = new List<Student> {
            new Student{RollNo=1,Name="RVR",Rank=2,Age=21},
            new Student{RollNo=2,Name="Ramana",Rank=2,Age=22},
            new Student{RollNo=3,Name="Venkat",Rank=3,Age=23}
        };

        [HttpGet]
        [Route("All")]
        public List<Student> GetAllStudents()
        {
            return Students;
        }

        [HttpGet]
        [Route("{id}")]
        public Student GetStudent(int id)
        {
            return (from student in Students where student.RollNo == id select student).FirstOrDefault();
        }

        [HttpPost]
        [Route("Add/{Name=name}")]
        public void Add(string Name)
        {
            List<Student> Students = GetAllStudents();
            Students.Add(new Student{ RollNo=0,Name=Name,Rank=2,Age=22});
        }

        [HttpDelete]
        [Route("Remove/{Id}")]
        public void Delete(int Id)
        {
            Student student = Students.Find(student=>student.RollNo==Id);
            Students.Remove(student);
        }
    }
}