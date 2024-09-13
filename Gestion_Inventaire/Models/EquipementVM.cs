using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Inventaire.Models
{
    class EquipementVM
    {
        public Equipement Equipement { get; set; }
        public Mark Mark { get; set; }
        public Type Type { get; set; }
        public EquipementVM() { }
        public EquipementVM(Equipement equipement,Mark mark, Type type) 
        {
            Equipement = equipement;
            Mark = mark;
            Type = type;
        }
    }
}
