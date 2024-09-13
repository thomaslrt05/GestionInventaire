using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Gestion_Inventaire.Models;

namespace Gestion_Inventaire.DataAccesLayer.Factories
{
    public class MarkFact
    {
        public Mark CreateFromReader(MySqlDataReader reader)
        {
            int id = (int)reader["id"];
            string name = (string)reader["name"] ?? string.Empty;
            return new Mark(id,name);
        }

        public Mark? Get(int id)
        {
            Mark? mark = null;
            MySqlConnection? mySqlCnn = null;
            MySqlDataReader? mySqlDataReader = null;

            try
            {
                mySqlCnn = new MySqlConnection(DAL.ConnectionString);
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "SELECT * FROM mark WHERE id = @id";
                mySqlCmd.Parameters.AddWithValue("@id", id);

                mySqlDataReader = mySqlCmd.ExecuteReader();
                if (mySqlDataReader.Read())
                {
                    mark = CreateFromReader(mySqlDataReader);
                }
            }
            finally
            {
                mySqlDataReader?.Close();
                mySqlCnn?.Close();
            }

            return mark;
        }

        public List<Mark?> GetAll()
        {

            MySqlConnection? mySqlCnn = null;
            MySqlDataReader? mySqlDataReader = null;
            List<Mark> datas = new List<Mark>();
            try
            {

                mySqlCnn = new MySqlConnection(DAL.ConnectionString);
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "SELECT * FROM mark";

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
