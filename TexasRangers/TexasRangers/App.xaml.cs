using System;
using System.IO;
using Xamarin.Forms;
using TexasRangers.Data;
using TexasRangers.Model;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

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
            AppCenter.Start("android=63eb9af3-89eb-4b98-80fc-9d4510925b1f;" +
                  "uwp={Your UWP App secret here};" +
                  "ios={Your iOS App secret here}",
                  typeof(Analytics), typeof(Crashes));
            try
            {
                Crashes.GenerateTestCrash();
            }
            catch (Exception e)
            {
                Crashes.TrackError(e);
            }


        }
        
        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
