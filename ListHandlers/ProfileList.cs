using System.Collections.Generic;
using VisualZorgApp.Handlers;
using VisualZorgApp.DataModels;

namespace VisualZorgApp.ListHandlers
{
    public class ProfileList
    {

        private List<Profile> profileList = new List<Profile>();
        private List<Role> roleList = new List<Role>();
        private ProfileDataModel dm = new ProfileDataModel();
        
        public ProfileList()
        {
            
/*
            profiles.Add(new Profile { id = 1, name = "Hugh", surname = "Mungu", age = 96, weight = 68.71, length = 1.31, type = 1, username = "hugh", password = "mungu" });
            profiles.Add(new Profile { id = 2, name = "Jack", surname = "Mango", age = 56, weight = 78.23, length = 1.81, type = 2, username = "jack", password = "mango" });
            profiles.Add(new Profile { id = 3, name = "Phil", surname = "PorPo", age = 14, weight = 45.22, length = 2.11, type = 2, username = "phil", password = "porpo" });
*/
            /*SqlAllUsersToProfiles();*/

        }

        
        public bool SqlDeleteProfile(int id)
        {
            dm.DeleteProfile(id);
            SqlAllProfilesToList();
            return true;
        }
        public bool SqlUpdateProfile(int id, string name, string surname, int age, double weight, double length, int roleId)
        {
            dm.UpdateProfile(id, name, surname, age, weight, length, roleId);
            SqlAllProfilesToList();
            return true;
        }
        public bool SqlCreateProfile(string name, string surname, int age, double weight, double length, int roleId)
        {
            dm.CreateProfile(name, surname, age, weight, length,roleId);
            SqlAllProfilesToList();
            return true;
        }
        public bool SqlAllRolesToList()
        {
            roleList.Clear();
            roleList.AddRange(dm.GetAllRoles());
            return true;
        }
        public bool SqlAllProfilesToList()
        {
            profileList.Clear();
            profileList.AddRange(dm.GetAllProfiles());
            return true;
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
