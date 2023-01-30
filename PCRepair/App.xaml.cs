using System;
using System.IO;
using PCRepair.Data;
using Xamarin.Forms;

namespace PCRepair
{
    public partial class App : Application
    {
        static PCRepairDatabase database;

        // Create the database connection as a singleton.
        public static PCRepairDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new PCRepairDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PCRepair.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}