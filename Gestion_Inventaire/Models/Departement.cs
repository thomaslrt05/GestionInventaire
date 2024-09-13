using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Inventaire.Models
{
    public class Departement
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Floor { get; set; }
        public Cegep Cegep { get; set; }
        public List<Local> Locals { get; set; }
        public Departement() { }
        public Departement(int id, string name, int floor, Cegep cegep)
        {
            Id = id;
            Name = name;
            Floor = floor;
            Cegep = cegep;
            Locals = new List<Local>();
        }
    }
}
