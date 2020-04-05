using System.Collections.Generic;
using VisualZorgApp.Handlers;
using VisualZorgApp.DataModels;

namespace VisualZorgApp.ListHandlers
{
    // List handler class
    // Handles all CRUD functionalities via its DataModel
    // Reads all roles into roleList
    public class ProfileList
    {

        private List<Profile> profileList = new List<Profile>();
        private List<Role> roleList = new List<Role>();
        private ProfileDataModel dm = new ProfileDataModel();
        
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
