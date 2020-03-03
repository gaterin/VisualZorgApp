using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace VisualZorgApp
{
    class DrugList
    {
        private List<Drug> drugList = new List<Drug>();
        private DBConnection db = new DBConnection();
        public bool SqlAllDrugsToList()
        {
            using (MySqlCommand qry = ExecuteSql("SELECT * FROM drug"))
            {

                try
                {
                    db.con.Open();
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
                    return true;
                }
                catch (Exception e)
                {
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

            MySqlCommand cmd = new MySqlCommand(sql, db.con);
            return cmd;
        }
    }

}
