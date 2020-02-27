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
            SqlAllUsersToProfiles();
        
        }

        public void SqlAllUsersToProfiles()
        {
            MySqlCommand qry = ExecuteSql("SELECT * FROM profile");
            db.con.Open();
            MySqlDataReader reader = qry.ExecuteReader();

            while (reader.Read())
            {
                int id = (int)reader["id"];
                string name = reader["name"].ToString();
                string surname = reader["surname"].ToString();
                int age = (int)reader["age"];
                double weight = (double)reader["weight"];
                double length = (double)reader["length"];
                int type = (int)reader["roleId"];
                string username = reader["username"].ToString();
                string password = reader["password"].ToString();

                profiles.Add(new Profile { id = id, name = name, surname = surname, age = age, weight = weight, length = length, type = type, username = username, password = password });


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
