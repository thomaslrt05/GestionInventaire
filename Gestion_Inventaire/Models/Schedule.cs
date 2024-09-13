using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Inventaire.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Local Local { get; set; }
        public List<Course> Courses { get; set; }
        public Schedule() { }
        public Schedule(int id, DateTime date, Local local)
        {
            Id = id;
            Date = date;
            Local = local;
            Courses = new List<Course>();
        }
    }
}
