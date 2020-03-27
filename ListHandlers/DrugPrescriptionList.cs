using System.Collections.Generic;
using VisualZorgApp.DataModels;
using VisualZorgApp.Handlers;

namespace VisualZorgApp.ListHandlers
{
    class DrugPrescriptionList
    {
        public int selectedRowDrugId;
        public int selectedRowProfileId;
        private List<DrugPrescription> drugPrescriptionList = new List<DrugPrescription>();
        private DrugPrescriptionDataModel dm = new DrugPrescriptionDataModel();

        public bool SqlAllDrugPrescriptionsToList()
        {
            drugPrescriptionList.Clear();
            drugPrescriptionList.AddRange(dm.GetAllDrugPrescriptions());
            return true;
        }
        public bool SqlCreateDrugPrescription(int profileId, int drugId, string intakeTime, string startDate, string endDate)
        {


            dm.CreateDrugPrescription(profileId, drugId, intakeTime, startDate, endDate);
            SqlAllDrugPrescriptionsToList();
            return true;
        }
        public bool SqlUpdateDrugPrescription(int profileId, int drugId, string intakeTime, string startDate, string endDate)
        {
            dm.UpdateDrugPrescription(profileId, drugId, intakeTime, startDate, endDate, selectedRowDrugId,selectedRowProfileId);
            SqlAllDrugPrescriptionsToList();
            return true;
        }
        public bool SqlDeleteDrugPrescription(int profileId, int drugId)
        {
            dm.DeleteDrugPrescription(profileId, drugId);
            SqlAllDrugPrescriptionsToList();
            return true;
        }

        public void AddDrugPrescription(DrugPrescription drugPrescription)
        {
            drugPrescriptionList.Add(drugPrescription);
        }

        public List<DrugPrescription> GetDrugPrescriptionList()
        {
            return drugPrescriptionList;
        }
    }
    

}
