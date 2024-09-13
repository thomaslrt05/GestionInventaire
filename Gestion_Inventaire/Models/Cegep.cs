using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Inventaire.Models
{
    public class Cegep
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public Localisation Localisation { get; set; }

        public Cegep() { }
        public Cegep(int id, string name, int phoneNumber, Localisation localisation)
        {
            Id = id;
            Name = name;
            PhoneNumber = phoneNumber;
            Localisation = localisation;
        }
    }
}
