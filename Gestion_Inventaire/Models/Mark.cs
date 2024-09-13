using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Inventaire.Models
{
    public class Mark
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Mark() { }
        public Mark(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
