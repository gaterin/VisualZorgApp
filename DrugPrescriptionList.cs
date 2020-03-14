using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace VisualZorgApp
{
    class DrugPrescriptionList
    {
        private List<DrugPrescription> drugPrescriptionList = new List<DrugPrescription>();
        private DBConnection db = new DBConnection();

        public bool SqlAllDrugsToList()
        {
            drugPrescriptionList.Clear();
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

                            AddDrugPrescription(new DrugPrescription
                            (
                                (string)reader["id"],
                                (string)reader["name"],
                                (string)reader["description"],
                                (string)reader["type"]
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
        public void AddDrugPrescription(DrugPrescription drugPrescription)
        {
            drugPrescriptionList.Add(drugPrescription);
        }

        public List<DrugPrescription> GetDrugPrescriptionList()
        {
            return drugPrescriptionList;
        }
    }
    

}
