using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public static class LanguageManager
    {
        // Dictionary to store all translations
        private static Dictionary<string, Dictionary<string, string>> translations = new Dictionary<string, Dictionary<string, string>>();

        // Current selected language
        public static string CurrentLanguage { get; private set; } = "English";

        // List of all supported languages
        public static List<string> SupportedLanguages => translations.Keys.ToList();

        // Initialize all translations
        public static void Initialize()
        {
            // English
            translations["English"] = new Dictionary<string, string>
            {
                {"app_title", "Municipal Services Application"},
                {"report_issue_title", "REPORT AN ISSUE"},
                {"report_issue_subtitle", "Help us improve your community by reporting a municipal issue."},
                {"location", "Location"},
                {"category", "Category"},
                {"description", "Description"},
                {"attachments", "Attachments"},
                {"attach_button", "Attach Image / Document"},
                {"submit_button", "Submit Report"},
                {"clear_button", "Clear"},
                {"back_button", "Back to Main Menu"},
                {"select_category", "Select a category..."},
                {"no_file", "No file attached"},
                {"file_attached", "File attached:"},
                {"enter_location", "Please enter the location of the issue."},
                {"location_entered", "Location entered! Now choose the category."},
                {"category_selected", "Category selected: {0}. Keep going and provide a description below."},
                {"provide_description", "Category selected! Keep going and provide a description."},
                {"enter_description", "Great! Now you can attach a file to your report using the 'Attach Image/Document' button."},
                {"file_attached_message", "You have now attached a file! Click the 'Submit Report' button to finalize your report."},
                {"custom_category", "Custom category: {0}. Keep going and provide a description below."},
                {"enter_custom_category", "Please specify your category in the textbox below."},
                {"submitting", "Submitting your report... Please wait."},
                {"submitting_message", "Submitting your report..."},
                {"processing_message", "Processing your report... Thank you for your patience!"},
                {"routing_message", "Your voice matters! Routing to the right department."},
                {"making_difference_message", "Your report is making a difference in our community."},
                {"thank_you_message", "Thank you for helping keep our city clean and safe!"},
                {"success_title", "Report Submitted Successfully"},
                {"success_message", "Issue Reported Successfully!"},
                {"report_details", "REPORT DETAILS"},
                {"location_label", "Location:"},
                {"category_label", "Category:"},
                {"description_label", "Description:"},
                {"attachment_label", "Attachment:"},
                {"reported_label", "Reported:"},
                {"reference_label", "Reference:"},
                {"thank_you_footer", "Thank you for helping improve our community!"},
                {"updates_footer", "We will keep you updated on the progress of this issue."},
                {"input_required", "Input Required"},
                {"validation_location", "Please enter the location of the issue."},
                {"validation_category", "Please select a category for the issue."},
                {"validation_custom_category", "Please specify your custom category in the textbox."},
                {"validation_description", "Please provide a detailed description of the issue."},
                {"clear_confirm", "Are you sure you want to clear the form? All entered data will be lost."},
                {"clear_confirm_title", "Confirm Clear"},
                {"clear_success", "Form cleared. Start a new report when you're ready."},
                {"exit_confirm", "You have unsaved data. Are you sure you want to go back?"},
                {"exit_confirm_title", "Confirm Exit"},
                {"language", "Language"},
                {"category_road", "Road & Potholes Maintenance"},
                {"category_water", "Water & Sanitation Issues"},
                {"category_electricity", "Electricity"},
                {"category_waste", "Waste Management"},
                {"category_safety", "Public Safety"},
                {"category_parks", "Parks & Recreation"},
                {"category_other", "Other"}
            };

           

            // ========================================
            // 4. XITSONGA
            // ========================================
            translations["Xitsonga"] = new Dictionary<string, string>
            {
                {"app_title", "Ntirho wa Masipala"},
                {"report_issue_title", "TIVIISA XIPHIQO"},
                {"report_issue_subtitle", "Hi pfuneta ku antswisa muganga wa wena hi ku tiviisa xiphiqo xa masipala."},
                {"lblLocation", "Ndzawulo"},
                {"lblCategory", "Xiyenge"},
                {"description", "Nhlamuselo"},
                {"lblInstructions", "Langha vukorhokeri laha hansi " },
                {"lblComingSoon", "vukorhokeri byinwani bya masipala byi tava kona eka nkarhi wolu taka" },
                {"attachments", "Swihlanganisi"},
                {"attach_button", "Hlanganisa Xifaniso / Dokhumente"},
                {"submit_button", "Rhuma Xiphiqo"},
                {"clear_button", "Sula"},
                {"back_button", "Vuya eka Menyu leyikulu"},
                {"select_category", "Hlawula xiyenge..."},
                {"no_file", "A ku na fayili yo hlanganisiwa"},
                {"file_attached", "Fayili yi hlanganisiwile:"},
                {"enter_location", "Tsakela ndzawulo ya xiphiqo."},
                {"location_entered", "Ndzawulo yi nghenisiwile! Tsakela xiyenge."},
                {"category_selected", "Xiyenge xi hlawuriwile: {0}. Yana emahlweni u nyika nhlamuselo leyi nga laha hansi."},
                {"provide_description", "Xiyenge xi hlawuriwile! Yana emahlweni u nyika nhlamuselo."},
                {"enter_description", "Kahle! Sweswi u nga hlanganisa fayili hi ku tirhisa bokisi ra 'Hlanganisa Xifaniso / Dokhumente'."},
                {"file_attached_message", "U nga hlanganisa fayili! Cofa bokisi ra 'Rhuma Xiphiqo' ku hetisisa xiphiqo xa wena."},
                {"custom_category", "Xiyenge xo hlawuleka: {0}. Yana emahlweni u nyika nhlamuselo leyi nga laha hansi."},
                {"enter_custom_category", "Cacisa xiyenge xa wena eka bokisi ro tsala ro dlulaka."},
                {"submitting", "Ku rhuma xiphiqo xa wena... Ndzhawulela."},
                {"submitting_message", "Ku rhuma xiphiqo xa wena..."},
                {"processing_message", "Ku cinciwa xiphiqo xa wena... Inkomu hi ku ringanyeta!"},
                {"routing_message", "Rito ra wena ri nkoka! Hi rhuma eka ndzawulo yoleyi."},
                {"making_difference_message", "Xiphiqo xa wena xi endla vun'we eka muganga wa hina."},
                {"thank_you_message", "Inkomu hi ku pfuneta ku hlayisa doroba ra hina ri basekile swinene!"},
                {"success_title", "Xiphiqo Xi Rhumiwe Hi Nkundzu"},
                {"success_message", "Xiphiqo Xi Rhumiwe Hi Nkundzu!"},
                {"report_details", "SWA XIPHIQO"},
                {"location_label", "Ndzawulo:"},
                {"category_label", "Xiyenge:"},
                {"description_label", "Nhlamuselo:"},
                {"attachment_label", "Leswi hlanganisiweke:"},
                {"reported_label", "Xi tivisiwe:"},
                {"reference_label", "Nomboro:"},
                {"thank_you_footer", "Inkomu hi ku pfuneta ku antswisa muganga wa hina!"},
                {"updates_footer", "Hi ta ku hlayisa u ri na vuxokoxoko bya ku ya emahlweni ka xiphiqo lexi."},
                {"input_required", "Ku Languteka Ku Nghenisiwa"},
                {"validation_location", "Tsakela ndzawulo ya xiphiqo."},
                {"validation_category", "Hlawula xiyenge xa xiphiqo."},
                {"validation_custom_category", "Cacisa xiyenge xa wena eka bokisi ro tsala ro dlulaka."},
                {"validation_description", "Nyika nhlamuselo yo anama ya xiphiqo."},
                {"clear_confirm", "Xana wa tiyiseka leswaku u lava ku sula fomu? Vuxokoxoko hinkwabyo byi ta lahleka."},
                {"clear_confirm_title", "Tiyiseka Ku Sula"},
                {"clear_success", "Fomu yi suliwile. Sungula xiphiqo xintshwa loko u lava."},
                {"exit_confirm", "U na vuxokoxoko lebyi nga hlayisiwanga. Xana wa tiyiseka leswaku u lava ku vuya?"},
                {"exit_confirm_title", "Tiyiseka Ku Humela"},
                {"language", "Ririmi"},
                {"category_road", "Ku Lulamisa Tindlela & Swiganga"},
                {"category_water", "Swiphiqo Swa Mati & Swihambiso"},
                {"category_electricity", "Gesi"},
                {"category_waste", "Ku Hlayisa Swihlambalala"},
                {"category_safety", "Nsikelelo Wa Rixaka"},
                {"category_parks", "Mapaki & Matsalwa"},
                {"category_other", "Swinyanya"}
            };

            


            // Set default language
            CurrentLanguage = "English";
        }

        // Get translation for a key
        public static string GetString(string key, params object[] args)
        {
            if (translations.ContainsKey(CurrentLanguage) &&
                translations[CurrentLanguage].ContainsKey(key))
            {
                string value = translations[CurrentLanguage][key];
                return args.Length > 0 ? string.Format(value, args) : value;
            }

            // Fallback to English if translation not found
            if (translations.ContainsKey("English") &&
                translations["English"].ContainsKey(key))
            {
                string value = translations["English"][key];
                return args.Length > 0 ? string.Format(value, args) : value;
            }

            return key;
        }

        // Change language
        public static void SetLanguage(string language)
        {
            if (translations.ContainsKey(language))
            {
                CurrentLanguage = language;
            }
        }

        // Update all controls on a form with translations
        public static void UpdateFormTranslations(Form form)
        {
            foreach (Control control in form.Controls)
            {
                UpdateControlTranslation(control);
            }
            form.Text = GetString("app_title");
        }

        private static void UpdateControlTranslation(Control control)
        {
            // Update based on control type
            if (control is Label || control is Button || control is GroupBox)
            {
                string key = control.Name;
                if (translations[CurrentLanguage].ContainsKey(key))
                {
                    control.Text = GetString(key);
                }
            }
        }
    }
}