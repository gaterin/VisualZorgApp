﻿using System.Collections.Generic;
using VisualZorgApp.DataModels;
using VisualZorgApp.Handlers;

namespace VisualZorgApp.ListHandlers
{
    // List handler class
    // Handles all CRUD functionalities via its DataModel
    class DrugList
    {
        private List<Drug> drugList = new List<Drug>();
        private DrugDataModel dm = new DrugDataModel();
        public bool SqlDeleteDrug(int id)
        {
            dm.DeleteDrug(id);
            SqlAllDrugsToList();
            return true;
        }
        public bool SqlUpdateDrug(int id, string name, string description, string type, string dosage)
        {
            dm.UpdateDrug(id,name,description,type,dosage);
            SqlAllDrugsToList();
            return true;
        }
        public bool SqlCreateDrug(string name, string description, string type, string dosage)
        {
            dm.CreateDrug(name, description, type, dosage);
            SqlAllDrugsToList();
            return true;
        }
        public bool SqlAllDrugsToList()
        {
            drugList.Clear();
            drugList.AddRange(dm.GetAllDrugs());
            return true;

        }
        public List<Drug> GetDrugList()
        {
            return drugList;
        }
        public void AddDrug(Drug drug)
        {
            drugList.Add(drug);
        }
        
    }

}
