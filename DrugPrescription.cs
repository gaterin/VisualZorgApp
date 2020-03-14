using System;
namespace VisualZorgApp
{

    class DrugPrescription
    {
        private int drugId;
        private int profileId;
        private string drugName;
        private DateTime drugIntakeTime;
        private DateTime drugStartDate;
        private DateTime drugEndDate;

        public DrugPrescription(string drugName, string drugIntakeTime, string drugStartDate, string drugEndDate)
        {
            SetDrugName(drugName);
            SetDrugIntakeTime(drugIntakeTime);
            SetDrugStartDate(drugStartDate);
            SetDrugEndDate(drugEndDate);
        }
        public DrugPrescription(int drugId, int profileId, string drugName, string drugIntakeTime, string drugStartDate, string drugEndDate)
        {
            SetDrugId(drugId);
            SetProfileId(profileId);
            SetDrugName(drugName);
            SetDrugIntakeTime(drugIntakeTime);
            SetDrugStartDate(drugStartDate);
            SetDrugEndDate(drugEndDate);
        }
        public int GetDrugId()
        {
            return drugId;
        }
        public int GetProfileId()
        {
            return profileId;
        }
        public string GetDrugName()
        {
            return drugName;
        }
        public DateTime GetDrugIntakeTime()
        {
            return drugIntakeTime;
        }
        public DateTime GetDrugStartDate()
        {
            return drugStartDate;
        }
        public DateTime GetDrugEndDate()
        {
            return drugEndDate;
        }

        public void SetDrugId(int drugId)
        {
            this.drugId = drugId;
        }
        public void SetProfileId(int profileId)
        {
            this.profileId = profileId;
        }
        public void SetDrugName(string drugName)
        {
            this.drugName = drugName;
        }
        public void SetDrugIntakeTime(string drugIntakeTime)
        {
           DateTime intakeTime = DateTime.Parse(drugIntakeTime);
            this.drugIntakeTime = intakeTime;
        }
        public void SetDrugStartDate(string drugStartDate)
        {
            DateTime startDate = DateTime.Parse(drugStartDate);
            this.drugStartDate = startDate;
        }
        public void SetDrugEndDate(string drugEndDate)
        {
            DateTime endDate = DateTime.Parse(drugEndDate);
            this.drugEndDate = endDate;
        }
    }
}
