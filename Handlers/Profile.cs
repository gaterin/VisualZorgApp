using System;

namespace VisualZorgApp.Handlers
{

    // Profile class
    // Basic class used as unit

    public class Profile
    {
        private int id;
        private string name;
        private string surname;
        private int age;
        private double weight;
        private double length;
        private int roleId;

        //Constructor overloading
        public Profile() 
        {
            SetId(0);
            SetName(null);
            SetSurname(null);
            SetAge(0);
            SetWeight(0);
            SetLength(0);
            SetRoleId(0);
        }
        public Profile(int id, string name , string surname)
        {
            SetId(id);
            SetName(name);
            SetSurname(surname);
        }
        public Profile(int id , string name , string surname , int age , double weight , double length , int roleId)
        {
            SetId(id);
            SetName(name);
            SetSurname(surname);
            SetAge(age);
            SetWeight(weight);
            SetLength(length);
            SetRoleId(roleId);
        }
        
        //All property Getters
        public int GetId()
        {
            return id;
        }
        public string GetName()
        {
            return name;
        }
        public string GetSurname()
        {
            return surname;
        }
        public int GetAge()
        {
            return age;
        }
        public double GetLength()
        {
            return length;
        }
        public double GetWeight()
        {
            return weight;
        }
        public int GetRoleId()
        {
            return roleId;
        }
        
        //All property Setters
        public void SetId(int id)
        {
           this.id = id;
        }
        public void SetName(string name)
        {
            this.name = name;
        }
        public void SetSurname(string surname)
        {
            this.surname = surname;
        }
        public void SetAge(int age)
        {
            this.age = age;
        }
        public void SetLength(double length)
        {
            this.length = length;
        }
        public void SetWeight(double weight)
        {
            this.weight = weight;
        }
        public void SetRoleId(int roleId)
        {
            this.roleId = roleId;
        }
        public double GetBmi()
        {
            return Math.Round(weight / (length * length), 2);
        }
    }
}
