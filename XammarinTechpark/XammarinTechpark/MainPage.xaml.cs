using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XammarinTechpark
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();

        }

        private async void Login_Button_Clicked (object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Login_Page());
        }

        private async void Registration_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Registration_Page());
        }
    }
}
