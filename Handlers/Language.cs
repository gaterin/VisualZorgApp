
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace VisualZorgApp.Handlers
{
    // Dictionary class
    // IMPORTANT: Make sure you have set the curDir variable in Const.cs right it should be.
    // Reads Language file based on id
    // Fills Dictionaries per file
    class Language
    {
        public Const constant = new Const();

        private Dictionary<string,string> dutch = new Dictionary<string, string>();
        private Dictionary<string,string> english = new Dictionary<string, string>();
        private Dictionary<string,string> bulgarian = new Dictionary<string, string>();

        public Language()
        {
            FillDutch();
            FillEnglish();
            FillBulgarian();
        }
        public Dictionary<string,string> GetLang(int langId)
        {
            Dictionary<string,string> lang = new Dictionary<string, string>();
            switch (langId)
            {
                case 1:
                    lang = dutch;
                    break;
                case 2:
                    lang = english;
                    break;
                case 3:
                    lang = bulgarian;
                    break;
            }
            return lang;
        }
        
        public void FillDutch()
        { 
            string json;
            try
            {
                json = File.ReadAllText(constant.langDutchJsonPath);
            }
            catch (FileNotFoundException)
            {
                json = "";
            }

            dutch = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

        }
        public void FillEnglish()
        {
            string json;
            try
            {
                json = File.ReadAllText(constant.langEnglishJsonPath);
            }
            catch (FileNotFoundException)
            {
                json = "";
            }

            english = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

           
        }
        public void FillBulgarian()
        {
            string json;
            try
            {
                json = File.ReadAllText(constant.langBulgarianJsonPath);
            }
            catch (FileNotFoundException)
            {
                json = "";
            }
            
            
            bulgarian = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            
        }
    }
}
