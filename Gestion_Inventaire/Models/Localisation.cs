using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Inventaire.Models
{
    public class Localisation
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public int PostalCode { get; set; }
        public Localisation() { }

        public Localisation(int id, string street, int number, int postalCode)
        {
            Id = id;
            Street = street;
            Number = number;
            PostalCode = postalCode;
        }
    }
}
