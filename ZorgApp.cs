﻿using System;
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
            myProfileIdLabel.Text += myProfile.GetId().ToString();
            myProfileNameLabel.Text += myProfile.GetName().ToString();
            myProfileSurnameLabel.Text += myProfile.GetSurname().ToString();
            myProfileAgeLabel.Text += myProfile.GetAge().ToString();
            myProfileWeightLabel.Text += myProfile.GetWeight().ToString();
            myProfileLengthLabel.Text += myProfile.GetLength().ToString();
            myProfileBmiLabel.Text += myProfile.GetBmi().ToString();
            myProfileRoleIdLabel.Text += myProfile.GetRoleId().ToString();
            myProfileRoleNameLabel.Text += myProfile.GetRoleName().ToString();

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
            
            string currentRowName = ProfileGridView.CurrentRow.Cells["profileName"].Value.ToString();
            string currentRowSurname = ProfileGridView.CurrentRow.Cells["profileSurname"].Value.ToString();
            string currentRowAge = ProfileGridView.CurrentRow.Cells["profileAge"].Value.ToString();
            string currentRowWeight = ProfileGridView.CurrentRow.Cells["profileWeight"].Value.ToString();
            string currentRowLength = ProfileGridView.CurrentRow.Cells["profileLength"].Value.ToString();
            string currentRowRoleId= ProfileGridView.CurrentRow.Cells["profileRoleId"].Value.ToString();

            ProfileNameInput.Text = currentRowName;
            ProfileSurnameInput.Text = currentRowSurname;
            ProfileAgeInput.Text = currentRowAge;
            ProfileWeightInput.Text = currentRowWeight;
            ProfileLengthInput.Text = currentRowLength;
            ProfileRoleIdInput.Text = currentRowRoleId;
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

       
    }
}
