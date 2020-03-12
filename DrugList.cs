using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;
namespace VisualZorgApp
{
    class DrugList
    {
        private List<Drug> drugList = new List<Drug>();
        private DBConnection db = new DBConnection();
        public bool SqlDeleteDrug(int id)
        {
            using (MySqlCommand qry = ExecuteSql($"DELETE FROM `drug` WHERE `id`= {id}"))
            {
                try
                {
                    db.con.Open();
                    qry.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    string errorMsg = e.Message.ToString();
                    return false;
                }


            }

            SqlAllDrugsToList();
            db.con.Close();
            return true;
        }
        public bool SqlUpdateDrug(int id, string name, string description, string type, string dosage)
        {
            using (MySqlCommand qry = ExecuteSql($"UPDATE `drug` SET name = '{name}',description = '{description}',type = '{type}', dosage = '{dosage}' WHERE id = {id}; "))
            {
                try
                {
                    db.con.Open();
                    qry.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    string errorMsg = e.Message.ToString();
                    return false;
                }


            }

            SqlAllDrugsToList();
            db.con.Close();
            return true;
        }
        public bool SqlCreateDrug(string name, string description, string type, string dosage)
        {
            using (MySqlCommand qry = ExecuteSql($"INSERT INTO `drug` (`id`, `name`, `description`, `type`, `dosage`) VALUES (NULL, '{name}', '{description}', '{type}', '{dosage}');"))
            {
                try
                {

                    if (db.con.State == ConnectionState.Closed)
                    {
                        db.con.Open();
                    }
                    qry.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    string errorMsg = e.Message.ToString();
                    return false;
                }


            }

            SqlAllDrugsToList();
            db.con.Close();
            return true;
        }
        public bool SqlAllDrugsToList()
        {
            drugList.Clear();
            using (MySqlCommand qry = ExecuteSql("SELECT * FROM drug"))
            {

                try
                {
                    if(db.con.State == ConnectionState.Closed)
                    {
                        db.con.Open();
                    }
                    
                    using (MySqlDataReader reader = qry.ExecuteReader())
                    {



                        while (reader.Read())
                        {

                            AddDrug(new Drug
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
                    return true;
                }
                catch (Exception e)
                {
                    string errorMsg = e.Message.ToString();
                    return false;
                }

            }

        }
        public List<Drug> GetDrugList()
        {
            return drugList;
        }
        public void AddDrug(Drug drug)
        {
            drugList.Add(drug);
        }
        public MySqlCommand ExecuteSql(string sql)
        {

            using (MySqlCommand cmd = new MySqlCommand(sql, db.con))
            {
                return cmd;
            }
        }
    }

}
