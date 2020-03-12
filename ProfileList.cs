using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace VisualZorgApp
{
    public class ProfileList
    {

        private List<Profile> profileList = new List<Profile>();
        private List<Role> roleList = new List<Role>();
        private DBConnection db = new DBConnection();
        public ProfileList()
        {
            
/*
            profiles.Add(new Profile { id = 1, name = "Hugh", surname = "Mungu", age = 96, weight = 68.71, length = 1.31, type = 1, username = "hugh", password = "mungu" });
            profiles.Add(new Profile { id = 2, name = "Jack", surname = "Mango", age = 56, weight = 78.23, length = 1.81, type = 2, username = "jack", password = "mango" });
            profiles.Add(new Profile { id = 3, name = "Phil", surname = "PorPo", age = 14, weight = 45.22, length = 2.11, type = 2, username = "phil", password = "porpo" });
*/
            /*SqlAllUsersToProfiles();*/

        }

        public bool SqlAllRolesToList()
        {
            roleList.Clear();
            using (MySqlCommand qry = ExecuteSql("SELECT * FROM role"))
            {
                try
                {
                    db.con.Open();
                    using (MySqlDataReader reader = qry.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            roleList.Add(new Role
                            (
                                (int)reader["id"],
                                (string)reader["name"]
                            ));

                        }
                    }

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
        public bool SqlDeleteProfile(int id)
        {
            using (MySqlCommand qry = ExecuteSql($"DELETE FROM `profile` WHERE `id`= {id}"))
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

            SqlAllProfilesToList();
            db.con.Close();
            return true;
        }
        public bool SqlUpdateProfile(int id, string name, string surname, int age, double weight, double length, int roleId)
        {
            using (MySqlCommand qry = ExecuteSql($"UPDATE profile SET name = '{name}',surname = '{surname}',age = '{age}', weight = '{weight}', length = '{length}', roleId = '{roleId}' WHERE id = {id}; "))
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

            SqlAllProfilesToList();
            db.con.Close();
            return true;
        }
        public bool SqlCreateProfile(string name, string surname, int age, double weight, double length, int roleId)
        {
            using (MySqlCommand qry = ExecuteSql($"INSERT INTO `profile` (`id`, `name`, `surname`, `age`, `weight`, `length`, `roleId`, `username`, `password`) VALUES (NULL, '{name}', '{surname}', '{age}', '{weight}', '{length}', '{roleId}', '', '');"))
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

            SqlAllProfilesToList();
            db.con.Close();
            return true;
        }
        public bool SqlAllProfilesToList()
        {
            profileList.Clear();
            using (MySqlCommand qry = ExecuteSql("SELECT * FROM profile"))
            {
                try
                {
                    db.con.Open();
                    using (MySqlDataReader reader = qry.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            profileList.Add(new Profile
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
                    }
                    
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
        public MySqlCommand ExecuteSql(string sql)
        {

            using (MySqlCommand cmd = new MySqlCommand(sql, db.con)) 
            { 
            return cmd;
            }

        }
        
        public void AddProfile(Profile profile)
        {
            profileList.Add(profile);
        }
        public List<Profile> GetProfileList()
        {
            return profileList;
        }
        public List<Role> GetRoleList()
        {
            return roleList;
        }


    }
}
