// ***********************************************************************
// Assembly         : FishingDerby
// Author           : Bill Banks
// Created          : 04-27-2017
//
// Last Modified By : Bill Banks
// Last Modified On : 04-27-2017
// ***********************************************************************
// <copyright file="Resetfrm.xaml.cs" company="Ourweb.net">
//     Copyright ©  2014
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FishingDerby.Models;
using FishingDerby.Utiltys;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FishingDerby.Forms
{
    /// <summary>
    /// Class Resetfrm.
    /// </summary>
    /// <seealso cref="Xamarin.Forms.ContentPage" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Resetfrm : ContentPage
    {
        /// <summary>
        /// The connection
        /// </summary>
        private SQLiteAsyncConnection conn;
        private Messagebox mbox = new Messagebox();
        /// <summary>
        /// Initializes a new instance of the <see cref="Resetfrm"/> class.
        /// </summary>
        public Resetfrm()
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
        }

 
        /// <summary>
        /// Handles the OnClicked event of the Reset control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        async private void Reset_OnClicked(object sender, EventArgs e)
        {
            
                if (catsw.On)
                {
                    var recs = await conn.Table<Category>().ToListAsync();
                    foreach (var rec in recs)
                    {
                        await conn.DeleteAsync(rec);
                    }
                }
                if (gamesw.On)
                {
                    var recs = await conn.Table<Game>().ToListAsync();
                    foreach (var rec in recs)
                    {
                        await conn.DeleteAsync(rec);
                    }
                }
                if (playersw.On)
                {
                    var recs = await conn.Table<Player>().ToListAsync();
                    foreach (var rec in recs)
                    {
                        await conn.DeleteAsync(rec);
                    }
               }
            
            await Navigation.PopToRootAsync();
        }
    }
}
