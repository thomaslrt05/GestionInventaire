using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Inventaire.Models
{
    public class Specificity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public Equipement Equipement { get; set; }
        public Specificity() { }
        public Specificity(int id, string description,Equipement equipement)
        {
            Id = id;
            Description = description;
            Equipement = equipement;
        }
    }
}
