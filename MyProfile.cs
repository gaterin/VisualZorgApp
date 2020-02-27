using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace VisualZorgApp
{
   
    class MyProfile : Profile
    {
       
        private DBConnection db = new DBConnection();
        public string roleName;
        public List<DrugPrescription> prescribedDrugs = new List<DrugPrescription>();
        public MyProfile(int id)
        {
            FetchProfileById(id);
            FetchPrescribedDrugsForMyProfile(id);
        }


        public bool FetchProfileById(int id)
        {
            using (MySqlCommand qry = ExecuteSql($"SELECT *, role.id AS role_id ,role.name AS role_name FROM profile JOIN role ON profile.roleId = role.id  WHERE profile.id = { id}"))
            {

                try
                {
                    db.con.Open();
                    using (MySqlDataReader reader = qry.ExecuteReader())
                    {
                        reader.Read();
                        this.id = (int)reader["id"];
                        name = (string)reader["name"];
                        surname = (string)reader["surname"];
                        age = (int)reader["age"];
                        weight = (double)reader["weight"];
                        length = (double)reader["length"];
                        roleId = (int)reader["role_id"];
                        roleName = (string)reader["role_name"];

                    }
                    db.con.Close();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }

            }
        }
        public bool FetchPrescribedDrugsForMyProfile(int id)
        {
            using (MySqlCommand qry = ExecuteSql($"SELECT startDate, endDate, intakeTime, name FROM drugprescription JOIN drug ON drugprescription.drugId = drug.id WHERE profileId = {id}"))
            {

                try
                {
                    db.con.Open();
                    using (MySqlDataReader reader = qry.ExecuteReader())
                    {

                        while (reader.Read())
                        {

                            prescribedDrugs.Add(new DrugPrescription
                             {

                                drugName = reader["name"].ToString(),
                                drugIntakeTime = reader["intakeTime"].ToString(),
                                drugStartDate = reader["startDate"].ToString(),
                                drugEndDate = reader["endDate"].ToString()

                            });

                        }
                    }
                    db.con.Close();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }

            }

        }
        public MySqlCommand ExecuteSql(string sql)
        {

            MySqlCommand cmd = new MySqlCommand(sql, db.con);
            return cmd;
        }
    }
}
