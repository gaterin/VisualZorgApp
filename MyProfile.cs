using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace VisualZorgApp
{
   
    class MyProfile : Profile
    {
        private int id;
        private string username;
        private string password;
        private string roleName;

        private int selectedRowWeightRegistrationId;

        private DBConnection db = new DBConnection();
        private List<DrugPrescription> prescribedDrugs = new List<DrugPrescription>();
        private List<WeightRegistration> registeredWeights = new List<WeightRegistration>();
        private List<string> prescribedDrugsToNotify = new List<string>();

        public MyProfile(int id)
        {
            SetId(id);
            FetchProfileById(id);
            FetchPrescribedDrugsForMyProfile(id);
            FetchRegisteredWeightsForMyProfile(id);
            SetPrescribedDrugsToNotify();
        }
        
        public List<WeightRegistration> GetWeightRegistrations()
        {
            return this.registeredWeights;
        }
        public bool SqlCreateWeightRegistration(string date, string time, double weight)
        {

            using (MySqlCommand qry = db.ExecuteSql($"INSERT INTO `weightregistration` (`id`,`profileId`, `date`, `time`, `weight`) VALUES ( null, '{this.id}', '{date}', '{time}', '{weight}');"))
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

           
            db.con.Close();
            return true;
        }
        public bool SqlDeleteWeightRegistration()
        {

            using (MySqlCommand qry = db.ExecuteSql($"DELETE FROM `weightregistration` WHERE profileId = '{id}' AND id = '{selectedRowWeightRegistrationId}'; "))
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


            db.con.Close();
            return true;
        }
        public bool SqlUpdateWeightRegistration(string date, string time, double weight)
        {

            using (MySqlCommand qry = db.ExecuteSql($"UPDATE `weightregistration` SET date = '{date}', time = '{time}',weight = '{weight}'  WHERE profileId = '{id}' AND id = '{selectedRowWeightRegistrationId}';"))
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


            db.con.Close();
            return true;
        }
        public bool FetchRegisteredWeightsForMyProfile(int id)
        {
            registeredWeights.Clear();
            using (MySqlCommand qry = db.ExecuteSql($"SELECT id, date, time, weight FROM weightregistration WHERE profileId = {id}"))
            {
            
                try
                {
                    db.con.Open();
                    using (MySqlDataReader reader = qry.ExecuteReader())
                    {

                        while (reader.Read())
                        {

                            AddRegisteredWeight
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

        public void AddRegisteredWeight(WeightRegistration weightRegistration)
        {
            registeredWeights.Add(weightRegistration);
        }
        public List<string> GetPrescribedDrugsToNotify()
        {
            return prescribedDrugsToNotify;
        }
        public void SetPrescribedDrugsToNotify()
        {
            int hoursBeforeIntake = 1;

            foreach (var item in prescribedDrugs)
            {
                if (item.GetDrugStartDate().Date <= DateTime.Today &&
                    item.GetDrugEndDate().Date >= DateTime.Today &&
                    item.GetDrugIntakeTime().Hour <= item.GetDrugIntakeTime().Hour + hoursBeforeIntake)
                {
                    prescribedDrugsToNotify.Add(item.GetDrugName().ToString());
                }
            }
        }
        public List<DrugPrescription> GetPrescribedDrugs()
        {
            return prescribedDrugs;
        }
        public void AddPrescribedDrug(DrugPrescription prescribedDrug)
        {
            prescribedDrugs.Add(prescribedDrug);
        }
        public bool FetchProfileById(int id)
        {

            using (MySqlCommand qry = db.ExecuteSql($"SELECT *, role.id AS role_id ,role.name AS role_name FROM profile JOIN role ON profile.roleId = role.id  WHERE profile.id = {id}"))
            {

                try
                {
                    db.con.Open();
                    using (MySqlDataReader reader = qry.ExecuteReader())
                    {
                        reader.Read();
                        SetId((int)reader["id"]);
                        SetName((string)reader["name"]);
                        SetSurname((string)reader["surname"]);
                        SetAge((int)reader["age"]);
                        SetWeight((double)reader["weight"]);
                        SetLength((double)reader["length"]);
                        SetRoleId((int)reader["role_id"]);
                        SetRoleName((string)reader["role_name"]);
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
        public void SetSelectedRowWeightRegistrationId(int selectedRowWeightRegistrationId)
        {
            this.selectedRowWeightRegistrationId = selectedRowWeightRegistrationId;
        }
        public int GetSelectedRowWeightRegistrationId()
        {
            return selectedRowWeightRegistrationId;
        }
        public void SetId(int id)
        {
            this.id = id;
        }
        public int GetId()
        {
            return id;
        }
        public void SetRoleName(string roleName)
        {
            this.roleName = roleName;
        }
        public string GetRoleName()
        {
            return roleName;
        }
        public string GetUsername()
        {
            return username;
        }
        private void SetUsername(string username)
        {
            this.username = username;
        }
        private void SetPassword(string password)
        {
            this.password = password;
        }


        public bool FetchPrescribedDrugsForMyProfile(int id)
        {
            using (MySqlCommand qry = db. ExecuteSql($"SELECT startDate, endDate, intakeTime, name FROM drugprescription JOIN drug ON drugprescription.drugId = drug.id WHERE profileId = {id}"))
            {

                try
                {
                    db.con.Open();
                    using (MySqlDataReader reader = qry.ExecuteReader())
                    {

                        while (reader.Read())
                        {

                            AddPrescribedDrug
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
        public bool CheckUserPass(string username, string password)
        {
            if (this.username == username && this.password == password)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
