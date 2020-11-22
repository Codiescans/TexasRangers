using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TexasRangers
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabbedHome : TabbedPage
    {
        public TabbedHome()
        {
            InitializeComponent();
        }

        private async void ContactButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Contact());
        }
    }
}