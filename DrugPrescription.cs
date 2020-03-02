using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualZorgApp
{

    class DrugPrescription
    {
        private string drugName;
        private string drugIntakeTime;
        private string drugStartDate;
        private string drugEndDate;

        public DrugPrescription(string drugName, string drugIntakeTime, string drugStartDate, string drugEndDate)
        {
            SetDrugName(drugName);
            SetDrugIntakeTime(drugIntakeTime);
            SetDrugStartDate(drugStartDate);
            SetDrugEndDate(drugEndDate);
        }
        public string GetDrugName()
        {
            return drugName;
        }
        public string GetDrugIntakeTime()
        {
            return drugIntakeTime;
        }
        public string GetDrugStartDate()
        {
            return drugStartDate;
        }
        public string GetDrugEndDate()
        {
            return drugEndDate;
        }

        public void SetDrugName(string drugName)
        {
            this.drugName = drugName;
        }
        public void SetDrugIntakeTime(string drugIntakeTime)
        {
            this.drugIntakeTime = drugIntakeTime;
        }
        public void SetDrugStartDate(string drugStartDate)
        {
            this.drugStartDate = drugStartDate;
        }
        public void SetDrugEndDate(string drugEndDate)
        {
            this.drugEndDate = drugEndDate;
        }
    }
}
