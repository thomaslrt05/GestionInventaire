using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Inventaire.Models
{
    public class Local
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public List<Schedule>? Schedules { get; set; }
        public List<Equipement> Equipements { get; set; }
        public Departement Departement { get; set; } 

        public Local() { }
        public Local(int id, int number, Departement departement)
        {
            Id = id;
            Number = number;
            Schedules = new List<Schedule>();
            Equipements = new List<Equipement>();
            Departement = departement;
        }
    }
}
