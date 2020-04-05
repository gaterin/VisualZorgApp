using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using VisualZorgApp.Handlers;


namespace VisualZorgApp.DataModels
{
    // Child class used as datamodel for MyProfile class
    // Read single Profile based on id (same id as Read DrugPrescription)
    // Read DrugPrescription based on id (same id as Read Profile)
    // [C]reate WeightRegistration query 
    // [R]ead all WeightRegistrations query as ListObject of WeightRegistration
    // [U]pdate WeightRegistration query
    // [D]elete WeightRegistration query
    class MyProfileDataModel : DataModel
    {
        public string[] GetProfile(int id)
        {
           
            string[] profile = {"0", "0", "0", "0", "0", "0", "0", "0" };

            using (MySqlCommand qry = GetDBConnection().ExecuteSql($"SELECT *, role.id AS role_id ,role.name AS role_name FROM profile JOIN role ON profile.roleId = role.id  WHERE profile.id = {id}"))
            {

                try
                {
                   GetDBConnection().con.Open();
                    using (MySqlDataReader reader = qry.ExecuteReader())
                    {
                        reader.Read();
                        profile[0]= reader["id"].ToString();
                        profile[1] = reader["name"].ToString();
                        profile[2] = reader["surname"].ToString();
                        profile[3] = reader["age"].ToString();
                        profile[4] = reader["weight"].ToString();
                        profile[5] = reader["length"].ToString();
                        profile[6] = reader["role_id"].ToString();
                        profile[7] = reader["role_name"].ToString();
                    }

                    GetDBConnection().con.Close();
                }
                catch (Exception e)
                {
                    SetErrorMsg(e.Message.ToString());
                }

            }

            return profile;
        }

        public List<WeightRegistration> GetAllWeightRegistrations(int id)
        {
            List<WeightRegistration> weightRegistrations = new List<WeightRegistration>();
            using (MySqlCommand qry = GetDBConnection().ExecuteSql($"SELECT id, date, time, weight FROM weightregistration WHERE profileId = {id}"))
            {

                try
                {
                    GetDBConnection().con.Open();
                    using (MySqlDataReader reader = qry.ExecuteReader())
                    {

                        while (reader.Read())
                        {

                            weightRegistrations.Add
                            (
                                new WeightRegistration(
                                    (int)reader["id"],
                                    reader["date"].ToString(),
                                    reader["time"].ToString(),
                                    (double)reader["weight"]
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
            return weightRegistrations;
        }

        public List<DrugPrescription> GetAllDrugPrescriptions(int id)
        {
            List<DrugPrescription> drugPrescriptions = new List<DrugPrescription>();

            using (MySqlCommand qry = GetDBConnection().ExecuteSql($"SELECT startDate, endDate, intakeTime, name FROM drugprescription JOIN drug ON drugprescription.drugId = drug.id WHERE profileId = {id}"))
            {

                try
                {
                    GetDBConnection().con.Open();
                    using (MySqlDataReader reader = qry.ExecuteReader())
                    {

                        while (reader.Read())
                        {

                            drugPrescriptions.Add
                             (
                                new DrugPrescription(
                                reader["name"].ToString(),
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
                    SetErrorMsg(e.Message.ToString());
                }

            }

            return drugPrescriptions;
        }
        public void UpdateWeightRegistration(string date, string time, double weight, int id, int selectedRowWeightRegistrationId)
        {
            using (MySqlCommand qry = GetDBConnection().ExecuteSql($"UPDATE `weightregistration` SET date = '{date}', time = '{time}',weight = '{weight}'  WHERE profileId = '{id}' AND id = '{selectedRowWeightRegistrationId}';"))
            {
                ExecNonQry(qry);
            }
        }

        public void CreateWeightRegistration(string date, string time, double weight,int id)
        {
            using (MySqlCommand qry = GetDBConnection().ExecuteSql($"INSERT INTO `weightregistration` (`id`,`profileId`, `date`, `time`, `weight`) VALUES ( null, '{id}', '{date}', '{time}', '{weight}');"))
            {
                ExecNonQry(qry);
            }
        }

        public void DeleteWeightRegistration(int id,int selectedRowWeightRegistrationId)
        {
            using (MySqlCommand qry = GetDBConnection().ExecuteSql($"DELETE FROM `weightregistration` WHERE profileId = '{id}' AND id = '{selectedRowWeightRegistrationId}'; "))
            {
                ExecNonQry(qry);
            }
        }
    }
}
