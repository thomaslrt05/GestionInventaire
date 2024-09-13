using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Gestion_Inventaire.Models;

namespace Gestion_Inventaire.DataAccesLayer.Factories
{
    public class DepartementFact
    {
        public Departement CreateFromReader(MySqlDataReader reader)
        {
            int id = (int)reader["Id"];
            string name = (string)reader["Name"];
            int floor = (int)reader["Floor"];
            Localisation localisation = new Localisation(1, "Jacques-Cartier E", 534,716);
            Cegep cegep = new Cegep(1, "Chicoutimi", 450200, localisation);
            return new Departement(id, name,floor,cegep);
        }

        public Departement Get(int id)
        {
            return new Departement();
        }
    }
}
