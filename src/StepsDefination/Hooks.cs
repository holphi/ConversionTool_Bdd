using System;
using TechTalk.SpecFlow;

using DAX2.DTT.Convertion.Test.Entities;
using DAX2.DTT.Convertion.Test.Common;

namespace DAX2.DTT.Convertion.Test.StepsDefination
{
    [Binding]
    public sealed class Hooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        [BeforeScenario]
        public void BeforeScenario()
        {
            //TODO: implement logic that has to run before executing each scenario
            string full_file_path = System.AppDomain.CurrentDomain.BaseDirectory + @"DAX2_DB\DAX2.sdf";
            DBHelper.BackupDB(full_file_path);
        }

        [AfterScenario]
        public void AfterScenario()
        {
           //Remove all tuning data
           Console.WriteLine("Reset DAX2 DB: Remove all injected tuning data.");
           Console.WriteLine("Close Conversion tool");
           GUIHelper.TerminateDTT2DBApp();
           DBHelper.CloseDBConnection();
           DBHelper.RestoreDB();
        }
    }
}
