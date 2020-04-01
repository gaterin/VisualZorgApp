using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualZorgApp.Handlers
{
    class Language
    {
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
            dutch.Add("button_create", "Creëer");
            dutch.Add("button_update", "Wijzig");
            dutch.Add("button_delete", "Verwijder");

            dutch.Add("reuse_time", "Tijd");
            dutch.Add("reuse_date", "Datum");
            dutch.Add("reuse_id", "ID");
            dutch.Add("reuse_name", "Naam");
            dutch.Add("reuse_surname", "Achternaam");
            dutch.Add("reuse_age", "Leeftijd");
            dutch.Add("reuse_weight", "Gewicht (KG)");
            dutch.Add("reuse_length", "Lengte");
            dutch.Add("reuse_bmi", "BMI");
            dutch.Add("reuse_roleId", "Rol ID");

            dutch.Add("reuse_profileId", "Profiel ID");
            dutch.Add("reuse_profileName", "Profiel Naam");
            dutch.Add("reuse_drugId", "Medicatie ID");
            dutch.Add("reuse_drugName", "Medicatie Naam");
            dutch.Add("reuse_drugDescription", "Medicatie Beschrijving");
            dutch.Add("reuse_drugType", "Medicatie Type");
            dutch.Add("reuse_drugDosage", "Medicatie Dosering");
            dutch.Add("reuse_intakeTime", "Innametijd");
            dutch.Add("reuse_startDate", "Voorschrift begint op");
            dutch.Add("reuse_endDate", "Voorschrift eindigt op");


            dutch.Add("myProfile_tab_header", "MijnProfiel");

            dutch.Add("myProfile_yourDetails_header", "Jouw gegevens");
            dutch.Add("myProfile_yourDetails_roleName", "Rolnaam");

            dutch.Add("myProfile_prescribedDrugs_header", "Voorgeschereven Medicatie");

            dutch.Add("myProfile_weightRegistration_header", "Gewichts geschiedenis");
            dutch.Add("myProfile_weightRegistration_input_date", "Datum registratie");
            dutch.Add("myProfile_weightRegistration_input_time", "Tijd registratie");

            dutch.Add("myProfile_changeLanguage_header", "Verander de taal");
            dutch.Add("myProfile_changeLanguage_button_dutch", "Nederlands");
            dutch.Add("myProfile_changeLanguage_button_english", "Engels");
            dutch.Add("myProfile_changeLanguage_button_bulgarian", "Bulgaars");

            dutch.Add("profileList_tab_header", "ProfielLijst");

            dutch.Add("drugList_tab_header", "MedicatieLijst");
            dutch.Add("drugPrescriptionList_tab_header", "MedicatieVoorschriftenLijst");


        }
        public void FillEnglish()
        {
            english.Add("button_create", "Create");
            english.Add("button_update", "Update");
            english.Add("button_delete", "Delete");

            english.Add("reuse_time", "Time");
            english.Add("reuse_date", "Date");
            english.Add("reuse_id", "ID");
            english.Add("reuse_name", "Name");
            english.Add("reuse_surname", "Surname");
            english.Add("reuse_age", "Age");
            english.Add("reuse_weight", "Weight (KG)");
            english.Add("reuse_length", "Length");
            english.Add("reuse_bmi", "BMI");
            english.Add("reuse_roleId", "Role ID");

            english.Add("reuse_profileId", "Profile ID");
            english.Add("reuse_profileName", "Profile Name");
            english.Add("reuse_drugId", "Drug ID");
            english.Add("reuse_drugName", "Drug Name");
            english.Add("reuse_drugDescription", "Drug Description");
            english.Add("reuse_drugType", "Drug Type");
            english.Add("reuse_drugDosage", "Drug Dosage");
            english.Add("reuse_intakeTime", "Intake Time");
            english.Add("reuse_startDate", "Prescription Starts");
            english.Add("reuse_endDate", "Prescription Ends");

            english.Add("myProfile_tab_header", "MyProfile");

            english.Add("myProfile_yourDetails_header", "Your Details");
            english.Add("myProfile_yourDetails_roleName", "Role Name");

            english.Add("myProfile_prescribedDrugs_header", "Prescribed Drugs");

            english.Add("myProfile_weightRegistration_header", "Weight History");
            english.Add("myProfile_weightRegistration_input_date", "Date of checkpoint");
            english.Add("myProfile_weightRegistration_input_time", "Time of checkpoint");

            english.Add("myProfile_changeLanguage_header", "Change the language");
            english.Add("myProfile_changeLanguage_button_dutch", "Dutch");
            english.Add("myProfile_changeLanguage_button_english", "English");
            english.Add("myProfile_changeLanguage_button_bulgarian", "Bulgarian");

            english.Add("profileList_tab_header", "ProfileList");

            english.Add("drugList_tab_header", "DrugList");
            english.Add("drugPrescriptionList_tab_header", "DrugPrescriptionList");
        }
        public void FillBulgarian()
        {

            bulgarian.Add("button_create", "Създай");
            bulgarian.Add("button_update", "Актуализирай");
            bulgarian.Add("button_delete", "Изтрий");

            bulgarian.Add("reuse_time", "Време");
            bulgarian.Add("reuse_date", "Дата");
            bulgarian.Add("reuse_id", "ID");
            bulgarian.Add("reuse_name", "Име");
            bulgarian.Add("reuse_surname", "Презиме");
            bulgarian.Add("reuse_age", "Възраст");
            bulgarian.Add("reuse_weight", "Тегло (KГ)");
            bulgarian.Add("reuse_length", "Дължина");
            bulgarian.Add("reuse_bmi", "BMI");
            bulgarian.Add("reuse_roleId", "Роля ID");
            bulgarian.Add("reuse_drugName", "Лекарство име");

            bulgarian.Add("reuse_profileId", "Профил ID");
            bulgarian.Add("reuse_profileName", "Профилно име");
            bulgarian.Add("reuse_drugId", "Лекарство ID");
            bulgarian.Add("reuse_drugDescription", "Лекарство описание");
            bulgarian.Add("reuse_drugType", "Лекарство тип");
            bulgarian.Add("reuse_drugDosage", "Лекарство доза");
            bulgarian.Add("reuse_intakeTime", "време за поемане");
            bulgarian.Add("reuse_startDate", "Начало на рецепта");
            bulgarian.Add("reuse_endDate", "Край на рецептата");


            bulgarian.Add("myProfile_tab_header", "МоятПрофил");

            bulgarian.Add("myProfile_yourDetails_header", "Вашите данни");
            bulgarian.Add("myProfile_yourDetails_roleName", "Роля име");

            bulgarian.Add("myProfile_prescribedDrugs_header", "Предписани лекарства");

            bulgarian.Add("myProfile_weightRegistration_header", "Тегло история");
            bulgarian.Add("myProfile_weightRegistration_input_date", "Дата на контрола");
            bulgarian.Add("myProfile_weightRegistration_input_time", "Време на контрола");

            bulgarian.Add("myProfile_changeLanguage_header", "Промяна на езика");
            bulgarian.Add("myProfile_changeLanguage_button_dutch", "Холандски");
            bulgarian.Add("myProfile_changeLanguage_button_english", "Английски");
            bulgarian.Add("myProfile_changeLanguage_button_bulgarian", "Български");

            bulgarian.Add("profileList_tab_header", "ПрофилРегистър");

            bulgarian.Add("drugList_tab_header", "ЛекарстваРегистър");
            bulgarian.Add("drugPrescriptionList_tab_header", "ПредписаниЛекарстваРегистър");
        }
    }
}
