using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Gestion_Inventaire.Models;
using System.Windows.Controls.Primitives;

namespace Gestion_Inventaire.DataAccesLayer.Factories
{
    public class ScheduleFact
    {
        public Schedule CreateFromReader(MySqlDataReader reader)
        {
            int id = (int)reader["Id"];
            DateTime date = (DateTime)reader["date"];
            int localId = (int)reader["local_id"];
            DAL dal = new DAL();
            Local? local = dal.LocalFact.Get(localId);
            return new Schedule(id, date, local);
        }

        public Schedule Get(int id)
        {
            Schedule? schedule = null;
            MySqlConnection? mySqlCnn = null;
            MySqlDataReader? mySqlDataReader = null;

            try
            {
                mySqlCnn = new MySqlConnection(DAL.ConnectionString);
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "SELECT * FROM schedule WHERE id = @id";
                mySqlCmd.Parameters.AddWithValue("@id", id);

                mySqlDataReader = mySqlCmd.ExecuteReader();
                if (mySqlDataReader.Read())
                {
                    schedule = CreateFromReader(mySqlDataReader);
                }
            }
            finally
            {
                mySqlDataReader?.Close();
                mySqlCnn?.Close();
            }

            return schedule;
        }

        public void Create(DateTime date, int localId)
        {
            MySqlConnection? mySqlCnn = null;
            MySqlDataReader? mySqlDataReader = null;
            try
            {
                mySqlCnn = new MySqlConnection(DAL.ConnectionString);
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "INSERT INTO schedule (Date, local_id) VALUES (@date, @localId);";
                mySqlCmd.Parameters.AddWithValue("@date", date);
                mySqlCmd.Parameters.AddWithValue("@localId", localId);

                mySqlCmd.ExecuteNonQuery();
            }
            finally
            {
                mySqlDataReader?.Close();
                mySqlCnn?.Close();
            }
        }

        public int GetLastId()
        {
            int lastId = -1;

            try
            {
                using (MySqlConnection mySqlCnn = new MySqlConnection(DAL.ConnectionString))
                {
                    mySqlCnn.Open();

                    using (MySqlCommand mySqlCmd = mySqlCnn.CreateCommand())
                    {
                        mySqlCmd.CommandText = "SELECT Id FROM schedule ORDER BY Id DESC LIMIT 1;";

                        using (MySqlDataReader mySqlDataReader = mySqlCmd.ExecuteReader())
                        {
                            if (mySqlDataReader.Read())
                            {
                                lastId = (int)mySqlDataReader["Id"];
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Une erreur est survenue : {ex.Message}");
            }

            return lastId;
        }
    }
}
