using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Inventaire.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Schedule Schedule { get; set; }
        public Teacher Teacher { get; set; }
        public Course() { }
        public Course(int id, string name, Schedule schedule, Teacher teacher)
        {
            Id = id;
            Name = name;
            Schedule = schedule;
            Teacher = teacher;
        }
    }
}
