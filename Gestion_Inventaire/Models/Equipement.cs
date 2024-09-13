using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Inventaire.Models
{
    public class Equipement
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public Type Type { get; set; }
        public Mark? Mark { get; set; }
        public List<Specificity> Specificities { get; set; }
        public Equipement() { }
        public Equipement(int id, string? description, Type type, Mark? mark)
        {
            Id = id;
            Description = description;
            Type = type;
            Mark = mark;
            Specificities = new List<Specificity>();
        }
    }
}
