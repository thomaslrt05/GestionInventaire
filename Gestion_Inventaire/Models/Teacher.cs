using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Inventaire.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public List<Course>? Courses { get; set; }

        public Teacher() { }
        public Teacher(int id, string name, string mail)
        {
            Id = id;
            Name = name;
            Mail = mail;
            Courses = new List<Course>();
        }
    }
}
