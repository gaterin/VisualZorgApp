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
using VisualZorgApp.Handlers;
using VisualZorgApp.ListHandlers;

namespace VisualZorgApp
{
    public partial class ZorgApp : Form
    {
        ProfileList profileList = new ProfileList();
        DrugList drugList = new DrugList();
        DrugPrescriptionList drugPrescriptionList = new DrugPrescriptionList();
        MyProfile myProfile = new MyProfile(1);
        Language language = new Language();
        
        public ZorgApp()
        {
            InitializeComponent();
        }

        private void ZorgApp_Load(object sender, EventArgs e)
        {

            FetchAllData();
            RenderAll();
            /*MessageBox.Show(msg);*/

        }

        private void FetchAllData()
        {
                profileList.SqlAllProfilesToList();
                profileList.SqlAllRolesToList();
                drugList.SqlAllDrugsToList();
                drugPrescriptionList.SqlAllDrugPrescriptionsToList();
        }

        private void RenderAll()
        {
            RenderMyProfile();
            RenderMyProfilePrescribedDrugs();
            RenderMyProfileRegisteredWeights();
            RenderProfiles();
            RenderDrugs();
            RenderPrescribedDrugs();
            NotifyPrescribedDrugs();
        }

        private void Translate(int langId)
        {
            Dictionary<string,string> lang= language.GetLang(langId);
            string affix = " : ";

            try
            {
                MyProfileTab.Text = lang["myProfile_tab_header"];
                ProfileListTab.Text = lang["profileList_tab_header"];
                DrugListTab.Text = lang["profileList_tab_header"];
                DrugPrescriptionListTab.Text = lang["drugPrescriptionList_tab_header"];

                myProfileDetailsGroupBox.Text = lang["myProfile_yourDetails_header"];
                myProfilePrescribedDrugsGroupBox.Text = lang["myProfile_prescribedDrugs_header"];
                myProfileWeightRegistrationGroupBox.Text = lang["myProfile_weightRegistration_header"];
                changeLanguageGroupBox.Text = lang["myProfile_changeLanguage_header"];

                myProfilePreIdLabel.Text = lang["reuse_id"] + affix;
                myProfilePreNameLabel.Text = lang["reuse_name"] + affix;
                myProfilePreSurnameLabel.Text = lang["reuse_surname"] + affix;
                myProfilePreAgeLabel.Text = lang["reuse_age"] + affix;
                myProfilePreWeightLabel.Text = lang["reuse_weight"] + affix;
                myProfilePreLengthLabel.Text = lang["reuse_length"] + affix;
                myProfilePreBmiLabel.Text = lang["reuse_bmi"] + affix;
                myProfilePreRoleIdLabel.Text = lang["reuse_roleId"] + affix;
                myProfilePreRoleNameLabel.Text = lang["myProfile_yourDetails_roleName"] + affix;

                myProfileWeightRegistrationDateLabel.Text = lang["myProfile_weightRegistration_input_date"];
                myProfileWeightRegistrationTimeLabel.Text = lang["myProfile_weightRegistration_input_time"];
                myProfileWeightRegistrationWeightLabel.Text = lang["reuse_weight"];

                WeightRegistrationCreateButton.Text = lang["button_create"];
                WeightRegistrationUpdateButton.Text = lang["button_update"];
                WeightRegistrationDeleteButton.Text = lang["button_delete"];
                changeLanguageDutchButton.Text = lang["myProfile_changeLanguage_button_dutch"];
                changeLanguageEnglishButton.Text = lang["myProfile_changeLanguage_button_english"];
                changeLanguageBulgarianButton.Text = lang["myProfile_changeLanguage_button_bulgarian"];

                MyProfilePrescribedDrugGridView.Columns["myProfilePrescribedDrugName"].HeaderText = lang["reuse_drugName"];
                MyProfilePrescribedDrugGridView.Columns["myProfilePrescribedDrugIntakeTime"].HeaderText = lang["reuse_time"];
                MyProfilePrescribedDrugGridView.Columns["myProfilePrescribedDrugStartDate"].HeaderText = lang["reuse_startDate"];
                MyProfilePrescribedDrugGridView.Columns["myProfilePrescribedDrugEndDate"].HeaderText = lang["reuse_endDate"];

                RegisteredWeightGridView.Columns["registeredWeightDate"].HeaderText = lang["reuse_date"];
                RegisteredWeightGridView.Columns["registeredWeightTime"].HeaderText = lang["reuse_time"];
                RegisteredWeightGridView.Columns["registeredWeight"].HeaderText = lang["reuse_weight"];

                profileListNameLabel.Text = lang["reuse_name"];
                profileListSurnameLabel.Text = lang["reuse_surname"];
                profileListAgeLabel.Text = lang["reuse_age"];
                profileListWeightLabel.Text = lang["reuse_weight"];
                profileListLengthLabel.Text = lang["reuse_length"];
                profileListRoleIdLabel.Text = lang["reuse_roleId"];

                ProfileGridView.Columns["profileId"].HeaderText = lang["reuse_profileId"];
                ProfileGridView.Columns["profileName"].HeaderText = lang["reuse_name"];
                ProfileGridView.Columns["profileSurname"].HeaderText = lang["reuse_surname"];
                ProfileGridView.Columns["profileAge"].HeaderText = lang["reuse_age"];
                ProfileGridView.Columns["profileWeight"].HeaderText = lang["reuse_weight"];
                ProfileGridView.Columns["profileLength"].HeaderText = lang["reuse_length"];
                ProfileGridView.Columns["profileRoleId"].HeaderText = lang["reuse_roleId"];
                ProfileGridView.Columns["profileBmi"].HeaderText = lang["reuse_bmi"];

                ProfileCreateButton.Text = lang["button_create"];
                ProfileUpdateButton.Text = lang["button_update"];
                ProfileDeleteButton.Text = lang["button_delete"];

                drugListNameLabel.Text = lang["reuse_drugName"];
                drugListDescriptionLabel.Text = lang["reuse_drugDescription"];
                drugListTypeLabel.Text = lang["reuse_drugType"];
                drugListDosageLabel.Text = lang["reuse_drugDosage"];

                DrugGridView.Columns["drugId"].HeaderText = lang["reuse_drugId"];
                DrugGridView.Columns["drugName"].HeaderText = lang["reuse_drugName"];
                DrugGridView.Columns["drugDescription"].HeaderText = lang["reuse_drugDescription"];
                DrugGridView.Columns["drugType"].HeaderText = lang["reuse_drugType"];
                DrugGridView.Columns["drugDosage"].HeaderText = lang["reuse_drugDosage"];

                DrugCreateButton.Text = lang["button_create"];
                DrugUpdateButton.Text = lang["button_update"];
                DrugDeleteButton.Text = lang["button_delete"];

                drugPrescriptionListProfileIdLabel.Text = lang["reuse_profileId"];
                drugPrescriptionListDrugIdLabel.Text = lang["reuse_drugId"];
                drugPrescriptionListIntakeTimeLabel.Text = lang["reuse_intakeTime"];
                drugPrescriptionListStartDateLabel.Text = lang["reuse_startDate"];
                drugPrescriptionListEndDateLabel.Text = lang["reuse_endDate"];

                DrugPrescriptionCreateButton.Text = lang["button_create"];
                DrugPrescriptionUpdateButton.Text = lang["button_update"];
                DrugPrescriptionDeleteButton.Text = lang["button_delete"];

                DrugPrescriptionGridView.Columns["prescribedDrugId"].HeaderText = lang["reuse_drugId"];
                DrugPrescriptionGridView.Columns["prescribedDrugName"].HeaderText = lang["reuse_drugName"];
                DrugPrescriptionGridView.Columns["prescribedDrugProfileId"].HeaderText = lang["reuse_profileId"];
                DrugPrescriptionGridView.Columns["prescribedDrugProfileName"].HeaderText = lang["reuse_profileName"];
                DrugPrescriptionGridView.Columns["prescribedDrugIntakeTime"].HeaderText = lang["reuse_time"];
                DrugPrescriptionGridView.Columns["prescribedDrugStartDate"].HeaderText = lang["reuse_startDate"];
                DrugPrescriptionGridView.Columns["prescribedDrugEndDate"].HeaderText = lang["reuse_endDate"];
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Lang file does not exsist or there is an error in the lang file");
            }
            
        }
        private void RenderPrescribedDrugs()
        {
            DrugPrescriptionGridView.Rows.Clear();
            ProfileIdInput.Items.Clear();
            DrugIdInput.Items.Clear();

            //populate profile dropdown

            foreach (var item in profileList.GetProfileList())
            {
                ProfileIdInput.Items.Add(item.GetId() + " , " + item.GetName());
            }

            //populate drug dropdown

            foreach (var item in drugList.GetDrugList())
            {
                DrugIdInput.Items.Add(item.GetId() + " , " + item.GetName());
            }

            foreach (var item in drugPrescriptionList.GetDrugPrescriptionList())
            {
                int rowIndexNumber = DrugPrescriptionGridView.Rows.Add();
                DrugPrescriptionGridView.Rows[rowIndexNumber].Cells["prescribedDrugProfileId"].Value = item.GetProfileId().ToString();
                DrugPrescriptionGridView.Rows[rowIndexNumber].Cells["prescribedDrugProfileName"].Value = item.GetProfileName().ToString();
                DrugPrescriptionGridView.Rows[rowIndexNumber].Cells["prescribedDrugId"].Value = item.GetDrugId().ToString();
                DrugPrescriptionGridView.Rows[rowIndexNumber].Cells["prescribedDrugName"].Value = item.GetDrugName().ToString();
                DrugPrescriptionGridView.Rows[rowIndexNumber].Cells["prescribedDrugIntakeTime"].Value = item.GetDrugIntakeTime().TimeOfDay.ToString();
                DrugPrescriptionGridView.Rows[rowIndexNumber].Cells["prescribedDrugStartDate"].Value = item.GetDrugStartDate().ToLongDateString();
                DrugPrescriptionGridView.Rows[rowIndexNumber].Cells["prescribedDrugEndDate"].Value = item.GetDrugEndDate().ToLongDateString();     
            }
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

            foreach (var item in myProfile.GetWeightRegistrations())
            {
                int rowIndexNumber = RegisteredWeightGridView.Rows.Add();
                RegisteredWeightGridView.Rows[rowIndexNumber].Cells["registeredWeightId"].Value = item.GetId().ToString();
                RegisteredWeightGridView.Rows[rowIndexNumber].Cells["registeredWeightDate"].Value = item.GetDate().ToLongDateString();
                RegisteredWeightGridView.Rows[rowIndexNumber].Cells["registeredWeightTime"].Value = item.GetTime().TimeOfDay.ToString();
                RegisteredWeightGridView.Rows[rowIndexNumber].Cells["registeredWeight"].Value = item.GetWeight().ToString();
            }
        }
        private void RenderMyProfilePrescribedDrugs()
        {
            MyProfilePrescribedDrugGridView.Rows.Clear();
            foreach (var item in myProfile.GetPrescribedDrugs())
            {
                int rowIndexNumber = MyProfilePrescribedDrugGridView.Rows.Add();
                MyProfilePrescribedDrugGridView.Rows[rowIndexNumber].Cells["myProfilePrescribedDrugName"].Value = item.GetDrugName().ToString();
                MyProfilePrescribedDrugGridView.Rows[rowIndexNumber].Cells["myProfilePrescribedDrugIntakeTime"].Value = item.GetDrugIntakeTime().TimeOfDay.ToString();
                MyProfilePrescribedDrugGridView.Rows[rowIndexNumber].Cells["myProfilePrescribedDrugStartDate"].Value = item.GetDrugStartDate().ToLongDateString();
                MyProfilePrescribedDrugGridView.Rows[rowIndexNumber].Cells["myProfilePrescribedDrugEndDate"].Value = item.GetDrugEndDate().ToLongDateString();
            }
        }
        private void RenderMyProfile()
        {
            myProfileIdLabel.Text = myProfile.GetId().ToString();
            myProfileNameLabel.Text = myProfile.GetName().ToString();
            myProfileSurnameLabel.Text = myProfile.GetSurname().ToString();
            myProfileAgeLabel.Text = myProfile.GetAge().ToString();
            myProfileWeightLabel.Text =  myProfile.GetWeight().ToString();
            myProfileLengthLabel.Text = myProfile.GetLength().ToString();
            myProfileBmiLabel.Text = myProfile.GetBmi().ToString();
            myProfileRoleIdLabel.Text =  myProfile.GetRoleId().ToString();
            myProfileRoleNameLabel.Text = myProfile.GetRoleName().ToString();

            MyProfilePrescribedDrugGridView.Rows.Clear();

            

        }
        private void RenderDrugs()
        {

            DrugGridView.Rows.Clear();

            foreach (var item in drugList.GetDrugList())
            {

                if (item.GetName() == null )
                {
                    item.SetName("");
                }

                int rowIndexNumber = DrugGridView.Rows.Add();
                DrugGridView.Rows[rowIndexNumber].Cells["drugId"].Value = item.GetId().ToString();
                DrugGridView.Rows[rowIndexNumber].Cells["drugName"].Value = item.GetName().ToString();
                DrugGridView.Rows[rowIndexNumber].Cells["drugDescription"].Value = item.GetDescription().ToString();
                DrugGridView.Rows[rowIndexNumber].Cells["drugType"].Value = item.GetTypeOfDrug().ToString();
                DrugGridView.Rows[rowIndexNumber].Cells["drugDosage"].Value = item.GetDosage().ToString();
            }
        }
        private void RenderProfiles()
        {

            ProfileGridView.Rows.Clear();
            ProfileRoleIdInput.Items.Clear();
            //populate role dropdown


            foreach (var item in profileList.GetRoleList())
            {
                ProfileRoleIdInput.Items.Add(item.GetId()+" , "+item.GetName());
            }

            //populate profile view
            foreach (var item in profileList.GetProfileList())
            {

                if (item.GetName() == null || item.GetSurname() == null)
                {
                    item.SetName("");
                    item.SetSurname("");
                }

                int rowIndexNumber = ProfileGridView.Rows.Add();
                ProfileGridView.Rows[rowIndexNumber].Cells["profileId"].Value = item.GetId().ToString();
                ProfileGridView.Rows[rowIndexNumber].Cells["profileName"].Value = item.GetName().ToString();
                ProfileGridView.Rows[rowIndexNumber].Cells["profileSurname"].Value = item.GetSurname().ToString();
                ProfileGridView.Rows[rowIndexNumber].Cells["profileAge"].Value = item.GetAge().ToString();
                ProfileGridView.Rows[rowIndexNumber].Cells["profileWeight"].Value = item.GetWeight().ToString();
                ProfileGridView.Rows[rowIndexNumber].Cells["profileLength"].Value = item.GetLength().ToString();
                ProfileGridView.Rows[rowIndexNumber].Cells["profileRoleId"].Value = item.GetRoleId().ToString();
                ProfileGridView.Rows[rowIndexNumber].Cells["profileBmi"].Value = item.GetBmi().ToString();

            }
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
                //Id is separated from the ComboBox string and used to make the query
                string[] profileRoleIdArray = ProfileRoleIdInput.Text.Split(',');
                int profileRoleId = Convert.ToInt32(profileRoleIdArray[0].Trim());

                profileList.SqlCreateProfile(
                                ProfileNameInput.Text,
                                ProfileSurnameInput.Text,
                                Convert.ToInt32(ProfileAgeInput.Text),
                                Convert.ToDouble(ProfileWeightInput.Text),
                                Convert.ToDouble(ProfileLengthInput.Text),
                                profileRoleId
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

            //Id is separated from the ComboBox string and used to make the query
            string[] profileRoleIdArray = ProfileRoleIdInput.Text.Split(',');
            int profileRoleId = Convert.ToInt32(profileRoleIdArray[0].Trim());

            profileList.SqlUpdateProfile
                            (
                                currentRowId,
                                ProfileNameInput.Text,
                                ProfileSurnameInput.Text,
                                Convert.ToInt32(ProfileAgeInput.Text),
                                Convert.ToDouble(ProfileWeightInput.Text),
                                Convert.ToDouble(ProfileLengthInput.Text),
                                profileRoleId
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
                                DrugNameInput.Text,
                                DrugDescriptionInput.Text,
                                DrugTypeInput.Text,
                                DrugDosageInput.Text
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
                                DrugNameInput.Text,
                                DrugDescriptionInput.Text,
                                DrugTypeInput.Text,
                                DrugDosageInput.Text
                                );
            }
            drugList.SqlAllDrugsToList();
            RenderDrugs();
        }

        private void tabs_Click(object sender, EventArgs e)
        {
            int id = myProfile.GetId();
            myProfile = new MyProfile(id);
            RenderAll();
        }

        private void DrugPrescriptionGridView_Click(object sender, EventArgs e)
        {
            //separate id initialization
            //used so you can update the drug id and profile id without getting the bug where it edits itself
            drugPrescriptionList.selectedRowProfileId =  Convert.ToInt32(DrugPrescriptionGridView.CurrentRow.Cells["prescribedDrugProfileId"].Value);
            drugPrescriptionList.selectedRowDrugId = Convert.ToInt32(DrugPrescriptionGridView.CurrentRow.Cells["prescribedDrugId"].Value);
            
            ProfileIdInput.Text = DrugPrescriptionGridView.CurrentRow.Cells["prescribedDrugProfileId"].Value.ToString();
            DrugIdInput.Text = DrugPrescriptionGridView.CurrentRow.Cells["prescribedDrugId"].Value.ToString();
            //Converted from long string to short string
            //easier for user to edit
            DrugIntakeTimeInput.Text = Convert.ToDateTime(DrugPrescriptionGridView.CurrentRow.Cells["prescribedDrugIntakeTime"].Value).ToString("HH:mm:ss");
            DrugStartDateInput.Text = Convert.ToDateTime(DrugPrescriptionGridView.CurrentRow.Cells["prescribedDrugStartDate"].Value).ToString("yyyy-MM-dd");
            DrugEndDateInput.Text = Convert.ToDateTime(DrugPrescriptionGridView.CurrentRow.Cells["prescribedDrugEndDate"].Value).ToString("yyyy-MM-dd");

        }

        private void DrugPrescriptionCreateButton_Click(object sender, EventArgs e)
        {
            //Id is separated from the ComboBox string and used to make the query
            string[] profileIdArray = ProfileIdInput.Text.Split(',');
            int profileId = Convert.ToInt32(profileIdArray[0].Trim());

            string[] drugIdArray = DrugIdInput.Text.Split(',');
            int drugId  = Convert.ToInt32(drugIdArray[0].Trim());

            if (!string.IsNullOrWhiteSpace(ProfileIdInput.Text) &&
                 !string.IsNullOrWhiteSpace(DrugIdInput.Text) &&
                 !string.IsNullOrWhiteSpace(DrugIntakeTimeInput.Text) &&
                 !string.IsNullOrWhiteSpace(DrugStartDateInput.Text) &&
                 !string.IsNullOrWhiteSpace(DrugEndDateInput.Text)
                )
            {
                drugPrescriptionList.SqlCreateDrugPrescription(
                                profileId,
                                drugId,
                                DrugIntakeTimeInput.Text,
                                DrugStartDateInput.Text,
                                DrugEndDateInput.Text
                                );
            }

            drugPrescriptionList.SqlAllDrugPrescriptionsToList();
            RenderPrescribedDrugs();
        }

        private void DrugPrescriptionUpdateButton_Click(object sender, EventArgs e)
        {
            //Id is separated from the ComboBox string and used to make the query
            string[] profileIdArray = ProfileIdInput.Text.Split(',');
            int profileId = Convert.ToInt32(profileIdArray[0].Trim());

            string[] drugIdArray = DrugIdInput.Text.Split(',');
            int drugId = Convert.ToInt32(drugIdArray[0].Trim());

            if (!string.IsNullOrWhiteSpace(ProfileIdInput.Text) &&
                 !string.IsNullOrWhiteSpace(DrugIdInput.Text) &&
                 !string.IsNullOrWhiteSpace(DrugIntakeTimeInput.Text) &&
                 !string.IsNullOrWhiteSpace(DrugStartDateInput.Text) &&
                 !string.IsNullOrWhiteSpace(DrugEndDateInput.Text)
                )
            {
                drugPrescriptionList.SqlUpdateDrugPrescription(
                                  profileId,
                                  drugId,
                                  DrugIntakeTimeInput.Text,
                                  DrugStartDateInput.Text,
                                  DrugEndDateInput.Text
                                  );
            }

            drugPrescriptionList.SqlAllDrugPrescriptionsToList();
            RenderPrescribedDrugs();
        }

        private void DrugPrescriptionDeleteButton_Click(object sender, EventArgs e)
        {
            int currentRowProfileId = Convert.ToInt32(DrugPrescriptionGridView.CurrentRow.Cells["prescribedDrugProfileId"].Value);
            int currentRowDrugId = Convert.ToInt32(DrugPrescriptionGridView.CurrentRow.Cells["prescribedDrugId"].Value);
            drugPrescriptionList.SqlDeleteDrugPrescription(currentRowProfileId, currentRowDrugId);
            drugPrescriptionList.SqlAllDrugPrescriptionsToList();
            RenderPrescribedDrugs();
        }

        private void RegisteredWeightGridView_Click(object sender, EventArgs e)
        {
            myProfile.SetSelectedRowWeightRegistrationId(Convert.ToInt32(RegisteredWeightGridView.CurrentRow.Cells["registeredWeightId"].Value));

            WeightRegistrationDateInput.Text = Convert.ToDateTime(RegisteredWeightGridView.CurrentRow.Cells["registeredWeightDate"].Value).ToString("yyyy-MM-dd");
            WeightRegistrationTimeInput.Text = Convert.ToDateTime(RegisteredWeightGridView.CurrentRow.Cells["registeredWeightTime"].Value).ToString("HH:mm:ss");
            WeightRegistrationWeightInput.Text = RegisteredWeightGridView.CurrentRow.Cells["registeredWeight"].Value.ToString();
        }

        private void WeightRegistrationCreateButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(WeightRegistrationDateInput.Text) &&
                 !string.IsNullOrWhiteSpace(WeightRegistrationTimeInput.Text) &&
                 !string.IsNullOrWhiteSpace(WeightRegistrationWeightInput.Text) 
                )
            {
                myProfile.SqlCreateWeightRegistration(
                                WeightRegistrationDateInput.Text,
                                WeightRegistrationTimeInput.Text,
                               Convert.ToDouble(WeightRegistrationWeightInput.Text)
                                );
            }

            myProfile.FetchRegisteredWeightsForMyProfile(myProfile.GetId());
            RenderMyProfileRegisteredWeights();
        }

        private void WeightRegistrationUpdateButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(WeightRegistrationDateInput.Text) &&
                 !string.IsNullOrWhiteSpace(WeightRegistrationTimeInput.Text) &&
                 !string.IsNullOrWhiteSpace(WeightRegistrationWeightInput.Text)
                )
            {
                myProfile.SqlUpdateWeightRegistration(
                                WeightRegistrationDateInput.Text,
                                WeightRegistrationTimeInput.Text,
                               Convert.ToDouble(WeightRegistrationWeightInput.Text)
                                );
            }

            myProfile.FetchRegisteredWeightsForMyProfile(myProfile.GetId());
            RenderMyProfileRegisteredWeights();
        }

        private void WeightRegistrationDeleteButton_Click(object sender, EventArgs e)
        {
            myProfile.SqlDeleteWeightRegistration();
            myProfile.FetchRegisteredWeightsForMyProfile(myProfile.GetId());
            RenderMyProfileRegisteredWeights();
        }

        private void languageDutchButton_Click(object sender, EventArgs e)
        {
            Translate(1);
        }

        private void languageEnglishButton_Click(object sender, EventArgs e)
        {
            Translate(2);
        }

        private void changeLanguageBulgarianButton_Click(object sender, EventArgs e)
        {
            Translate(3);
        }
    }
}
