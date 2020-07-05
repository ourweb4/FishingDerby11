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
    

    public partial class Categoryfrm : ContentPage
    {
        private SQLiteAsyncConnection conn;
        private Messagebox Deletebox = new Messagebox();

        private ObservableCollection<Category> categories;
        public Categoryfrm()
        {
            InitializeComponent();
        }

         protected override  void OnAppearing()

        {
            base.OnAppearing();
            conn = DependencyService.Get<ISQLiteDb>().GetConnection();
            loadcategory();
            Deletebox.message = "Delete?";
        }

        async private void loadcategory()
        {
            var temp = await conn.Table<Category>().ToListAsync();
            
            categories = new ObservableCollection<Category>(from i in temp orderby i.catname select i);

            catListView.ItemsSource = categories;

        }

        async private void Add_OnClicked(object sender, EventArgs e)
        {
            var fcatname = catname.Text;

            if (fcatname != "")
            {
                var category = new Category {
                    catname = fcatname

            };
               await conn.InsertAsync(category);
                catname.Text = "";
                loadcategory();


            }
        }

        protected async void CatListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
          var category = e.Item as Category;
            var res =  Deletebox.Result();
            if (res)
            {
              await  conn.DeleteAsync(category);

                loadcategory();
            }
        }


        private async void CatListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var category = e.SelectedItem as Category;
            var res = Deletebox.Result();
            if (res)
            {
                 await conn.DeleteAsync(category);

                loadcategory();
            }
        }

        private async void  Delete_OnClicked(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var category = menuItem.CommandParameter as Category;
            await conn.DeleteAsync(category);

            loadcategory();

        }
    }
}
