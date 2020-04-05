
namespace VisualZorgApp.Handlers
{
    // Drug class
    // Basic class used as unit
    class Drug
    {
        private int id;
        private string name;
        private string description;
        private string type;
        private string dosage;
        public Drug(int id, string name, string description, string type, string dosage)
        {
            SetId(id);
            SetName(name);
            SetDescription(description);
            SetType(type);
            SetDosage(dosage);
        }

        public int GetId()
        {
            return id;
        }
        public string GetName()
        {
            return name;
        }
        public string GetDescription()
        {
            return description;
        }
        public string GetTypeOfDrug()
        {
            return type;
        }
        public string GetDosage()
        {
            return dosage;
        }

        public void SetId(int id)
        {
            this.id = id;
        }
        public void SetName(string name)
        {
            this.name = name;
        }
        public void SetDescription(string description)
        {
            this.description = description;

        }
        public void SetType(string type)
        {
            this.type = type;
        }
        public void SetDosage(string dosage)
        {
            this.dosage = dosage;
        }
    }
}
