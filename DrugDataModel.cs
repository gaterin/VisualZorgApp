using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace VisualZorgApp
{
    class DrugDataModel
    {
        private DBConnection db = new DBConnection();
        private string errorMsg;

        public void ExecNonQry(MySqlCommand qry)
        {
            try
            {
                db.con.Open();
                qry.ExecuteNonQuery();
                db.con.Close();
            }
            catch (Exception e)
            {
                errorMsg = e.Message.ToString();
            }
        }

        public List<Drug> GetAllDrugs()
        {
            List<Drug> drugs = new List<Drug>();
            using (MySqlCommand qry = db.ExecuteSql("SELECT * FROM drug"))
            {

                try
                {
                    if (db.con.State == ConnectionState.Closed)
                    {
                        db.con.Open();
                    }

                    using (MySqlDataReader reader = qry.ExecuteReader())
                    {

                        while (reader.Read())
                        {

                            drugs.Add(new Drug
                            (
                                (int)reader["id"],
                                (string)reader["name"],
                                (string)reader["description"],
                                (string)reader["type"],
                                (string)reader["dosage"]
                                )
                            );


                        }
                    }
                    db.con.Close();
                }
                catch (Exception e)
                {
                    errorMsg = e.Message.ToString();
                }

            }
            return drugs;
        }
        public void CreateDrug(string name, string description, string type, string dosage)
        {
            using (MySqlCommand qry = db.ExecuteSql($"INSERT INTO `drug` (`id`, `name`, `description`, `type`, `dosage`) VALUES (NULL, '{name}', '{description}', '{type}', '{dosage}');"))
            {
                ExecNonQry(qry);
            }
        }
        public void UpdateDrug(int id, string name, string description, string type, string dosage)
        {
            using (MySqlCommand qry = db.ExecuteSql($"UPDATE `drug` SET name = '{name}',description = '{description}',type = '{type}', dosage = '{dosage}' WHERE id = {id}; "))
            {
                ExecNonQry(qry);
            }
        }
        public void DeleteDrug(int id)
        {
            using (MySqlCommand qry = db.ExecuteSql($"DELETE FROM `drug` WHERE `id`= {id}"))
            {
                ExecNonQry(qry);
            }
        }
    }

   
}
