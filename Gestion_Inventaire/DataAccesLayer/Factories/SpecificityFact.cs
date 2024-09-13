using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Gestion_Inventaire.Models;
using System.Windows.Navigation;

namespace Gestion_Inventaire.DataAccesLayer.Factories
{
    public class SpecificityFact
    {
        public Specificity CreateFromReader(MySqlDataReader reader)
        {
            int id = (int)reader["Id"];
            string description = (string)reader["Description"];
            int equipementId = (int)reader["equipment_id"]; 
            DAL dAL = new DAL();
            Equipement? equipement = dAL.EquipementFact.Get(equipementId);
            return new Specificity(id,description,equipement);
        }

        public void Create(string description, int equipmentID)
        {
            MySqlConnection? mySqlCnn = null;
            try
            {
                mySqlCnn = new MySqlConnection(DAL.ConnectionString);
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "INSERT INTO specificity (Description, equipment_id) VALUES (@description, @equipment_id);";
                mySqlCmd.Parameters.AddWithValue("@description", description);
                mySqlCmd.Parameters.AddWithValue("@equipment_id", equipmentID);

                mySqlCmd.ExecuteNonQuery();
            }
            finally
            {
                mySqlCnn?.Close();
            }
        }


        public List<Specificity?> GetAllForEquipment(int id)
        {

            MySqlConnection? mySqlCnn = null;
            MySqlDataReader? mySqlDataReader = null;
            List<Specificity> datas = new List<Specificity>();
            try
            {

                mySqlCnn = new MySqlConnection(DAL.ConnectionString);
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "SELECT * FROM specificity where equipment_id = @id";
                mySqlCmd.Parameters.AddWithValue("@id", id);
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

        public void Delete(int id)
        {
            MySqlConnection? mySqlCnn = null;
            MySqlDataReader? mySqlDataReader = null;

            try
            {
                mySqlCnn = new MySqlConnection(DAL.ConnectionString);
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "DELETE FROM specificity WHERE id = @id";
                mySqlCmd.Parameters.AddWithValue("@id", id);

                mySqlDataReader = mySqlCmd.ExecuteReader();

            }
            finally
            {
                mySqlDataReader?.Close();
                mySqlCnn?.Close();
            }
        }

        public void DeleteCauseEquipment(int id)
        {
            MySqlConnection? mySqlCnn = null;
            MySqlDataReader? mySqlDataReader = null;

            try
            {
                mySqlCnn = new MySqlConnection(DAL.ConnectionString);
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "DELETE FROM specificity WHERE equipment_id = @id";
                mySqlCmd.Parameters.AddWithValue("@id", id);

                mySqlDataReader = mySqlCmd.ExecuteReader();

            }
            finally
            {
                mySqlDataReader?.Close();
                mySqlCnn?.Close();
            }
        }
    }
}
