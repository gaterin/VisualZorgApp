using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using VisualZorgApp.Handlers;
namespace VisualZorgApp.DataModels
{
    class DrugPrescriptionDataModel : DataModel
    {
        public List<DrugPrescription> GetAllDrugPrescriptions()
        {
            List<DrugPrescription> drugPrescriptions = new List<DrugPrescription>();
            using (MySqlCommand qry = GetDBConnection().ExecuteSql("SELECT intakeTime,startDate,endDate, profile.id AS profile_id , profile.name AS profile_name, drug.id AS drug_id, drug.name AS drug_name FROM drugprescription JOIN profile ON profileId = profile.id JOIN drug ON drugId = drug.id"))
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
                    GetDBConnection().con.Close();
                   
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
            using (MySqlCommand qry = GetDBConnection().ExecuteSql($"INSERT INTO `drugprescription` (`profileId`, `drugId`, `intakeTime`, `startDate`, `endDate`) VALUES ('{profileId}', '{drugId}', '{intakeTime}', '{startDate}', '{endDate}');"))
            {
                ExecNonQry(qry);
            }
        }
        public void UpdateDrugPrescription(int profileId, int drugId, string intakeTime, string startDate, string endDate, int selectedRowDrugId, int selectedRowProfileId)
        {
            using (MySqlCommand qry = GetDBConnection().ExecuteSql($"UPDATE `drugprescription` SET profileId = '{profileId}',drugId = '{drugId}',intakeTime = '{intakeTime}', startDate = '{startDate}',endDate = '{endDate}'  WHERE `drugprescription`.profileId = '{selectedRowProfileId}' AND `drugprescription`.drugId = '{selectedRowDrugId}'; "))
            {
                ExecNonQry(qry);
            }
        }
        public void DeleteDrugPrescription(int profileId, int drugId)
        {
            using (MySqlCommand qry = GetDBConnection().ExecuteSql($"DELETE FROM `drugprescription` WHERE profileId = {profileId} AND drugId = {drugId} ;"))
            {
                ExecNonQry(qry);
            }
        }
    }
}
