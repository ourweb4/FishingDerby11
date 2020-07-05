using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FishingDerby.Forms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Settingsfrm : ContentPage
    {
        public Settingsfrm()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var app = Application.Current as App;
            weightflag.On = app.weightflag;
            fraction.Text = app.fractionmax.ToString();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            var app = Application.Current as App;
            app.weightflag = weightflag.On;
            app.fractionmax = Convert.ToInt16( fraction.Text);
        }
    }
}
