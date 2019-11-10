using APIDemo1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace APIDemo1.Controllers
{
    public class StudentController : ApiController
    {

        //   static List<Student> listStudent = new List<Student>()
        //   {
        //    new Student{id=1,name="mahmoud",age=24,gender="Male"},
        //    new Student{id=2,name="ahmed",age=20,gender="Male"},
        //    new Student{id=3,name="ali",age=26,gender="Male"},
        //    new Student{id=4,name="sara",age=22,gender="Female"},
        //    new Student{id=5,name="ayman",age=21,gender="Male"},
        //    new Student{id=6,name="mai",age=23,gender="Female"},
        //};
         container db = new container();
        // selectall student
        public IHttpActionResult GetStudents()
        {
            var students = from x in db.Students
                           select new StudentDTO()
                           {
                               id = x.id,
                               name = x.name,
                               DepartmenName = x.Department.Name

                           };

            return Ok(students);
        }

        //select by student id 
        public IHttpActionResult GetStudent(int id)
        {
            var s = from x in db.Students
                    where x.id == id
                    select new StudentDTO()
                    {
                        id = x.id,
                        name = x.name,
                        DepartmenName = x.Department.Name

                    };

            if (s == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(s);
            }

        }

        // add new student
        public IHttpActionResult post(Student s)
        {
            if (s == null)
            {
                return BadRequest();
            }
            else
            {
                db.Students.Add(s);
                db.SaveChanges();
                return Created("List of student", db.Students);

            }

        }
        // delete student 
        public IHttpActionResult delete(int id)
        {
            Student s = db.Students.Find(id);
            if (s == null)
            {
                return NotFound();
            }
            else
            {
                db.Students.Remove(s);
                return StatusCode(HttpStatusCode.NoContent);
            }

        }
        // edit student 
        public IHttpActionResult put(int id, Student s)
        {
            db.Students.FirstOrDefault(a => a.id == id).name = s.name;
            db.Students.FirstOrDefault(a => a.id == id).age = s.age;
            db.Students.FirstOrDefault(a => a.id == id).gender = s.gender;
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
