using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace VisualZorgApp
{
    class ProfileDataModel
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
        public List<Profile> GetAllProfiles()
        {
            List<Profile> profiles = new List<Profile>();

            using (MySqlCommand qry = db.ExecuteSql("SELECT * FROM profile"))
            {

                try
                {
                    db.con.Open();
                    using (MySqlDataReader reader = qry.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            profiles.Add(new Profile
                            (
                                (int)reader["id"],
                                (string)reader["name"],
                                (string)reader["surname"],
                                (int)reader["age"],
                                (double)reader["weight"],
                                (double)reader["length"],
                                (int)reader["roleId"]
                            ));

                        }
                        db.con.Close();
                    }

                }
                catch (Exception e)
                {
                    errorMsg = e.Message.ToString();
                }


            }

            return profiles;
        }

        public List<Role> GetAllRoles()
        {
            List<Role> roles = new List<Role>();

            using (MySqlCommand qry = db.ExecuteSql("SELECT * FROM role"))
            {
                try
                {
                    db.con.Open();
                    using (MySqlDataReader reader = qry.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            roles.Add(new Role
                            (
                                (int)reader["id"],
                                (string)reader["name"]
                            ));

                        }
                        db.con.Close();
                    }

                }
                catch (Exception e)
                {
                    errorMsg = e.Message.ToString();
                }


            }

            return roles;
        }

        public void CreateProfile(string name, string surname, int age, double weight, double length, int roleId)
        {
            using (MySqlCommand qry = db.ExecuteSql($"INSERT INTO `profile` (`id`, `name`, `surname`, `age`, `weight`, `length`, `roleId`, `username`, `password`) VALUES (NULL, '{name}', '{surname}', '{age}', '{weight}', '{length}', '{roleId}', '', '');"))
            {
                ExecNonQry(qry);
            }
        }

        public void UpdateProfile(int id, string name, string surname, int age, double weight, double length, int roleId)
        {
            using (MySqlCommand qry = db.ExecuteSql($"UPDATE profile SET name = '{name}',surname = '{surname}',age = '{age}', weight = '{weight}', length = '{length}', roleId = '{roleId}' WHERE id = {id}; "))
            {
                ExecNonQry(qry);
            }
        }

        public void DeleteProfile(int id)
        {
            using (MySqlCommand qry = db.ExecuteSql($"DELETE FROM `profile` WHERE `id`= {id}"))
            {
                ExecNonQry(qry);
            }
        }
    }
}
