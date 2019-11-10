using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using APIDemo1.Models;

namespace APIDemo1.Controllers
{
    public class DepartmentController : ApiController
    {
        container db = new container();

        // selectall Departments
        public IHttpActionResult GetDepartments()
        {
            var departments = from x in db.Departments
                           select new DepartmentDTO()
                           {
                               id = x.id,
                               Name = x.Name,
                               

                           };

            return Ok(departments);
        }

        //select by department id 
        public IHttpActionResult GetDepartment(int id)
        {
            var s = from x in db.Departments
                    where x.id == id
                    select new DepartmentDTO()
                    {
                        id = x.id,
                        Name = x.Name,
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

        // add new department
        public IHttpActionResult post(Department s)
        {
            if (s == null)
            {
                return BadRequest();
            }
            else
            {
                db.Departments.Add(s);
                db.SaveChanges();
                return Created("department", db.Departments);

            }

        }
        // delete department 
        public IHttpActionResult delete(int id)
        {
            Department s = db.Departments.Find(id);
            if (s == null)
            {
                return NotFound();
            }
            else
            {
                db.Departments.Remove(s);
                return StatusCode(HttpStatusCode.NoContent);
            }

        }
        // edit Department 
        public IHttpActionResult put(int id, Department s)
        {
            db.Departments.FirstOrDefault(a => a.id == id).Name = s.Name;
            
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
