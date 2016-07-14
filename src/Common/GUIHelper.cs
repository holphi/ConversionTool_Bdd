using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.WindowsAPI;
using TestStack.White.InputDevices;

namespace DAX2.DTT.Convertion.Test.Common
{
    public class GUIHelper
    {
        private static string BASE_DIR = System.AppDomain.CurrentDomain.BaseDirectory;
        private static string DTT2DB_APP_PATH = BASE_DIR + @"DUT\DTT2DB_APP.exe";
        private static string DTT2DB_APP_TITLE = "DTT To DAX2 DataBase Conversion Tool";
        private static string OPEN_DB_WINDOW_TITLE = "Select a Database File";
        private static string OPEN_XML_WINDOW_TITLE = "Select a DTT xml File";

        private static int TIME_OUT = 1500;

        private static Application app=null;
        private static Window window_instance = null;

        public static void LaunchDTT2DBApp()
        {
            try
            {
                app = Application.Launch(DTT2DB_APP_PATH);
                window_instance = app.GetWindow(DTT2DB_APP_TITLE, InitializeOption.NoCache);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void LaunchDTT2DBApp(string arguments)
        {
            try
            {
                ProcessStartInfo launch_arguments = new ProcessStartInfo(DTT2DB_APP_PATH, arguments);
                app = Application.Launch(launch_arguments);
                window_instance = app.GetWindow(DTT2DB_APP_TITLE, InitializeOption.NoCache);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void TerminateDTT2DBApp()
        {
            if (app != null)
            {
                try
                {
                    app.Kill();
                }
                catch (Exception ex)
                { }
            }
        }

        public static void CloseDTT2DBApp()
        { 
            if (app != null)
            {
                app.Close();
            }
        }

        public static void ClickConvertBtn()
        {
            SearchCriteria searchCriteria = SearchCriteria.ByText("CONVERT");
            try
            {
                window_instance.Get<Button>(searchCriteria).Click();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void SetDBFilePath(string filepath)
        {
            try
            {
               Console.WriteLine(filepath);

               //Click Browse button
               window_instance.Get<Button>(SearchCriteria.ByAutomationId("DB_FILE_Button")).Click();
               Window open_file_window = window_instance.ModalWindow(OPEN_DB_WINDOW_TITLE);

               //Input file name to the text box of file name
               open_file_window.Get<TextBox>(SearchCriteria.ByAutomationId("1148")).Enter(filepath);
               
               //Press Open button
               //open_file_window.Get<Button>(SearchCriteria.ByAutomationId("1")).Click();
               Keyboard.Instance.HoldKey(KeyboardInput.SpecialKeys.ALT);
               Keyboard.Instance.Enter("o");
               Keyboard.Instance.LeaveKey(KeyboardInput.SpecialKeys.ALT);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void SetDTTXmlFilePath(string filepath)
        {
            try
            {
                //Click Browse button
                window_instance.Get<Button>(SearchCriteria.ByAutomationId("XML_Browse_Button")).Click();
                Window open_file_window = window_instance.ModalWindow(OPEN_XML_WINDOW_TITLE);

                //Input file name to the text box of xml file
                open_file_window.Get<TextBox>(SearchCriteria.ByAutomationId("1148")).Enter(filepath);

                //Press Open button
                //open_file_window.Get<Button>(SearchCriteria.ByAutomationId("1")).Click();
                //input combination keys: Alt + o to open the selected XML file 
                Keyboard.Instance.HoldKey(KeyboardInput.SpecialKeys.ALT);
                Keyboard.Instance.Enter("o");
                Keyboard.Instance.LeaveKey(KeyboardInput.SpecialKeys.ALT);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool IsMessageWindowPresent(string title, string message)
        {
            bool ret = true;
            try
            {
                Window message_window = window_instance.ModalWindow(title);
                window_instance.Get<UIItem>(SearchCriteria.ByText(message));
            }
            catch (Exception)
            {
                ret = false;
            }

            return ret;
        }

        public static string GetSystemID()
        {
            try
            {
                return window_instance.Get<TextBox>(SearchCriteria.ByAutomationId("m_systemIDTextBox")).Text;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void SelectSpeakerMode(string[] modes)
        {
            string[] available_speaker_mode = new string[]{"Laptop", "Stand", "Tent", "Tablet"};

            //Iterate and check on speaker mode one by one;
            foreach(string item in modes)
            {
                foreach (string mode in available_speaker_mode)
                {
                    if (mode.Equals(item))
                    {
                        CheckSpeakerMode(mode);
                    }
                }
            }
        }

        public static void SelectEndpoint(string[] endpoints)
        {
            string[] available_endpoints = new string[] { "Speaker", "Headphone"};

            //Iterate and check on endpoint one by one;
            foreach (string item in endpoints)
            {
                foreach (string edp in available_endpoints)
                {
                    if (edp.Equals(item))
                        CheckEndpoint(edp);
                }
            }
        }

        private static void CheckEndpoint(string edp)
        {
            CheckBox edp_chkbox;
            try
            {
                edp_chkbox = window_instance.Get<CheckBox>(SearchCriteria.ByAutomationId(String.Format("ENDPOINT_Check_{0}", edp)));
                if ((edp_chkbox.Enabled) && (!edp_chkbox.Checked))
                {
                    edp_chkbox.Click();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void CheckDesktopIcon()
        {
            CheckBox chkbox;
            try
            {
                chkbox = window_instance.Get<CheckBox>(SearchCriteria.ByAutomationId("m_desktopIconCheckBox"));
                if ((chkbox.Enabled) && (!chkbox.Checked))
                {
                    chkbox.Click();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void UncheckDesktopIcon()
        {
            CheckBox chkbox;
            try
            {
                chkbox = window_instance.Get<CheckBox>(SearchCriteria.ByAutomationId("m_desktopIconCheckBox"));
                if ((chkbox.Enabled) && (chkbox.Checked))
                {
                    chkbox.Click();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void CheckTrayIcon()
        {
            CheckBox chkbox;
            try
            {
                chkbox = window_instance.Get<CheckBox>(SearchCriteria.ByAutomationId("m_trayIconCheckBox"));
                if ((chkbox.Enabled) && (!chkbox.Checked))
                {
                    chkbox.Click();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void UncheckTrayIcon()
        {
            CheckBox chkbox;
            try
            {
                chkbox = window_instance.Get<CheckBox>(SearchCriteria.ByAutomationId("m_trayIconCheckBox"));
                if ((chkbox.Enabled) && (chkbox.Checked))
                {
                    chkbox.Click();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void CheckToastNotification()
        {
            CheckBox chkbox;
            try
            {
                chkbox = window_instance.Get<CheckBox>(SearchCriteria.ByAutomationId("m_toastCheckBox"));
                if ((chkbox.Enabled) && (!chkbox.Checked))
                {
                    chkbox.Click();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void UncheckToastNotification()
        {
            CheckBox chkbox;
            try
            {
                chkbox = window_instance.Get<CheckBox>(SearchCriteria.ByAutomationId("m_toastCheckBox"));
                if ((chkbox.Enabled) && (chkbox.Checked))
                {
                    chkbox.Click();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void CheckDefaultTuning(string chk)
        {
            CheckBox df_chkbox;
            try
            {
                df_chkbox = window_instance.Get<CheckBox>(SearchCriteria.ByAutomationId(String.Format("m_{0}CheckBox",chk)));
                if ((df_chkbox.Enabled) && (!df_chkbox.Checked))
                {
                    df_chkbox.Click();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void UncheckDefaultTuning(string chk)
        {
            CheckBox df_chkbox;
            try
            {
                df_chkbox = window_instance.Get<CheckBox>(SearchCriteria.ByAutomationId(String.Format("m_{0}CheckBox", chk)));
                if ((df_chkbox.Enabled) && (df_chkbox.Checked))
                {
                    df_chkbox.Click();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void CheckHeadphones()
        {
            CheckBox edp_chkbox;
            try
            {
                edp_chkbox = window_instance.Get<CheckBox>(SearchCriteria.ByAutomationId("ENDPOINT_Check_Headphone"));
                if ((edp_chkbox.Enabled) && (!edp_chkbox.Checked))
                {
                    edp_chkbox.Click();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void CheckSpeakers()
        {
            CheckBox edp_chkbox;
            try
            {
                edp_chkbox = window_instance.Get<CheckBox>(SearchCriteria.ByAutomationId("ENDPOINT_Check_Speaker"));
                if ((edp_chkbox.Enabled) && (!edp_chkbox.Checked))
                {
                    edp_chkbox.Click();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static Window GetMessageWindowInst()
        {
            try
            {
                return window_instance.ModalWindow(SearchCriteria.ByClassName("#32770"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void ClickOKOnTheMessageWindow()
        {
            try
            {
                Window message_window = GetMessageWindowInst();
                message_window.Get<Button>(SearchCriteria.ByText("OK")).Click();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void ClickYesOnTheMessageWindow()
        {
            try
            {
                Window message_window = GetMessageWindowInst();
                message_window.Get<Button>(SearchCriteria.ByText("Yes")).Click();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void ClickNoOnTheMessageWindow()
        {
            try
            {
                Window message_window = GetMessageWindowInst();
                message_window.Get<Button>(SearchCriteria.ByText("No")).Click();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static void CheckSpeakerMode(string mode)
        {
            CheckBox spk_mode_chkbox;
            try
            {
                spk_mode_chkbox = window_instance.Get<CheckBox>(SearchCriteria.ByAutomationId(String.Format("Spk_Mode_{0}", mode)));
                if ((spk_mode_chkbox.Enabled)&&(!spk_mode_chkbox.Checked))
                {
                    spk_mode_chkbox.Click();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void SelectDefaultProfile(string profile)
        {
            ComboBox profile_cb;
            try
            {
                profile_cb = window_instance.Get<ComboBox>(SearchCriteria.ByAutomationId("cmb_Def_Profile"));
                profile_cb.Select(profile);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void SelectUXImprovement(string value)
        {
            ComboBox improvement_cb;
            try
            {
                improvement_cb = window_instance.Get<ComboBox>(SearchCriteria.ByAutomationId("m_helpImproveCombo"));
                improvement_cb.Select(value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void SelectOperator(string op)
        {
            ComboBox operators_cb;
            try
            {
                operators_cb = window_instance.Get<ComboBox>(SearchCriteria.ByAutomationId("cmb_operator"));
                operators_cb.Select(op);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
