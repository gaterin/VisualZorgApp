using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            /*      RenderAll();*/
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            profileList.SqlAllProfilesToList();
            drugList.SqlAllDrugsToList();
            RenderMyProfile();
            RenderProfiles();
            RenderDrugs();
            /*string msg = profileList.SqlAllUsersToProfiles();
            MessageBox.Show(msg);*//**/

        }
        private void RenderMyProfile()
        {
            myProfileIdLabel.Text += myProfile.id.ToString();
            myProfileNameLabel.Text += myProfile.name.ToString();
            myProfileSurnameLabel.Text += myProfile.surname.ToString();
            myProfileAgeLabel.Text += myProfile.age.ToString();
            myProfileWeightLabel.Text += myProfile.weight.ToString();
            myProfileLengthLabel.Text += myProfile.length.ToString();
            myProfileBmiLabel.Text += myProfile.GetBmi().ToString();
            myProfileRoleIdLabel.Text += myProfile.roleId.ToString();
            myProfileRoleNameLabel.Text += myProfile.roleName.ToString();

            
            PrescribedDrugsGridView.Rows.Clear();
            PrescribedDrugsGridView.Refresh();

            foreach (var item in myProfile.prescribedDrugs)
            {


                int n = PrescribedDrugsGridView.Rows.Add();
                PrescribedDrugsGridView.Rows[n].Cells[0].Value = item.drugName.ToString();
                PrescribedDrugsGridView.Rows[n].Cells[1].Value = item.drugIntakeTime.ToString();
                PrescribedDrugsGridView.Rows[n].Cells[2].Value = item.drugStartDate.ToString();
                PrescribedDrugsGridView.Rows[n].Cells[3].Value = item.drugEndDate.ToString();



            }

        }
        private void RenderDrugs()
        {



            DrugGridView.Rows.Clear();
            DrugGridView.Refresh();

            foreach (var item in drugList.drugs)
            {

                if (item.name == null )
                {
                    item.name = "";
                }

                int n = DrugGridView.Rows.Add();
                DrugGridView.Rows[n].Cells[0].Value = item.id.ToString();
                DrugGridView.Rows[n].Cells[1].Value = item.name.ToString();
                DrugGridView.Rows[n].Cells[2].Value = item.description.ToString();
                DrugGridView.Rows[n].Cells[3].Value = item.type.ToString();
                DrugGridView.Rows[n].Cells[4].Value = item.dosage.ToString();



            }
        }
        private void RenderProfiles()
        {

           

            ProfileGridView.Rows.Clear();
            ProfileGridView.Refresh();
            foreach (var item in profileList.profiles)
            {

                if (item.name == null || item.surname == null)
                {
                    item.name = "";
                    item.surname = "";
                }

                int n = ProfileGridView.Rows.Add();
                ProfileGridView.Rows[n].Cells[0].Value = item.id.ToString();
                ProfileGridView.Rows[n].Cells[1].Value = item.name.ToString();
                ProfileGridView.Rows[n].Cells[2].Value = item.surname.ToString();
                ProfileGridView.Rows[n].Cells[3].Value = item.age.ToString();
                ProfileGridView.Rows[n].Cells[4].Value = item.weight.ToString();
                ProfileGridView.Rows[n].Cells[5].Value = item.length.ToString();
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

                    profilesLocal.profiles.Add(new Profile { id = id, name = name, surname = surname, age = age, weight = weight, length = length });
                
            }
            profilesLocal.profiles.RemoveAt(profilesLocal.profiles.Count - 1);
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
