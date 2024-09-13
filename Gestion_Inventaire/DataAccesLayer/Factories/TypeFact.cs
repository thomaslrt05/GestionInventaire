using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Gestion_Inventaire.Models;
using Type = Gestion_Inventaire.Models.Type;


namespace Gestion_Inventaire.DataAccesLayer.Factories
{
    public class TypeFact
    {
        public Type CreateFromReader(MySqlDataReader reader)
        {
            int id = (int)reader["Id"];
            string name = reader["Name"].ToString() ?? string.Empty;
            return new Type(id, name);
        }

        public Type Get(int id)
        {
            Type? type = null;
            MySqlConnection? mySqlCnn = null;
            MySqlDataReader? mySqlDataReader = null;

            try
            {
                mySqlCnn = new MySqlConnection(DAL.ConnectionString);
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "SELECT * FROM type WHERE id = @id";
                mySqlCmd.Parameters.AddWithValue("@id", id);

                mySqlDataReader = mySqlCmd.ExecuteReader();
                if (mySqlDataReader.Read())
                {
                    type = CreateFromReader(mySqlDataReader);
                }
            }
            finally
            {
                mySqlDataReader?.Close();
                mySqlCnn?.Close();
            }

            return type;
        }

        public List<Type?> GetAll()
        {

            MySqlConnection? mySqlCnn = null;
            MySqlDataReader? mySqlDataReader = null;
            List<Type> datas = new List<Type>();
            try
            {

                mySqlCnn = new MySqlConnection(DAL.ConnectionString);
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "SELECT * FROM type";

                mySqlDataReader = mySqlCmd.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    datas.Add(CreateFromReader(mySqlDataReader));
                }
            }
            finally
            {
                mySqlDataReader?.Close();
                mySqlCnn?.Close();
            }

            return datas;
        }
    }
}
