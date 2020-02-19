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
            string r = "";
            
            
            foreach (DataGridViewRow row in ProfileGridView.Rows)
            {
                /*Convertrow.Cells[0].Value;*/
            /*    row.Cells[1].ValueType = typeof(string);
                row.Cells[2].ValueType = typeof(string);
                row.Cells[3].ValueType = typeof(int);
                row.Cells[4].ValueType = typeof(double);
                row.Cells[5].ValueType = typeof(double);
                MessageBox.Show(r);
                *//*r += row.Cells[1].Value.GetType();
                r += row.Cells[2].Value.GetType();
                r += row.Cells[3].Value.GetType();
                r += row.Cells[4].Value.GetType();
                r += row.Cells[5].Value.GetType();
*//*
                profileList.profiles[rowIndex].id = row.Cells[id].Value;
                profileList.profiles[rowIndex].name = row.Cells[1].Value;
                profileList.profiles[rowIndex].surname = row.Cells[2].Value;
                profileList.profiles[rowIndex].age = Convert.ToInt32(row.Cells[3].Value);
                profileList.profiles[rowIndex].weight = Convert.ToDouble(row.Cells[4].Value);
                profileList.profiles[rowIndex].length = Convert.ToDouble(row.Cells[5].Value);
*/
                
                /*foreach (var item in row.Cells)
                {
                    
                    *//*item.name = ProfileGridView.Rows[n].Cells[1].Value;
                    item.surname = ProfileGridView.Rows[n].Cells[2].Value;
                    item.age = ProfileGridView.Rows[n].Cells[3].Value;
                    item.weight = ProfileGridView.Rows[n].Cells[4].Value;
                    item.length = ProfileGridView.Rows[n].Cells[5].Value;*//*
                }*/

                rowIndex++;
            }
            
            profileList.SaveJsonToFile(profileList.SerializeProfileListToJson());
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
