// ***********************************************************************
// Assembly         : FishingDerby
// Author           : Bill Banks
// Created          : 04-22-2017
//
// Last Modified By : Bill Banks
// Last Modified On : 04-22-2017
// ***********************************************************************
// <copyright file="Gameentryfrm.xaml.cs" company="Ourweb.net">
//     Copyright ©  2014
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FishingDerby.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using  SQLite;

namespace FishingDerby.Forms
{
    /// <summary>
    /// Class Gameentryfrm.
    /// </summary>
    /// <seealso cref="Xamarin.Forms.ContentPage" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Gameentryfrm : ContentPage
    {
        /// <summary>
        /// The categories
        /// </summary>
        private ObservableCollection<Category> categories;
        /// <summary>
        /// The players
        /// </summary>
        private ObservableCollection<Player> players;
        /// <summary>
        /// The connection
        /// </summary>
        private SQLiteAsyncConnection conn;
        /// <summary>
        /// The weightflag
        /// </summary>
        public bool weightflag;
        /// <summary>
        /// The inchesflag
        /// </summary>
        public bool inchesflag;
        /// <summary>
        /// The fraction
        /// </summary>
        private int fraction;
        /// <summary>
        /// The gameentry
        /// </summary>
        private Game gameentry;

        /// <summary>
        /// Initializes a new instance of the <see cref="Gameentryfrm"/> class.
        /// </summary>
        public Gameentryfrm()
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
            weightflag = app.weightflag;
            inchesflag = weightflag == false;
            fraction = app.fractionmax;
         resetgame();

            conn = DependencyService.Get<ISQLiteDb>().GetConnection();
            loadplayers();
            loadcategory();
        }

        /// <summary>
        /// Resetgames this instance.
        /// </summary>
        private void resetgame()
        {
            gameentry = new Game();
            gameentry.gid = 0;
            gameentry.pid = 0;
            gameentry.catid = 0;
            gameentry.fraction = 0;
            gameentry.lenth = 0;
            gameentry.notes = " ";
            gameentry.weight = 0;
   
            for (int i = 0; i < fraction - 1; i++)
            {
                FractionPicker.Items.Add(i.ToString());
            }
        }

        /// <summary>
        /// Loadcategories this instance.
        /// </summary>
         private async void loadcategory()
        {
            var temp = await conn.Table<Category>().ToListAsync();

            categories = new ObservableCollection<Category>(from i in temp orderby i.catname select i);

            CategoryPicker.ItemsSource = categories;

        }

        /// <summary>
        /// Loadplayerses this instance.
        /// </summary>
         private async void loadplayers()
        {
            var temp = await conn.Table<Player>().ToListAsync();

            players = new ObservableCollection<Player>(from p in temp orderby p.lname, p.fname select p);
         PlayersListView.ItemsSource = players;
        }

        /// <summary>
        /// Handles the OnItemTapped event of the PlayersListView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ItemTappedEventArgs"/> instance containing the event data.</param>
        private void PlayersListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var player = e.Item as Player;
            gameentry.pid = player.pid;
            vname.Text = player.ToString();
        }

        /// <summary>
        /// Handles the OnItemSelected event of the PlayersListView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SelectedItemChangedEventArgs"/> instance containing the event data.</param>
        private void PlayersListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var player = e.SelectedItem as Player;
            gameentry.pid = player.pid;
            vname.Text = player.ToString();
        }

        /// <summary>
        /// Handles the OnSelectedIndexChanged event of the CategoryPicker control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void CategoryPicker_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            var catnamwe = CategoryPicker.Items[CategoryPicker.SelectedIndex];
            var cat = categories.Single(ca => ca.catname == catnamwe);
            gameentry.catid = cat.catid;
        }

        /// <summary>
        /// Handles the OnSelectedIndexChanged event of the FractionPicker control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FractionPicker_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            var frac = FractionPicker.Items[FractionPicker.SelectedIndex];
            gameentry.fraction = Convert.ToInt16(frac);
        }

        /// <summary>
        /// Handles the OnClicked event of the Add control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
         private async void Add_OnClicked(object sender, EventArgs e)
        {
            gameentry.lenth = Convert.ToInt16(einches.Text);
            gameentry.time = DateTime.Now;
            if (gameentry.pid != 0 && gameentry.catid != 0)
            {

                await conn.InsertAsync(gameentry);

                await Navigation.PopToRootAsync();
            }
            else
            {
           await     DisplayAlert("Error", "Input error", "Ok");
            }
        }

        /// <summary>
        /// Handles the OnClicked event of the AddPlayer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        async private void AddPlayer_OnClicked(object sender, EventArgs e)
        {
            var ifname = efname.Text;
            var ilame = elname.Text;

            if (ifname != "" && ilame != "")
            {
                var addplayer = new Player(

                );
                addplayer.fname = ifname;
                addplayer.lname = ilame;
                await conn.InsertAsync(addplayer);
                efname.Text = "";
                elname.Text = "";
                loadplayers();
            }
        }

    }

}

