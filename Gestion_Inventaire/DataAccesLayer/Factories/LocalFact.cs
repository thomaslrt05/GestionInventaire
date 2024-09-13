using Gestion_Inventaire.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestion_Inventaire.DataAccesLayer;

namespace Gestion_Inventaire.DataAccesLayer.Factories
{
    public class LocalFact
    {
        public Local CreateFromReader(MySqlDataReader reader)
        {
            int id = (int)reader["Id"];
            int number = (int)reader["Number"];
            int departementId = (int)reader["Departement_id"];
            DAL dal = new DAL();
            Departement? departement = dal.DepartementFact.Get(departementId);
            return new Local(id, number,departement);
        }

        public Local Get(int id)
        {
            Local? local = null;
            MySqlConnection? mySqlCnn = null;
            MySqlDataReader? mySqlDataReader = null;

            try
            {
                mySqlCnn = new MySqlConnection(DAL.ConnectionString);
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "SELECT * FROM local WHERE id = @id";
                mySqlCmd.Parameters.AddWithValue("@id", id);

                mySqlDataReader = mySqlCmd.ExecuteReader();
                if (mySqlDataReader.Read())
                {
                    local = CreateFromReader(mySqlDataReader);
                }
            }
            finally
            {
                mySqlDataReader?.Close();
                mySqlCnn?.Close();
            }

            return local;
        }

        public List<Local>? GetAll()
        {
            List<Local>? locals = new List<Local>();
            MySqlConnection? mySqlCnn = null;
            MySqlDataReader? mySqlDataReader = null;

            try
            {
                mySqlCnn = new MySqlConnection(DAL.ConnectionString);
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "SELECT * FROM local";
                mySqlDataReader = mySqlCmd.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    locals.Add(CreateFromReader(mySqlDataReader));
                }
            }
            finally
            {
                mySqlDataReader?.Close();
                mySqlCnn?.Close();
            }

            return locals;
        }
    }
}
