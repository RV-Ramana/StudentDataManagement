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
        static List<Student> Students = new List<Student> {
            new Student{RollNo=1,Name="RVR",Rank=2,Age=21},
            new Student{RollNo=2,Name="Ramana",Rank=2,Age=22},
            new Student{RollNo=3,Name="Venkat",Rank=3,Age=23}
        };

        [HttpGet]
        [Route("All")]
        public IEnumerable<Student> GetAllStudents()
        {
            return from student in Students orderby student.RollNo select student;
        }

        [HttpGet]
        [Route("{id}")]
        public Student GetStudent(int id)
        {
            return (from student in Students where student.RollNo == id select student).FirstOrDefault();
        }

        [HttpPost]
        [Route("Add/{Name}/{RollNo}/{Rank}/{Age}")]
        public IEnumerable<Student> Add(string Name, int RollNo, int Rank, int Age)
        {
            Students.Add(new Student { Name = Name, RollNo = RollNo, Rank = Rank, Age = Age });
            return GetAllStudents();
        }

        [HttpPut]
        [Route("Modify/{RollNo}/{Rank=rank}")]
        public IEnumerable<Student> Modify (int RollNo,int Rank)
        {
            Students.Find(student=>student.RollNo==RollNo).Rank=Rank;
            return GetAllStudents();
        }

        [HttpDelete]
        [Route("Remove/{Id}")]
        public IEnumerable<Student> Delete(int Id)
        {
            Students.Remove(Students.Find(student => student.RollNo == Id));
            return GetAllStudents();
        }
    }
}