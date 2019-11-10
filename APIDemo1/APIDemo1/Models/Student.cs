using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIDemo1.Models
{
    public class Student
    {
        public int id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public string gender { get; set; }
        public Department Department { get; set; }
    }
}