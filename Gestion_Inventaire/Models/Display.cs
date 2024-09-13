using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Inventaire.Models
{
    public class Display
    {
        public int Id { get; set; }
        public List<Content>? Contents { get; set; }
        public Departement Departement { get; set; }
        public Display() { }
        public Display(int id, List<Content>? contents, Departement departement)
        {
            Id = id;
            Contents = new List<Content>();
            Departement = departement;
        }
    }
}
