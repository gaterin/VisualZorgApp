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
    public partial class Form1 : Form
    {
        ProfileList profileList = new ProfileList();

        public Form1()
        {
            InitializeComponent();
            profileList.DeserializeJsonToProfileList();
            RenderAll();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RenderAll();
        }

        private void RenderAll()
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
            RenderAll();
        }


        private void RenderAllButton_Click(object sender, EventArgs e)
        {
            profileList.DeserializeJsonToProfileList();
            RenderAll();
        }

        private void ProfileGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SaveProfileListButton_Click(object sender, EventArgs e)
        {
            SaveAll();
        }
    }
}
