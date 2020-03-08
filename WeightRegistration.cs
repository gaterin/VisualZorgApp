using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualZorgApp
{
    class WeightRegistration
    {
        private DateTime date;
        private DateTime time;
        private double weight;

        public WeightRegistration(string date, string time, double weight)
        {
            SetDate(date);
            SetTime(time);
            SetWeight(weight);
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
