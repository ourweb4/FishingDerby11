// ***********************************************************************
// Assembly         : FishingDerby
// Author           : Bill Banks
// Created          : 05-03-2017
//
// Last Modified By : Bill Banks
// Last Modified On : 05-03-2017
// ***********************************************************************
// <copyright file="Players1frm.xaml.cs" company="Ourweb.net">
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
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FishingDerby.Forms
{
    /// <summary>
    /// Class Players1frm.
    /// </summary>
    /// <seealso cref="Xamarin.Forms.ContentPage" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Players1frm : ContentPage
    {
        /// <summary>
        /// The connection
        /// </summary>
        private SQLiteAsyncConnection conn;

        /// <summary>
        /// The players
        /// </summary>
        private ObservableCollection<Player> players;
        /// <summary>
        /// Initializes a new instance of the <see cref="Players1frm"/> class.
        /// </summary>
        public Players1frm()
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
           
            loadplayers();

        }

        /// <summary>
        /// Loadplayerses this instance.
        /// </summary>
        private async void loadplayers()
        {
            var temp = await conn.Table<Player>().ToListAsync();

            players = new ObservableCollection<Player>(from p in temp orderby p.lname, p.fname select p);
            PlayerListView.ItemsSource = players;
        }

        /// <summary>
        /// Handles the OnClicked event of the Add control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void Add_OnClicked(object sender, EventArgs e)
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

        /// <summary>
        /// Handles the OnClicked event of the Delete control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void Delete_OnClicked(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var player = menuItem.CommandParameter as Player;

            await conn.DeleteAsync(player);
            var pid = player.pid;
            loadplayers();

        }
    }
}
