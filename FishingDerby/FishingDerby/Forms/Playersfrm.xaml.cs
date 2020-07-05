// ***********************************************************************
// Assembly         : FishingDerby
// Author           : Bill Banks
// Created          : 04-08-2017
//
// Last Modified By : Bill Banks
// Last Modified On : 04-11-2017
// ***********************************************************************
// <copyright file="Playersfrm.xaml.cs" company="Ourweb.net">
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
using FishingDerby.Utiltys;
using Xamarin.Forms;
using SQLite;

namespace FishingDerby.Forms
{
    /// <summary>
    /// Class Playersfrm.
    /// </summary>
    /// <seealso cref="Xamarin.Forms.ContentPage" />
    public partial class Playersfrm : ContentPage
    {
        /// <summary>
        /// The connection
        /// </summary>
        private SQLiteAsyncConnection conn;


        private Messagebox Deletebox = new Messagebox();

        /// <summary>
        /// The players
        /// </summary>
        private ObservableCollection<Player> players;
        /// <summary>
        /// Initializes a new instance of the <see cref="Playersfrm"/> class.
        /// </summary>
        public Playersfrm()
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
            conn = DependencyService.Get<ISQLiteDb>().GetConnection();
            Deletebox.message="Delete?";
            loadplayers();

        }

        /// <summary>
        /// Loadplayerses this instance.
        /// </summary>
         private async void loadplayers()
        {
            var temp = await conn.Table<Player>().ToListAsync();

            players = new ObservableCollection<Player>(from p in temp orderby p.lname select p);
            playersListView.ItemsSource = players;
        }
        

        /// <summary>
        /// Addns the clicked.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
         private async void AddnClicked(object sender, EventArgs e)
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
        
        private async void  Delete_OnClicked(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var player = menuItem.CommandParameter as Player;

            await conn.DeleteAsync(player);
            var pid = player.pid;
            loadplayers();
            
        }
    }
}
