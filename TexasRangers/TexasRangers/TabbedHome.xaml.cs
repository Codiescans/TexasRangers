using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TexasRangers.Model;

namespace TexasRangers
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabbedHome : TabbedPage
    {
        public TabbedHome()
        {
            InitializeComponent();

            var client = new RestClient("https://api.chucknorris.io/jokes/random");
            var request = new RestRequest(Method.GET);
            var response = client.Execute<Chuckapi>(request);
            var Chucknorrisapi = response.Data;
            string Joke = Chucknorrisapi.Value;
            Chuckjoke.Text = Joke;
           
        }
        private async void FoodMenu_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FoodMenu());
        }

        private async void DrinkMenu_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DrinkMenu());
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.Database.GetNotesAsync();
        }

        async void OnNoteAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ReservationPage
            {
                BindingContext = new Reservation()
            }); 
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new ReservationPage
                {
                    BindingContext = e.SelectedItem as Reservation
                });
            }
        }
    }
}