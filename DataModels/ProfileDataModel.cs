using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using VisualZorgApp.Handlers;

namespace VisualZorgApp.DataModels
{
    // Child class used as datamodel for Profile class
    // [C]reate profile query 
    // [R]ead all profiles query as ListObject of Profile
    // [U]pdate profile query
    // [D]elete profile query
    class ProfileDataModel : DataModel
    {
        public List<Profile> GetAllProfiles()
        {
            List<Profile> profiles = new List<Profile>();

            using (MySqlCommand qry = GetDBConnection().ExecuteSql("SELECT * FROM profile"))
            {

                try
                {
                    GetDBConnection().con.Open();
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
                        GetDBConnection().con.Close();
                    }

                }
                catch (Exception e)
                {
                    SetErrorMsg(e.Message.ToString());
                }


            }

            return profiles;
        }

        public List<Role> GetAllRoles()
        {
            List<Role> roles = new List<Role>();

            using (MySqlCommand qry = GetDBConnection().ExecuteSql("SELECT * FROM role"))
            {
                try
                {
                    GetDBConnection().con.Open();
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
                        GetDBConnection().con.Close();
                    }

                }
                catch (Exception e)
                {
                    SetErrorMsg(e.Message.ToString());
                }


            }

            return roles;
        }

        public void CreateProfile(string name, string surname, int age, double weight, double length, int roleId)
        {
            using (MySqlCommand qry = GetDBConnection().ExecuteSql($"INSERT INTO `profile` (`id`, `name`, `surname`, `age`, `weight`, `length`, `roleId`, `username`, `password`) VALUES (NULL, '{name}', '{surname}', '{age}', '{weight}', '{length}', '{roleId}', '', '');"))
            {
                ExecNonQry(qry);
            }
        }

        public void UpdateProfile(int id, string name, string surname, int age, double weight, double length, int roleId)
        {
            using (MySqlCommand qry = GetDBConnection().ExecuteSql($"UPDATE profile SET name = '{name}',surname = '{surname}',age = '{age}', weight = '{weight}', length = '{length}', roleId = '{roleId}' WHERE id = {id}; "))
            {
                ExecNonQry(qry);
            }
        }

        public void DeleteProfile(int id)
        {
            using (MySqlCommand qry = GetDBConnection().ExecuteSql($"DELETE FROM `profile` WHERE `id`= {id}"))
            {
                ExecNonQry(qry);
            }
        }
    }
}
