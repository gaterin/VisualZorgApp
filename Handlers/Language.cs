using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualZorgApp.Handlers
{
    class Language
    {   
        //Translation from english to dutch
        private Dictionary<string,string> dutch = new Dictionary<string, string>();
        private Dictionary<string,string> english = new Dictionary<string, string>();
        private Dictionary<string, string> bulgarian = new Dictionary<string, string>();

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
            dutch.Add("myProfile_tab_header", "MijnProfiel");
            dutch.Add("myProfile_yourDetails_header", "Jouw gegevens");
            dutch.Add("myProfile_yourDetails_id", "ID : ");
            dutch.Add("myProfile_yourDetails_name", "Naam : ");
            dutch.Add("myProfile_yourDetails_surname", "Achternaam : ");
            dutch.Add("myProfile_yourDetails_age", "Leeftijd : ");
            dutch.Add("myProfile_yourDetails_weight", "Gewicht : ");
            dutch.Add("myProfile_yourDetails_length", "Lengte : ");
            dutch.Add("myProfile_yourDetails_bmi", "BMI : ");
            dutch.Add("myProfile_yourDetails_roleId", "Rol ID : ");
            dutch.Add("myProfile_yourDetails_roleName", "Rolnaam : ");
            dutch.Add("myProfile_prescribedDrugs_header", "Voorgeschereven Medicatie");
            dutch.Add("myProfile_prescribedDrugs_table_drugName", "Medicate Naam");
            dutch.Add("myProfile_prescribedDrugs_table_time", "Tijd");
            dutch.Add("myProfile_prescribedDrugs_table_startDate", "Voorschrijving begint op");
            dutch.Add("myProfile_prescribedDrugs_table_endDate", "Voorschrijving eindigt op");
            dutch.Add("myProfile_weightRegistration_header", "Gewichts geschiedenis");
            dutch.Add("myProfile_weightRegistration_input_date", "Datum registratie");
            dutch.Add("myProfile_weightRegistration_input_time", "Tijd registratie");
            dutch.Add("myProfile_weightRegistration_input_weight", "Gewicht in kilogram");
            dutch.Add("myProfile_weightRegistration_button_create", "Creëer");
            dutch.Add("myProfile_weightRegistration_button_update", "Wijzig");
            dutch.Add("myProfile_weightRegistration_button_delete", "Verwijder");
            dutch.Add("myProfile_weightRegistration_table_date", "Datum");
            dutch.Add("myProfile_weightRegistration_table_time", "Tijd");
            dutch.Add("myProfile_weightRegistration_table_weight", "Gewicht (KG)");
            dutch.Add("myProfile_changeLanguage_header", "Verander de taal");
            dutch.Add("myProfile_changeLanguage_button_dutch", "Nederlands");
            dutch.Add("myProfile_changeLanguage_button_english", "Engels");
            dutch.Add("myProfile_changeLanguage_button_bulgarian", "Bulgaars");
        }
        public void FillEnglish()
        {
            english.Add("myProfile_tab_header", "MyProfile");
            english.Add("myProfile_yourDetails_header", "Your Details");
            english.Add("myProfile_yourDetails_id", "ID : ");
            english.Add("myProfile_yourDetails_name", "Name : ");
            english.Add("myProfile_yourDetails_surname", "Surname : ");
            english.Add("myProfile_yourDetails_age", "Age : ");
            english.Add("myProfile_yourDetails_weight", "Weight : ");
            english.Add("myProfile_yourDetails_length", "Length : ");
            english.Add("myProfile_yourDetails_bmi", "BMI : ");
            english.Add("myProfile_yourDetails_roleId", "Role ID : ");
            english.Add("myProfile_yourDetails_roleName", "Role Name : ");
            english.Add("myProfile_prescribedDrugs_header", "Prescribed Drugs");
            english.Add("myProfile_prescribedDrugs_table_drugName", "Drug Name");
            english.Add("myProfile_prescribedDrugs_table_time", "Time");
            english.Add("myProfile_prescribedDrugs_table_startDate", "Prescription Start");
            english.Add("myProfile_prescribedDrugs_table_endDate", "Prescription Ends");
            english.Add("myProfile_weightRegistration_header", "Weight History");
            english.Add("myProfile_weightRegistration_input_date", "Date of checkpoint");
            english.Add("myProfile_weightRegistration_input_time", "Time of checkpoint");
            english.Add("myProfile_weightRegistration_input_weight", "Weight in kilogram");
            english.Add("myProfile_weightRegistration_button_create", "Create");
            english.Add("myProfile_weightRegistration_button_update", "Update");
            english.Add("myProfile_weightRegistration_button_delete", "Delete");
            english.Add("myProfile_weightRegistration_table_date", "Date");
            english.Add("myProfile_weightRegistration_table_time", "Time");
            english.Add("myProfile_weightRegistration_table_weight", "Weight (KG)");
            english.Add("myProfile_changeLanguage_header", "Change the language");
            english.Add("myProfile_changeLanguage_button_dutch", "Dutch");
            english.Add("myProfile_changeLanguage_button_english", "English");
            english.Add("myProfile_changeLanguage_button_bulgarian", "Bulgarian");
        }
        public void FillBulgarian()
        {
            bulgarian.Add("myProfile_tab_header", "МоятПрофил");
            bulgarian.Add("myProfile_yourDetails_header", "Вашите данни");
            bulgarian.Add("myProfile_yourDetails_id", "ID : ");
            bulgarian.Add("myProfile_yourDetails_name", "Име: ");
            bulgarian.Add("myProfile_yourDetails_surname", "Презиме : ");
            bulgarian.Add("myProfile_yourDetails_age", "Възраст : ");
            bulgarian.Add("myProfile_yourDetails_weight", "Тегло : ");
            bulgarian.Add("myProfile_yourDetails_length", "Дължина : ");
            bulgarian.Add("myProfile_yourDetails_bmi", "BMI : ");
            bulgarian.Add("myProfile_yourDetails_roleId", "Роля ID : ");
            bulgarian.Add("myProfile_yourDetails_roleName", "Роля име : ");
            bulgarian.Add("myProfile_prescribedDrugs_header", "Предписани лекарства");
            bulgarian.Add("myProfile_prescribedDrugs_table_drugName", "Лекарство име");
            bulgarian.Add("myProfile_prescribedDrugs_table_time", "Време");
            bulgarian.Add("myProfile_prescribedDrugs_table_startDate", "Начало на рецепта");
            bulgarian.Add("myProfile_prescribedDrugs_table_endDate", "Край на рецептата");
            bulgarian.Add("myProfile_weightRegistration_header", "Тегло история");
            bulgarian.Add("myProfile_weightRegistration_input_date", "Дата на контрола");
            bulgarian.Add("myProfile_weightRegistration_input_time", "Време на контрола");
            bulgarian.Add("myProfile_weightRegistration_input_weight", "Тегло в килограм");
            bulgarian.Add("myProfile_weightRegistration_button_create", "Създай");
            bulgarian.Add("myProfile_weightRegistration_button_update", "Актуализирай");
            bulgarian.Add("myProfile_weightRegistration_button_delete", "Изтрий");
            bulgarian.Add("myProfile_weightRegistration_table_date", "Дата");
            bulgarian.Add("myProfile_weightRegistration_table_time", "Време");
            bulgarian.Add("myProfile_weightRegistration_table_weight", "Тегло (KГ)");
            bulgarian.Add("myProfile_changeLanguage_header", "Промяна на езика");
            bulgarian.Add("myProfile_changeLanguage_button_dutch", "Холандски");
            bulgarian.Add("myProfile_changeLanguage_button_english", "Английски");
            bulgarian.Add("myProfile_changeLanguage_button_bulgarian", "Български");
        }
    }
}
