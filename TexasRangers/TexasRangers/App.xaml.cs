using System;
using System.IO;
using Xamarin.Forms;
using TexasRangers.Data;
using TexasRangers.Model;

namespace TexasRangers
{
    public partial class App : Application
    {
        static ReservationDatabase database;
        public static ReservationDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new ReservationDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ReservationTable.db"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new TabbedHome());
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
