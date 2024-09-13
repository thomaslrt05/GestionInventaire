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
    public class EquipementFactory
    {
       public Equipement CreateFromReader(MySqlDataReader reader)
        {
            int id = (int)reader["Id"];
            string? description = reader["Description"].ToString() ?? string.Empty;
            int typeId = (int)reader["type_id"];
            int markId = (int)reader["mark_id"];
            DAL dal = new DAL();
            Type? type = dal.TypeFact.Get(typeId);
            Mark? mark = dal.MarkFact.Get(markId);
            return new Equipement(id, description, type, mark);
       }

        public Equipement? Get(int equipementId)
        {
            Equipement? equipement = null;
            MySqlConnection? mySqlCnn = null;
            MySqlDataReader? mySqlDataReader = null;

            try
            {
                mySqlCnn = new MySqlConnection(DAL.ConnectionString);
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "SELECT * FROM equipment WHERE id = @id";
                mySqlCmd.Parameters.AddWithValue("@id", equipementId);

                mySqlDataReader = mySqlCmd.ExecuteReader();
                if (mySqlDataReader.Read())
                {
                    equipement = CreateFromReader(mySqlDataReader);
                }
            }
            finally
            {
                mySqlDataReader?.Close();
                mySqlCnn?.Close();
            }

            return equipement;
        }

        public List<Equipement?> GetAll()
        {
           
            MySqlConnection? mySqlCnn = null;
            MySqlDataReader? mySqlDataReader = null;
            List<Equipement> datas = new List<Equipement>();
            try
            {
                
                mySqlCnn = new MySqlConnection(DAL.ConnectionString);
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "SELECT * FROM equipment";

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

        public void Save(Equipement equipement)
        {
            MySqlConnection? mySqlCnn = null;
            try
            {
                mySqlCnn = new MySqlConnection(DAL.ConnectionString);
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();

                if (equipement.Id == 0)
                {
                    mySqlCmd.CommandText = "INSERT INTO equipment(description,mark_id,type_id) " +
                                           "VALUES (@description, @type, @mark)";
                }
                else
                {
                    mySqlCmd.CommandText = "UPDATE equipment " +
                                           "SET description = @description, type_id = @type, mark_id = @mark " +
                                           "WHERE Id = @id";

                    mySqlCmd.Parameters.AddWithValue("@Id", equipement.Id);
                }

                mySqlCmd.Parameters.AddWithValue("@description", equipement.Description);
                mySqlCmd.Parameters.AddWithValue("@type", equipement.Type.Id);
                mySqlCmd.Parameters.AddWithValue("@mark", equipement.Mark.Id);

                mySqlCmd.ExecuteNonQuery();

                if (equipement.Id == 0)
                {
                    equipement.Id = (int)mySqlCmd.LastInsertedId;
                }
            }
            finally
            {
                mySqlCnn?.Close();
            }
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
                mySqlCmd.CommandText = "DELETE FROM equipment WHERE id = @id";
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
