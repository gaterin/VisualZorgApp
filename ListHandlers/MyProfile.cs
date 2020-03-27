using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using VisualZorgApp.DataModels;
using VisualZorgApp.Handlers;
namespace VisualZorgApp.ListHandlers
{
   
    class MyProfile : Profile
    {
        private int id;
        private string username;
        private string password;
        private string roleName;

        private int selectedRowWeightRegistrationId;

        private DBConnection db = new DBConnection();
        private MyProfileDataModel dm = new MyProfileDataModel();
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
            dm.CreateWeightRegistration(date, time, weight, id);
            return true;
        }
        public bool SqlDeleteWeightRegistration()
        {
            dm.DeleteWeightRegistration(id,selectedRowWeightRegistrationId);
            return true;
        }
        public bool SqlUpdateWeightRegistration(string date, string time, double weight)
        {
            dm.UpdateWeightRegistration(date, time, weight, id, selectedRowWeightRegistrationId);
            return true;
        }
        public bool FetchRegisteredWeightsForMyProfile(int id)
        {
            registeredWeights.Clear();
            List<WeightRegistration> weightRegistrations = dm.GetAllWeightRegistrations(id);
            AddRangeRegisteredWeight(weightRegistrations);
            return true;
        }

        public void AddRangeRegisteredWeight(List<WeightRegistration> weightRegistrations)
        {
            registeredWeights.AddRange(weightRegistrations);
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
        
        public bool FetchProfileById(int id)
        {

            string[] profile = dm.GetProfile(id);

            SetId(Convert.ToInt32(profile[0]));
            SetName(profile[1]);
            SetSurname(profile[2]);
            SetAge(Convert.ToInt32(profile[3]));
            SetWeight(Convert.ToDouble(profile[4]));
            SetLength(Convert.ToDouble(profile[5]));
            SetRoleId(Convert.ToInt32(profile[6]));
            SetRoleName(profile[7]);

            return true;
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
            prescribedDrugs.Clear();
            List<DrugPrescription> drugPrescriptions = dm.GetAllDrugPrescriptions(id);
            AddRangePrescribedDrug(drugPrescriptions);
            return true;
        }
        public void AddRangePrescribedDrug(List<DrugPrescription> prescribedDrug)
        {
            prescribedDrugs.AddRange(prescribedDrug);
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
