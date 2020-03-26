using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace VisualZorgApp
{
    class DrugPrescriptionDataModel
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

        public List<DrugPrescription> GetAllDrugPrescriptions()
        {
            List<DrugPrescription> drugPrescriptions = new List<DrugPrescription>();
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
                            drugPrescriptions.Add(new DrugPrescription
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
                   
                }
                catch (Exception e)
                {
                    string errorMsg = e.Message.ToString();
                }

            }
            return drugPrescriptions;
        }

        public void CreateDrugPrescription(int profileId, int drugId, string intakeTime, string startDate, string endDate)
        {
            using (MySqlCommand qry = db.ExecuteSql($"INSERT INTO `drugprescription` (`profileId`, `drugId`, `intakeTime`, `startDate`, `endDate`) VALUES ('{profileId}', '{drugId}', '{intakeTime}', '{startDate}', '{endDate}');"))
            {
                ExecNonQry(qry);
            }
        }
        public void UpdateDrugPrescription(int profileId, int drugId, string intakeTime, string startDate, string endDate, int selectedRowDrugId, int selectedRowProfileId)
        {
            using (MySqlCommand qry = db.ExecuteSql($"UPDATE `drugprescription` SET profileId = '{profileId}',drugId = '{drugId}',intakeTime = '{intakeTime}', startDate = '{startDate}',endDate = '{endDate}'  WHERE `drugprescription`.profileId = '{selectedRowProfileId}' AND `drugprescription`.drugId = '{selectedRowDrugId}'; "))
            {
                ExecNonQry(qry);
            }
        }
        public void DeleteDrugPrescription(int profileId, int drugId)
        {
            using (MySqlCommand qry = db.ExecuteSql($"DELETE FROM `drugprescription` WHERE profileId = {profileId} AND drugId = {drugId} ;"))
            {
                ExecNonQry(qry);
            }
        }
    }
}
