namespace VisualZorgApp.Handlers
{
    // Role class
    // Basic class used as unit
    public class Role
    {
        private int id;
        private string name;

        public Role()
        {
           
        }
        public Role(int id, string name)
        {
            SetId(id);
            SetName(name);
        }

        public void SetId(int id)
        {
            this.id = id;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public int GetId()
        {
            return id;
        }

        public string GetName()
        {
            return name;
        }
    }
}
