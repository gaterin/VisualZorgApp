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

        private void SaveAll()
        {
            int rowIndex = 0;
            var profile = profileList.profiles[rowIndex];
            string r = "";
            ProfileList profilesLocal = new ProfileList();

            foreach (DataGridViewRow row in ProfileGridView.Rows)
            {
                /*Convertrow.Cells[0].Value;*/
                /* row.Cells[1].ValueType = typeof(string);
                 row.Cells[2].ValueType = typeof(string);
                 row.Cells[3].ValueType = typeof(int);
                 row.Cells[4].ValueType = typeof(double);
                 row.Cells[5].ValueType = typeof(double);
 */
                int id = Convert.ToInt32(row.Cells[0].Value);
                string name = (string)row.Cells[1].Value;
                string surname = (string)row.Cells[2].Value;
                int age = Convert.ToInt32(row.Cells[3].Value);
                double weight = Convert.ToDouble(row.Cells[0].Value);
                double length = Convert.ToDouble(row.Cells[0].Value);


                if (id == 0 && name == "" && surname =="" && age == 0 && weight == 0.0 && length == 0.0)
                {
                    break;
                }

                profilesLocal.profiles.Add(new Profile {id = id , name =name, surname=surname,age=age,weight = weight, length = length});
                try
                {
                    profile.id = id;
                    profile.name = name;
                    profile.surname = surname;
                    profile.age = age;
                    profile.weight = weight;
                    profile.length = length;
                }
                catch (Exception)
                {

                    throw;
                }

                /*
                                profileList.profiles[rowIndex].name = name;
                                profileList.profiles[rowIndex].surname = surname;
                                profileList.profiles[rowIndex].age = age;
                                profileList.profiles[rowIndex].weight = weight;
                                profileList.profiles[rowIndex].length = length;*/
                rowIndex++;

                /*foreach (var item in row.Cells)
                {
                    
                    *//*item.name = ProfileGridView.Rows[n].Cells[1].Value;
                    item.surname = ProfileGridView.Rows[n].Cells[2].Value;
                    item.age = ProfileGridView.Rows[n].Cells[3].Value;
                    item.weight = ProfileGridView.Rows[n].Cells[4].Value;
                    item.length = ProfileGridView.Rows[n].Cells[5].Value;*//*
                }*/


            }

            profilesLocal.SaveJsonToFile(profilesLocal.SerializeProfileListToJson());
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
