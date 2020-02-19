using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualZorgApp
{
    public class Profile
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public int age { get; set; }
        public double weight { get; set; }
        public double length { get; set; }
        public int type { get; set; }
        public string username { get; set; }
        public string password { get; set; }


        public Profile() { 

     
        }
        public double GetBmi()
        {
            return Math.Round(weight / (length * length), 2);
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
