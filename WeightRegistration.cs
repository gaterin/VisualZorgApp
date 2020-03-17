using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualZorgApp
{
    class WeightRegistration
    {
        private int id;
        private DateTime date;
        private DateTime time;
        private double weight;

        public WeightRegistration(int id,string date, string time, double weight)
        {
            SetId(id);
            SetDate(date);
            SetTime(time);
            SetWeight(weight);
        }
        public int GetId()
        {
            return this.id;
        }
        public DateTime GetDate()
        {
            return this.date;
        }
        public DateTime GetTime()
        {
            return this.time;
        }
        public double GetWeight()
        {
            return this.weight;
        }
        public void SetId(int id)
        {
            this.id = id;
        }
        public void SetDate(string date)
        {
            DateTime Date = DateTime.Parse(date);
            this.date = Date;
        }
        public void SetTime(string time)
        {
            DateTime Time = DateTime.Parse(time);
            this.time = Time;
        }
        public void SetWeight(double weight)
        {
            this.weight = weight;
        }
    }
}
