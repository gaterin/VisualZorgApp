using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tulpep.NotificationWindow;

namespace VisualZorgApp
{
    public partial class ZorgApp : Form
    {
         ProfileList profileList = new ProfileList();
         DrugList drugList = new DrugList();
         MyProfile myProfile = new MyProfile(1);

        
        public ZorgApp()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            profileList.SqlAllProfilesToList();
            drugList.SqlAllDrugsToList();
            RenderMyProfile();
            RenderMyProfilePrescribedDrugs();
            RenderMyProfileRegisteredWeights();
            RenderProfiles();
            RenderDrugs();
            NotifyPrescribedDrugs();
            /*string msg = profileList.SqlAllUsersToProfiles();
            MessageBox.Show(msg);*//**/

        }

        private void NotifyPrescribedDrugs()
        {
            string drugsToTakeIn = "";
            
            if (myProfile.GetPrescribedDrugsToNotify().Any())
            {
                
                foreach (var item in myProfile.GetPrescribedDrugsToNotify())
                {
                    drugsToTakeIn += item.ToString() + System.Environment.NewLine;
                }
                Notification notification = new Notification("DRUG INTAKE ALERT!", drugsToTakeIn, true);
            }
            
        }
        private void RenderMyProfileRegisteredWeights()
        {
            RegisteredWeightGridView.Rows.Clear();
            RegisteredWeightGridView.Refresh();
            foreach (var item in myProfile.GetWeightRegistrations())
            {
                int n = RegisteredWeightGridView.Rows.Add();
                RegisteredWeightGridView.Rows[n].Cells["registeredWeightDate"].Value = item.GetDate().ToLongDateString();
                RegisteredWeightGridView.Rows[n].Cells["registeredWeightTime"].Value = item.GetTime().TimeOfDay.ToString();
                RegisteredWeightGridView.Rows[n].Cells["registeredWeight"].Value = item.GetWeight().ToString();
            }
        }
        private void RenderMyProfilePrescribedDrugs()
        {
            PrescribedDrugGridView.Rows.Clear();
            PrescribedDrugGridView.Refresh();
            foreach (var item in myProfile.GetPrescribedDrugs())
            {
                int n = PrescribedDrugGridView.Rows.Add();
                PrescribedDrugGridView.Rows[n].Cells["prescribedDrugName"].Value = item.GetDrugName().ToString();
                PrescribedDrugGridView.Rows[n].Cells["prescribedDrugIntakeTime"].Value = item.GetDrugIntakeTime().TimeOfDay.ToString();
                PrescribedDrugGridView.Rows[n].Cells["prescribedDrugStartDate"].Value = item.GetDrugStartDate().ToLongDateString();
                PrescribedDrugGridView.Rows[n].Cells["prescribedDrugEndDate"].Value = item.GetDrugEndDate().ToLongDateString();
            }
        }
        private void RenderMyProfile()
        {
            myProfileIdLabel.Text = "ID : " + myProfile.GetId().ToString();
            myProfileNameLabel.Text = "Name : " + myProfile.GetName().ToString();
            myProfileSurnameLabel.Text = "Surname : " + myProfile.GetSurname().ToString();
            myProfileAgeLabel.Text = "Age : " + myProfile.GetAge().ToString();
            myProfileWeightLabel.Text = "Weight : " + myProfile.GetWeight().ToString();
            myProfileLengthLabel.Text = "Length : " + myProfile.GetLength().ToString();
            myProfileBmiLabel.Text = "BMI : " + myProfile.GetBmi().ToString();
            myProfileRoleIdLabel.Text = "Role ID : " + myProfile.GetRoleId().ToString();
            myProfileRoleNameLabel.Text = "Role : " + myProfile.GetRoleName().ToString();

            PrescribedDrugGridView.Rows.Clear();
            PrescribedDrugGridView.Refresh();

            

        }
        private void RenderDrugs()
        {

            DrugGridView.Rows.Clear();
            DrugGridView.Refresh();

            foreach (var item in drugList.GetDrugList())
            {

                if (item.GetName() == null )
                {
                    item.SetName("");
                }

                int n = DrugGridView.Rows.Add();
                DrugGridView.Rows[n].Cells["drugId"].Value = item.GetId().ToString();
                DrugGridView.Rows[n].Cells["drugName"].Value = item.GetName().ToString();
                DrugGridView.Rows[n].Cells["drugDescription"].Value = item.GetDescription().ToString();
                DrugGridView.Rows[n].Cells["drugType"].Value = item.GetTypeOfDrug().ToString();
                DrugGridView.Rows[n].Cells["drugDosage"].Value = item.GetDosage().ToString();
            }
        }
        private void RenderProfiles()
        {

            ProfileGridView.Rows.Clear();
            ProfileGridView.Refresh();

            foreach (var item in profileList.GetProfileList())
            {

                if (item.GetName() == null || item.GetSurname() == null)
                {
                    item.SetName("");
                    item.SetSurname("");
                }

                int n = ProfileGridView.Rows.Add();
                ProfileGridView.Rows[n].Cells["profileId"].Value = item.GetId().ToString();
                ProfileGridView.Rows[n].Cells["profileName"].Value = item.GetName().ToString();
                ProfileGridView.Rows[n].Cells["profileSurname"].Value = item.GetSurname().ToString();
                ProfileGridView.Rows[n].Cells["profileAge"].Value = item.GetAge().ToString();
                ProfileGridView.Rows[n].Cells["profileWeight"].Value = item.GetWeight().ToString();
                ProfileGridView.Rows[n].Cells["profileLength"].Value = item.GetLength().ToString();
                ProfileGridView.Rows[n].Cells["profileRoleId"].Value = item.GetRoleId().ToString();
                ProfileGridView.Rows[n].Cells["profileBmi"].Value = item.GetBmi().ToString();

            }
        }

        public ProfileList GetGridData()
        {
            ProfileList profilesLocal = new ProfileList();

            foreach (DataGridViewRow row in ProfileGridView.Rows)
            {
                
                    int id = Convert.ToInt32(row.Cells[0].Value);
                    string name = (string)row.Cells[1].Value;
                    string surname = (string)row.Cells[2].Value;
                    int age = Convert.ToInt32(row.Cells[3].Value);
                    double weight = Convert.ToDouble(row.Cells[4].Value);
                    double length = Convert.ToDouble(row.Cells[5].Value);
                    int roleId = 2;

                    profilesLocal.AddProfile(new Profile( id, name, surname, age,  weight, length, roleId));
                
            }
            profilesLocal.GetProfileList().RemoveAt(profilesLocal.GetProfileList().Count - 1);
             
            return profilesLocal;
        }

        private void SaveAll()
        {
            ProfileList gridData = GetGridData();
            gridData.SaveJsonToFile(gridData.SerializeProfileListToJson());
            profileList.DeserializeJsonToProfileList();
            RenderProfiles();
        }


        private void RenderAllButton_Click(object sender, EventArgs e)
        {
            profileList.DeserializeJsonToProfileList();
            RenderProfiles();
        }

       

        private void SaveProfileListButton_Click(object sender, EventArgs e)
        {
            SaveAll();
        }

        private void DrugList_Click(object sender, EventArgs e)
        {

        }

        private void ProfileGridView_Click(object sender, EventArgs e)
        {
            
            ProfileNameInput.Text = ProfileGridView.CurrentRow.Cells["profileName"].Value.ToString();
            ProfileSurnameInput.Text = ProfileGridView.CurrentRow.Cells["profileSurname"].Value.ToString();
            ProfileAgeInput.Text = ProfileGridView.CurrentRow.Cells["profileAge"].Value.ToString();
            ProfileWeightInput.Text = ProfileGridView.CurrentRow.Cells["profileWeight"].Value.ToString();
            ProfileLengthInput.Text = ProfileGridView.CurrentRow.Cells["profileLength"].Value.ToString();
            ProfileRoleIdInput.Text = ProfileGridView.CurrentRow.Cells["profileRoleId"].Value.ToString();
        }
        private void ProfileCreateButton_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrWhiteSpace(ProfileNameInput.Text) &&
                 !string.IsNullOrWhiteSpace(ProfileSurnameInput.Text) &&
                 !string.IsNullOrWhiteSpace(ProfileAgeInput.Text) &&
                 !string.IsNullOrWhiteSpace(ProfileWeightInput.Text) &&
                 !string.IsNullOrWhiteSpace(ProfileLengthInput.Text) &&
                 !string.IsNullOrWhiteSpace(ProfileRoleIdInput.Text)
                )
            {
                profileList.SqlCreateProfile(
                                ProfileNameInput.Text.ToString(),
                                ProfileSurnameInput.Text.ToString(),
                                Convert.ToInt32(ProfileAgeInput.Text),
                                Convert.ToDouble(ProfileWeightInput.Text),
                                Convert.ToDouble(ProfileLengthInput.Text),
                                Convert.ToInt32(ProfileRoleIdInput.Text)
                                );
            }

            profileList.SqlAllProfilesToList();
            RenderProfiles();

        }
        private void ProfileDeleteButton_Click(object sender, EventArgs e)
        {
            int currentRowId = Convert.ToInt32(ProfileGridView.CurrentRow.Cells["profileId"].Value);
            profileList.SqlDeleteProfile(currentRowId);
            profileList.SqlAllProfilesToList();
            RenderProfiles();
        }
        private void ProfileUpdateButton_Click(object sender, EventArgs e)
        {
            int currentRowId = Convert.ToInt32(ProfileGridView.CurrentRow.Cells["profileId"].Value);
            profileList.SqlUpdateProfile
                            (
                                currentRowId,
                                ProfileNameInput.Text.ToString(),
                                ProfileSurnameInput.Text.ToString(),
                                Convert.ToInt32(ProfileAgeInput.Text),
                                Convert.ToDouble(ProfileWeightInput.Text),
                                Convert.ToDouble(ProfileLengthInput.Text),
                                Convert.ToInt32(ProfileRoleIdInput.Text)
                                );
            profileList.SqlAllProfilesToList();
            RenderProfiles();
        }

      

        private void DrugGridView_Click(object sender, EventArgs e)
        {
            DrugNameInput.Text = DrugGridView.CurrentRow.Cells["drugName"].Value.ToString();
            DrugDescriptionInput.Text = DrugGridView.CurrentRow.Cells["drugDescription"].Value.ToString();
            DrugTypeInput.Text = DrugGridView.CurrentRow.Cells["drugType"].Value.ToString();
            DrugDosageInput.Text = DrugGridView.CurrentRow.Cells["drugDosage"].Value.ToString();

        }

        private void DrugCreateButton_Click(object sender, EventArgs e)
        {
           
            if (!string.IsNullOrWhiteSpace(DrugNameInput.Text) &&
                 !string.IsNullOrWhiteSpace(DrugDescriptionInput.Text) &&
                 !string.IsNullOrWhiteSpace(DrugTypeInput.Text) &&
                 !string.IsNullOrWhiteSpace(DrugDosageInput.Text)
                )
            {
                drugList.SqlCreateDrug(
                                DrugNameInput.Text.ToString(),
                                DrugDescriptionInput.Text.ToString(),
                                DrugTypeInput.Text.ToString(),
                                DrugDosageInput.Text.ToString()
                                );
            }

            drugList.SqlAllDrugsToList();
            RenderDrugs();
        }

        private void DrugDeleteButton_Click(object sender, EventArgs e)
        {
            int currentRowId = Convert.ToInt32(DrugGridView.CurrentRow.Cells["drugId"].Value);
            drugList.SqlDeleteDrug(currentRowId);
            drugList.SqlAllDrugsToList();
            RenderDrugs();
        }

        private void DrugUpdateButton_Click(object sender, EventArgs e)
        {
            int currentRowId = Convert.ToInt32(DrugGridView.CurrentRow.Cells["drugId"].Value);
            if (!string.IsNullOrWhiteSpace(DrugNameInput.Text) &&
                  !string.IsNullOrWhiteSpace(DrugDescriptionInput.Text) &&
                  !string.IsNullOrWhiteSpace(DrugTypeInput.Text) &&
                  !string.IsNullOrWhiteSpace(DrugDosageInput.Text)
                 )
            {
                drugList.SqlUpdateDrug(
                                currentRowId,
                                DrugNameInput.Text.ToString(),
                                DrugDescriptionInput.Text.ToString(),
                                DrugTypeInput.Text.ToString(),
                                DrugDosageInput.Text.ToString()
                                );
            }
            drugList.SqlAllDrugsToList();
            RenderDrugs();
        }

        private void tabs_Click(object sender, EventArgs e)
        {
            int id = myProfile.GetId();
            myProfile = new MyProfile(id);
            RenderMyProfile();
            RenderMyProfilePrescribedDrugs();
            RenderMyProfileRegisteredWeights();
        }
    }
}
