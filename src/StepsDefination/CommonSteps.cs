using System;
using System.Collections;
using System.Collections.Generic;

using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

using DAX2.DTT.Convertion.Test.Entities;
using DAX2.DTT.Convertion.Test.Common;

namespace DAX2.DTT.Convertion.Test.StepsDefination
{
    [Binding]
    public class CommonSteps
    {
        private string system_id = null;
        private string device_id = null;

        [Given(@"I have opened the DTT conversion tool")]
        [When(@"I open the DTT conversion tool")]
        [Then(@"I open the DTT conversion tool")]
        public void LaunchConversionTool()
        {
            GUIHelper.LaunchDTT2DBApp();
        }

        [Given(@"I have opened the DTT conversion tool with argument (.*)")]
        [When(@"I open the DTT conversion tool with argument (.*)")]
        [Then(@"I open the DTT conversion tool with argument (.*)")]
        public void LaunchConversionTool(string arguments)
        {
            GUIHelper.LaunchDTT2DBApp(arguments);
        }

        [When(@"I set the DB file to (.*)")]
        public void SetDBFile(string file_name)
        {
            string full_file_path = System.AppDomain.CurrentDomain.BaseDirectory + @"DAX2_DB\" + file_name;

            Console.WriteLine(String.Format("Set the path of DB to:{0}", full_file_path));

            GUIHelper.SetDBFilePath(full_file_path);

            //Set data base file to the DBHelper
            SetDBFilePath(file_name);
        }

        [Given(@"I have the default DAX2 Database named (.*)")]
        public void SetDBFilePath(string db_name)
        {
            string full_file_path = System.AppDomain.CurrentDomain.BaseDirectory + @"DAX2_DB\" + db_name;
            DBHelper.SetDBFilePath(full_file_path);
        }


        [When(@"I set the XML file to (.*)")]
        public void SetXMLFile(string file_name)
        {
            string full_file_path = System.AppDomain.CurrentDomain.BaseDirectory + @"DTT_Files\" + file_name;

            Console.WriteLine(String.Format("Set the path of tuning file to:{0}", full_file_path));
            GUIHelper.SetDTTXmlFilePath(full_file_path);
        }

        [When(@"I click on the convert button")]
        public void ClickOnTheConvertButton()
        {
            GUIHelper.ClickConvertBtn();
        }

        [When(@"I press (.*) button on the message box")]
        public void PressButtonOnTheMsgBox(string button_txt)
        {
            if (button_txt.ToUpper() == "OK")
                GUIHelper.ClickOKOnTheMessageWindow();
            else if (button_txt.ToUpper() == "YES")
                GUIHelper.ClickYesOnTheMessageWindow();
            else if (button_txt.ToUpper() == "NO")
                GUIHelper.ClickNoOnTheMessageWindow();
            else
                throw new Exception(String.Format("The button text {0} cannot be resolved.", button_txt));
        }


        [Then(@"I should see a message box with the title (.*) and the message (.*) shows up")]
        public void VerifyTheMessageBox(string title, string message)
        {
            Assert.IsTrue(GUIHelper.IsMessageWindowPresent(title, message));
        }

        [Given(@"I close the DTT conversion tool")]
        [When(@"I close the DTT conversion tool")]
        [Then(@"I close the DTT conversion tool")]
        public void CloseConversionTool()
        {
            //Save the system id first before closing the conversion tool
            system_id = GUIHelper.GetSystemID();

            GUIHelper.CloseDTT2DBApp();
        }

        [Then(@"I should be able to query below new records in the table (.*) of the DAX2 DB")]
        public void VerifyDataConversion(string table_name, Table table)
        {
            //Query the device_id first before do database verification
            if (device_id == null)
                device_id = DBHelper.GetDeviceID(system_id);

            if (table_name == "IEQ_Bands")
            { 
                List<IEQ_Band> ieq_bands = DBHelper.GetIEQBand(device_id);
                table.CompareToSet<IEQ_Band>(ieq_bands);
            }
            else if (table_name == "GEQ_Bands")
            {
                List<GEQ_Band> geq_bands = DBHelper.GetGEQBand(device_id);
                table.CompareToSet<GEQ_Band>(geq_bands);
            }
            else if (table_name == "Device_Info")
            {
                List<Device_Info> device_info = DBHelper.GetDeviceInfo(device_id);
                table.CompareToSet<Device_Info>(device_info);
            }
            else if (table_name == "Profile_Tuning")
            {
                List<Profile_Tuning> profile_tuning = DBHelper.GetProfileTuning(device_id);
                table.CompareToSet<Profile_Tuning>(profile_tuning);
            }
            else
            {
                throw new Exception("The table name cannot be resolved!");
            }
        }

        [Then(@"I should be able to query below (.*) default records in the table (.*) of the DAX2 DB")]
        public void VerifyDefaultTuningData(int count, string table_name, Table table)
        {
            if (table_name == "Device_Info")
            {
                List<Device_Info> device_info = DBHelper.GetDeviceInfo();

                Assert.AreEqual(count, device_info.Count);
                table.CompareToSet<Device_Info>(device_info);
            }

            if (table_name == "Device_Endpoints")
            {
                List<Device_Endpoint> Device_Endpoints = DBHelper.GetDeviceEndpoint();

                Assert.AreEqual(count, Device_Endpoints.Count);
                table.CompareToSet<Device_Endpoint>(Device_Endpoints);
            }

            if (table_name == "Device_Tuning")
            {
                List<Device_Tuning> Device_Tuning = DBHelper.GetDeviceTuning();

                Assert.AreEqual(count, Device_Tuning.Count);
                table.CompareToSet<Device_Tuning>(Device_Tuning);
            }
        }

        [Then(@"I should be able to query below (.*) new records in the table (.*) of the DAX2 DB")]
        [When(@"I should be able to query below (.*) new records in the table (.*) of the DAX2 DB")]
        public void VerifyConvertedTuningData(int count, string table_name, Table table)
        {
            //Query the device_id first before do database verification
            if (device_id == null)
                device_id = DBHelper.GetDeviceID(system_id);

            if (table_name == "IEQ_Bands")
            {
                List<IEQ_Band> ieq_bands = DBHelper.GetIEQBand(device_id);
                Assert.AreEqual(count, ieq_bands.Count);
                table.CompareToSet<IEQ_Band>(ieq_bands);
            }
            else if (table_name == "GEQ_Bands")
            {
                List<GEQ_Band> geq_bands = DBHelper.GetGEQBand(device_id);
                Assert.AreEqual(count, geq_bands.Count);
                table.CompareToSet<GEQ_Band>(geq_bands);
            }
            else if (table_name == "Device_Info")
            {
                List<Device_Info> device_info = DBHelper.GetDeviceInfo(device_id);
                Assert.AreEqual(count, device_info.Count);
                table.CompareToSet<Device_Info>(device_info);
            }
            else if (table_name == "Device_Tuning")
            {
                List<Device_Tuning> device_Tuning = DBHelper.GetDeviceTuning(device_id);
                Assert.AreEqual(count, device_Tuning.Count);
                table.CompareToSet<Device_Tuning>(device_Tuning);
            }
            else if (table_name == "Device_Endpoints")
            {
                List<Device_Endpoint> device_Endpoint = DBHelper.GetDeviceEndpoint(device_id);
                Assert.AreEqual(count, device_Endpoint.Count);
                table.CompareToSet<Device_Endpoint>(device_Endpoint);
            }
            else if (table_name == "Profile_Tuning")
            {
                List<Profile_Tuning> profile_tuning = DBHelper.GetProfileTuning(device_id);
                Assert.AreEqual(count, profile_tuning.Count);
                table.CompareToSet<Profile_Tuning>(profile_tuning);
            }
            else if (table_name == "Profile_EndpointPort")
            {
                List<Profile_EndpointPort> profile_edp_port = DBHelper.GetProfileEdpPort(device_id);
                Assert.AreEqual(count, profile_edp_port.Count);

                table.CompareToSet<Profile_EndpointPort>(profile_edp_port);
            }
            else if (table_name == "Profile_EndpointType")
            {
                List<Profile_EndpointType> profile_edp_type = DBHelper.GetProfileEdpType(device_id);
                Assert.AreEqual(count, profile_edp_type.Count);

                table.CompareToSet<Profile_EndpointType>(profile_edp_type);
            }
            else
            {
                throw new Exception("The table name cannot be resolved!");
            }
        }

        [When(@"I set the operator to (.*)")]
        [Then(@"I set the operator to (.*)")]
        public void SelectOperator(string operator_name)
        {
            GUIHelper.SelectOperator(operator_name);
        }

        [When(@"I set the endpoint to (.*)")]
        [Then(@"I set the endpoint to (.*)")]
        public void SelectEndpoint(string endpoint)
        {
            string[] available_endpoints = new string[] { endpoint };
            GUIHelper.SelectEndpoint(available_endpoints);
        }

        [When(@"I select (.*)")]
        [Then(@"I select (.*)")]
        public void CheckDefaultTuning(string chk_message)
        {
            string chk;
            switch(chk_message)
            {
                case "Import as default tuning for all PC models, apply to SKU": chk = "defaultTuning"; break;
                case "HD Audio": chk = "hdaudio"; break;
                case "HD Audio Core": chk = "hdCore"; break;
                case "DSP": chk = "dsp"; break;
                default: chk = "defaultTuning"; break;
            }
            GUIHelper.CheckDefaultTuning(chk);
        }

        [When(@"I uncheck the three SKUs")]
        [Then(@"I uncheck the three SKUs")]
        public void UncheckDefaultTuning()
        {
            GUIHelper.UncheckDefaultTuning("hdaudio");
            GUIHelper.UncheckDefaultTuning("hdCore");
            GUIHelper.UncheckDefaultTuning("dsp");
        }

        [When(@"I set the device mode to (.*)")]
        [Then(@"I set the device mode to (.*)")]
        public void SelectDeviceMode(string device_mode)
        {
            string[] available_modes = new string[] { device_mode };
            GUIHelper.SelectSpeakerMode(available_modes);
        }
        
        [When(@"I set default profile to (.*)")]
        [Then(@"I set default profile to (.*)")]
        public void SelectProfile(string profile_name)
        {
            GUIHelper.SelectDefaultProfile(profile_name);
        }


        [Given(@"I convert the tuning file (.*) to the database (.*)")]
        [When(@"I convert the tuning file (.*) to the database (.*)")]
        public void ConvertTuningFile(string xml_file, string db_file)
        {
            //Set xml file
            SetXMLFile(xml_file);
            //Set database file
            SetDBFile(db_file);

            //Press convert button
            GUIHelper.ClickConvertBtn();
            //Press OK button on the message box
            GUIHelper.ClickOKOnTheMessageWindow();
        }

        [Given(@"I check Desktop Icon in install options section")]
        [When(@"I check Desktop Icon in install options section")]
        [Then(@"I check Desktop Icon in install options section")]
        public void CheckDesktopIcon()
        {
            GUIHelper.CheckDesktopIcon();
        }

        [Given(@"I uncheck Desktop Icon in install options section")]
        [When(@"I uncheck Desktop Icon in install options section")]
        [Then(@"I uncheck Desktop Icon in install options section")]
        public void UncheckDesktopIcon()
        {
            GUIHelper.UncheckDesktopIcon();
        }

        [Given(@"I check Tray Icon in install options section")]
        [When(@"I check Tray Icon in install options section")]
        [Then(@"I check Tray Icon in install options section")]
        public void CheckTrayIcon()
        {
            GUIHelper.CheckTrayIcon();
        }

        [Given(@"I uncheck Tray Icon in install options section")]
        [When(@"I uncheck Tray Icon in install options section")]
        [Then(@"I uncheck Tray Icon in install options section")]
        public void UncheckTrayIcon()
        {
            GUIHelper.UncheckTrayIcon();
        }

        [Given(@"I check Toast Notification in install options section")]
        [When(@"I check Toast Notification in install options section")]
        [Then(@"I check Toast Notification in install options section")]

        public void CheckToastNotification()
        {
            GUIHelper.CheckToastNotification();
        }

        [Given(@"I uncheck Toast Notification in install options section")]
        [When(@"I uncheck Toast Notification in install options section")]
        [Then(@"I uncheck Toast Notification in install options section")]
        public void UncheckToastNotification()
        {
            GUIHelper.UncheckToastNotification();
        }

        [When(@"I set UX Improvement to (.*) in install options section")]
        public void SelectUXImprovement(string value)
        {
            GUIHelper.SelectUXImprovement(value);
        }

    }
}
