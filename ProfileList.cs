using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MySql.Data.MySqlClient;

namespace VisualZorgApp
{
    public class ProfileList
    {

        public List<Profile> profiles = new List<Profile>();
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

        public void SqlAllProfilesToList()
        {
            using (MySqlCommand qry = ExecuteSql("SELECT * FROM profile"))
            {
                try
                {
                    db.con.Open();
                    using (MySqlDataReader reader = qry.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            profiles.Add(new Profile
                            {
                                id = (int)reader["id"],
                                name = (string)reader["name"],
                                surname = (string)reader["surname"],
                                age = (int)reader["age"],
                                weight = (double)reader["weight"],
                                length = (double)reader["length"],
                                roleId = (int)reader["roleId"],
                                username = (string)reader["username"],
                                password = (string)reader["password"]
                            });

                        }
                    }
                }
                catch (Exception e)
                {


                }

                
                //MySqlCommand qry = ExecuteSql("SELECT * FROM profile");
                //db.con.Open();
                //MySqlDataReader reader = qry.ExecuteReader();




                //}
            }
            db.con.Close();
        }
        public MySqlCommand ExecuteSql(string sql)
        {
        
            MySqlCommand cmd = new MySqlCommand(sql, db.con );
            return cmd;
        }
        public string SerializeProfileListToJson()
        {
            return JsonConvert.SerializeObject(profiles, Formatting.Indented);
        }

        public void SaveJsonToFile(string jsonString)
        {
            System.IO.File.Delete(Const.jsonPath);
            System.IO.File.WriteAllText(Const.jsonPath, jsonString);
        }
        public void DeserializeJsonToProfileList()
        {
            string json = System.IO.File.ReadAllText(Const.jsonPath);
            var jsonDeserialize = JsonConvert.DeserializeObject<List<Profile>>(json);
            profiles = jsonDeserialize;
            
        }
     
        public Profile GetProfile(int id)
        {

            foreach (var profile in profiles)
            {
                if (profile.id == id)
                {
                 
                    return profile;

                }
                
            }
            return null;
        }

       
    }
}
