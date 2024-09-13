using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Gestion_Inventaire.Models;

namespace Gestion_Inventaire.DataAccesLayer.Factories
{
    public class CourseFact
    {
        public Course CreateFromReader(MySqlDataReader reader)
        {
            int id = (int)reader["Id"];
            string name = (string)reader["Name"];
            int schedule_id = (int)reader["schedule_id"];
            int teacher_id = (int)reader["teacher_id"];
            DAL dal = new DAL();
            Schedule? schedule = dal.ScheduleFact.Get(schedule_id);
            Teacher? teacher = dal.TeacherFact.Get(teacher_id);
            
            return new Course(id, name , schedule , teacher);
        }


        public List<Course>? GetAll()
        {
            List<Course>? courses = new List<Course>();
            MySqlConnection? mySqlCnn = null;
            MySqlDataReader? mySqlDataReader = null;

            try
            {
                mySqlCnn = new MySqlConnection(DAL.ConnectionString);
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "SELECT * FROM course";
                mySqlDataReader = mySqlCmd.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    courses.Add(CreateFromReader(mySqlDataReader));
                }
            }
            finally
            {
                mySqlDataReader?.Close();
                mySqlCnn?.Close();
            }

            return courses;
        }

        public void Delete(int id)
        {
            MySqlConnection? mySqlCnn = null;
            MySqlDataReader? mySqlDataReader = null;

            try
            {
                mySqlCnn = new MySqlConnection(DAL.ConnectionString);
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "DELETE FROM course WHERE id = @id";
                mySqlCmd.Parameters.AddWithValue("@id", id);

                mySqlDataReader = mySqlCmd.ExecuteReader();

            }
            finally
            {
                mySqlDataReader?.Close();
                mySqlCnn?.Close();
            }
        }

        public void Create(string name, int teacherId, int scheduleID)
        {
            MySqlConnection? mySqlCnn = null;
            try
            {
                mySqlCnn = new MySqlConnection(DAL.ConnectionString);
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "INSERT INTO course (Name, schedule_id, teacher_id) VALUES (@name, @schedule_id, @teacher_id);";
                mySqlCmd.Parameters.AddWithValue("@name", name);
                mySqlCmd.Parameters.AddWithValue("@schedule_id", scheduleID);
                mySqlCmd.Parameters.AddWithValue("@teacher_id", teacherId);
                mySqlCmd.ExecuteNonQuery();
            }
            finally
            {
                mySqlCnn?.Close();
            }
        }

    }
}
