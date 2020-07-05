// ***********************************************************************
// Assembly         : FishingDerby
// Author           : Bill Banks
// Created          : 04-26-2017
//
// Last Modified By : Bill Banks
// Last Modified On : 04-27-2017
// ***********************************************************************
// <copyright file="Winnersfrm.xaml.cs" company="Ourweb.net">
//     Copyright ©  2014
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
    /// Class Winnersfrm.
    /// </summary>
    /// <seealso cref="Xamarin.Forms.ContentPage" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Winnersfrm : ContentPage
    {
        /// <summary>
        /// The games
        /// </summary>
        private ObservableCollection<Game> games;
        /// <summary>
        /// The view games
        /// </summary>
        private ObservableCollection<ViewGame> viewGames;

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
        /// Initializes a new instance of the <see cref="Winnersfrm"/> class.
        /// </summary>
        public Winnersfrm()
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
            loadcategory();
            loadgames();
    
        }


        /// <summary>
        /// Loadcategories this instance.
        /// </summary>
         private async void loadcategory()
        {
            var temp = await conn.Table<Category>().ToListAsync();

            categories = new ObservableCollection<Category>(from i in temp orderby i.catname select i);



        }

        /// <summary>
        /// Loadplayerses this instance.
        /// </summary>
         private async void loadplayers()
        {
            var temp = await conn.Table<Player>().ToListAsync();

            players = new ObservableCollection<Player>(from p in temp orderby p.lname, p.fname select p);
           
        }

        /// <summary>
        /// Loadgameses this instance.
        /// </summary>
         private async void loadgames()
        {
            var temp = await conn.Table<Game>().ToListAsync();
            Debug.WriteLine(temp);
            games = new ObservableCollection<Game>(from p in temp orderby p.catid, p.lenth descending , p.fraction descending , p.time select p); //sort the winners
            Debug.WriteLine(games.Count);


            if (games.Count > 0)
            {
                displayview();
            }
        }

        /// <summary>
        /// Displayviews this instance.
        /// </summary>
        private void displayview()
        {
            viewGames = new ObservableCollection<ViewGame>();
            var app = Application.Current as App;

           var fraction = app.fractionmax;


            foreach (var game in games)
            {
                var cid = game.catid;

                var pid = game.pid;

                var work = new ViewGame();

                work.Time = game.time;
                var cat = categories.Single(cm => cm.catid == cid).catname;
                work.category = cat;
                work.player = players.Single(p => p.pid == pid).ToString();

                work.lenght = Convert.ToString(game.lenth) + " " + Convert.ToString(game.fraction) + "/" +
                              fraction.ToString() + " ";

                viewGames.Add(work);

            }
            winnerListView.ItemsSource = viewGames;

        }
    }
}
