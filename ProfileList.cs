using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VisualZorgApp
{
    public class ProfileList
    {
        public List<Profile> profiles = new List<Profile>();
        public ProfileList()
        {
           /* profiles.Add(new Profile { id = 1, name = "Hugh", surname = "Mungu", age = 96, weight = 68.71, length = 1.31, type = 1, username = "hugh", password = "mungu" });
            profiles.Add(new Profile { id = 2, name = "Jack", surname = "Mango", age = 56, weight = 78.23, length = 1.81, type = 2, username = "jack", password = "mango" });
            profiles.Add(new Profile { id = 3, name = "Phil", surname = "PorPo", age = 14, weight = 45.22, length = 2.11, type = 2, username = "phil", password = "porpo" });*/
        }

        public string SerializeProfileListToJson()
        {

            return JsonConvert.SerializeObject(profiles);
        }

        public void SaveJsonToFile(string jsonString)
        {
            System.IO.File.WriteAllText(@"C:\Users\Georgi\source\repos\gaterin\VisualZorgApp\json\ProfileList.json", jsonString);
        }
        public void DeserializeJsonToProfileList()
        {
            string json = System.IO.File.ReadAllText(@"C:\Users\Georgi\source\repos\gaterin\VisualZorgApp\json\ProfileList.json");
            var jsonDeserialize = JsonConvert.DeserializeObject<List<Profile>>(json);
            profiles = jsonDeserialize;
            
        }
        public void CreateProfile(string name, string surname, int age, double weight, double length)
        {
            int highestId = 0;
            foreach (var profile in profiles)
            {

                if (profile.id > highestId)
                {
                    highestId = profile.id + 1;
                }
            }
            profiles.Add(new Profile { id = highestId, name = name, surname = surname, age = age, weight = weight, length = length });
        }
        public void DeleteProfile(int id)
        {

            foreach (var profile in profiles)
            {

                if (profile.id == id)
                {
                    profiles.Remove(profile);
                    break;
                }
            }

        }
        public void SetProfile(int id, string name, string surname, int age, double weight, double length)
        {

            foreach (var profile in profiles)
            {

                if (profile.id == id)
                {
                    profile.name = name;
                    profile.surname = surname;
                    profile.age = age;
                    profile.weight = weight;
                    profile.length = length;
                    break;

                }
            }
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

        public void RenderAllProfiles()
        {
            Console.WriteLine("ID | Name | Surname | Age | Weight | Length | Bmi");
            Console.WriteLine("-------------------------------------------------");
            foreach (var profile in profiles)
            {
                Console.WriteLine($"{profile.id}  |  {profile.name} | {profile.surname}  |  {profile.age} | {profile.weight}  |  {profile.length}  | {profile.GetBmi()}");
            }
        }
    }
}
