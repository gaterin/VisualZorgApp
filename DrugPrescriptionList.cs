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

        public bool SqlAllDrugPrescriptionsToList()
        {
            drugPrescriptionList.Clear();
            using (MySqlCommand qry = db.ExecuteSql("SELECT intakeTime,startDate,endDate, profile.id AS profile_id , profile.name AS profile_name, drug.id AS drug_id, drug.name AS drug_name FROM drugprescription JOIN profile ON profileId = profile.id JOIN drug ON drugId = drug.id"))
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
                                (int)reader["drug_id"],
                                (int)reader["profile_id"],
                                reader["drug_name"].ToString(),
                                reader["profile_name"].ToString(),
                                reader["intakeTime"].ToString(),
                                reader["startDate"].ToString(),
                                reader["endDate"].ToString()
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
