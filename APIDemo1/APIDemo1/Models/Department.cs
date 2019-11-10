using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIDemo1.Models
{
    public class Department
    {
        public int id { get; set; }
        public string Name { get; set; }
        public List<Student> Students { get; set; }
    }
}