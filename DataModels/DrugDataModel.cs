using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using VisualZorgApp.Handlers;

namespace VisualZorgApp.DataModels
{
    class DrugDataModel : DataModel
    {
        
        public List<Drug> GetAllDrugs()
        {
            List<Drug> drugs = new List<Drug>();
            using (MySqlCommand qry = GetDBConnection().ExecuteSql("SELECT * FROM drug"))
            {

                try
                {
                    if (GetDBConnection().con.State == ConnectionState.Closed)
                    {
                        GetDBConnection().con.Open();
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
                    GetDBConnection().con.Close();
                }
                catch (Exception e)
                {
                    SetErrorMsg(e.Message.ToString());
                }

            }
            return drugs;
        }
        public void CreateDrug(string name, string description, string type, string dosage)
        {
            using (MySqlCommand qry = GetDBConnection().ExecuteSql($"INSERT INTO `drug` (`id`, `name`, `description`, `type`, `dosage`) VALUES (NULL, '{name}', '{description}', '{type}', '{dosage}');"))
            {
                ExecNonQry(qry);
            }
        }
        public void UpdateDrug(int id, string name, string description, string type, string dosage)
        {
            using (MySqlCommand qry = GetDBConnection().ExecuteSql($"UPDATE `drug` SET name = '{name}',description = '{description}',type = '{type}', dosage = '{dosage}' WHERE id = {id}; "))
            {
                ExecNonQry(qry);
            }
        }
        public void DeleteDrug(int id)
        {
            using (MySqlCommand qry = GetDBConnection().ExecuteSql($"DELETE FROM `drug` WHERE `id`= {id}"))
            {
                ExecNonQry(qry);
            }
        }
    }

   
}
