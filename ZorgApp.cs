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
        MyProfile myProfile = new MyProfile(2);

        
        public ZorgApp()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            profileList.SqlAllProfilesToList();
            drugList.SqlAllDrugsToList();
            RenderMyProfile();
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

            PrescribedDrugsGridView.Rows.Clear();
            PrescribedDrugsGridView.Refresh();

            foreach (var item in myProfile.GetPrescribedDrugs())
            {
                int n = PrescribedDrugsGridView.Rows.Add();
                PrescribedDrugsGridView.Rows[n].Cells[0].Value = item.GetDrugName().ToString();
                PrescribedDrugsGridView.Rows[n].Cells[1].Value = item.GetDrugIntakeTime().ToString();
                PrescribedDrugsGridView.Rows[n].Cells[2].Value = item.GetDrugStartDate().ToString();
                PrescribedDrugsGridView.Rows[n].Cells[3].Value = item.GetDrugEndDate().ToString();
            }

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
                DrugGridView.Rows[n].Cells[0].Value = item.GetId().ToString();
                DrugGridView.Rows[n].Cells[1].Value = item.GetName().ToString();
                DrugGridView.Rows[n].Cells[2].Value = item.GetDescription().ToString();
                DrugGridView.Rows[n].Cells[3].Value = item.GetType().ToString();
                DrugGridView.Rows[n].Cells[4].Value = item.GetDosage().ToString();
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
                ProfileGridView.Rows[n].Cells[0].Value = item.GetId().ToString();
                ProfileGridView.Rows[n].Cells[1].Value = item.GetName().ToString();
                ProfileGridView.Rows[n].Cells[2].Value = item.GetSurname().ToString();
                ProfileGridView.Rows[n].Cells[3].Value = item.GetAge().ToString();
                ProfileGridView.Rows[n].Cells[4].Value = item.GetWeight().ToString();
                ProfileGridView.Rows[n].Cells[5].Value = item.GetLength().ToString();
                ProfileGridView.Rows[n].Cells[6].Value = item.GetBmi().ToString();

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

                    profilesLocal.AddProfile(new Profile( id = id, name = name, surname = surname, age = age, weight = weight, length = length, roleId = roleId));
                
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

        private void ProfileGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SaveProfileListButton_Click(object sender, EventArgs e)
        {
            SaveAll();
        }

        private void DrugList_Click(object sender, EventArgs e)
        {

        }

      
    }
}
