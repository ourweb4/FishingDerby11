// ***********************************************************************
// Assembly         : FishingDerby
// Author           : Bill Banks
// Created          : 04-22-2017
//
// Last Modified By : Bill Banks
// Last Modified On : 04-27-2017
// ***********************************************************************
// <copyright file="MainPage.xaml.cs" company="Ourweb.net">
//     Copyright ©  2014
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FishingDerby.Forms;
using Xamarin.Forms;
using SQLite;
using  FishingDerby.Models;

namespace FishingDerby
{
    /// <summary>
    /// Class MainPage.
    /// </summary>
    /// <seealso cref="Xamarin.Forms.ContentPage" />
    public partial class MainPage : ContentPage
    {
        public string version;
        /// <summary>
        /// The connection
        /// </summary>
        private SQLiteAsyncConnection conn;
        /// <summary>
        /// Initializes a new instance of the <see cref="MainPage"/> class.
        /// </summary>
        public MainPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// When overridden, allows application developers to customize behavior immediately prior to the <see cref="T:Xamarin.Forms.Page" /> becoming visible.
        /// </summary>
        /// <remarks>To be added.</remarks>
        protected override void OnAppearing()
        {
            base.OnAppearing();
            var app = Application.Current as App;
            version = app.Version;
            vlabel.Text = version;
            setupdb();
        }

        /// <summary>
        /// Setupdbs this instance.
        /// </summary>
        private async void setupdb()
        {
             conn = DependencyService.Get<ISQLiteDb>().GetConnection();
            await conn.CreateTableAsync<Category>();
            await conn.CreateTableAsync<Player>();
           await conn.CreateTableAsync<Game>();
        }



        /// <summary>
        /// Handles the OnClicked event of the Category control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
         private void Category_OnClicked(object sender, EventArgs e)
        {
           Navigation.PushAsync(new Categoryfrm());
        }

        /// <summary>
        /// Handles the OnClicked event of the Player control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        async private void Player_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Players1frm());
        }

        /// <summary>
        /// Handles the OnClicked event of the Game control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        async private void Game_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Gameentryfrm());
        }

        /// <summary>
        /// Handles the OnClicked event of the Winner control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        async private void Winner_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Winnersfrm());
        }

        /// <summary>
        /// Handles the OnClicked event of the Reset control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
         private void Reset_OnClicked(object sender, EventArgs e)
      {
           Navigation.PushAsync(new Resetfrm());
      }

        /// <summary>
        /// Handles the OnClicked event of the Settings control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        async private void Settings_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Settingsfrm());
        }
    }
}
