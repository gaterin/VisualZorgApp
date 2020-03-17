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
        public int selectedRowDrugId;
        public int selectedRowProfileId;
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
        public bool SqlCreateDrugPrescription(int profileId, int drugId, string intakeTime, string startDate, string endDate)
        {

            using (MySqlCommand qry = db.ExecuteSql($"INSERT INTO `drugprescription` (`profileId`, `drugId`, `intakeTime`, `startDate`, `endDate`) VALUES ('{profileId}', '{drugId}', '{intakeTime}', '{startDate}', '{endDate}');"))
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

            SqlAllDrugPrescriptionsToList();
            db.con.Close();
            return true;
        }
        public bool SqlUpdateDrugPrescription(int profileId, int drugId, string intakeTime, string startDate, string endDate)
        {
            using (MySqlCommand qry = db.ExecuteSql($"UPDATE `drugprescription` SET profileId = '{profileId}',drugId = '{drugId}',intakeTime = '{intakeTime}', startDate = '{startDate}',endDate = '{endDate}'  WHERE `drugprescription`.profileId = '{selectedRowProfileId}' AND `drugprescription`.drugId = '{selectedRowDrugId}'; "))
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

            SqlAllDrugPrescriptionsToList();
            db.con.Close();
            return true;
        }
        public bool SqlDeleteDrugPrescription(int profileId, int drugId)
        {
            using (MySqlCommand qry = db.ExecuteSql($"DELETE FROM `drugprescription` WHERE profileId = {profileId} AND drugId = {drugId} ;"))
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

            SqlAllDrugPrescriptionsToList();
            db.con.Close();
            return true;
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
