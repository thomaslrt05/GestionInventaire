using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Gestion_Inventaire.Models;

namespace Gestion_Inventaire.DataAccesLayer.Factories
{
    public class TeacherFact
    {
        public Teacher CreateFromReader(MySqlDataReader reader)
        {
            int id = (int)reader["Id"];
            string name = (string)reader["Name"];
            string mail = (string)reader["Mail"];
            return new Teacher(id, name, mail);
        }

        public Teacher Get(int id)
        {
            Teacher? teacher = null;
            MySqlConnection? mySqlCnn = null;
            MySqlDataReader? mySqlDataReader = null;

            try
            {
                mySqlCnn = new MySqlConnection(DAL.ConnectionString);
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "SELECT * FROM teacher WHERE id = @id";
                mySqlCmd.Parameters.AddWithValue("@id", id);

                mySqlDataReader = mySqlCmd.ExecuteReader();
                if (mySqlDataReader.Read())
                {
                    teacher = CreateFromReader(mySqlDataReader);
                }
            }
            finally
            {
                mySqlDataReader?.Close();
                mySqlCnn?.Close();
            }
            return teacher;
        }

        public List<Teacher>? GetAll()
        {
            List<Teacher>? teachers = new List<Teacher>();
            MySqlConnection? mySqlCnn = null;
            MySqlDataReader? mySqlDataReader = null;

            try
            {
                mySqlCnn = new MySqlConnection(DAL.ConnectionString);
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "SELECT * FROM teacher";
                mySqlDataReader = mySqlCmd.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    teachers.Add(CreateFromReader(mySqlDataReader));
                }
            }
            finally
            {
                mySqlDataReader?.Close();
                mySqlCnn?.Close();
            }

            return teachers;
        }
    }
}
