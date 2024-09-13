using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Inventaire.Models
{
    public class CourseVM
    {
        public Course Course { get; set; }
        //public Teacher Teacher { get; set; }
        //public Schedule Schedule { get; set; }
        public Local Local { get; set; }
        public CourseVM(){}
        public CourseVM(Course course, Local local)
        {
            Course = course;
           // Teacher = teacher;
            //Schedule = schedule;
            Local = local;
        }

    }
}
