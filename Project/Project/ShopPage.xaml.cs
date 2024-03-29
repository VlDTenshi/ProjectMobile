﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ShopPage : ContentPage
	{
		public ShopPage ()
		{
			InitializeComponent ();
            ToolbarItems.Add(new ToolbarItem("Back", null, async () => await Navigation.PopAsync()));
            
        }
        protected override void OnAppearing()
        {
            ShowItems();
        }
		private void ShowItems()
		{
			itemsCollection.ItemsSource = App.Db.GetItems();
		}
        private async void AddItemButton(object sender, EventArgs e)
        {
			await Navigation.PushAsync(new ShopItemAdd());
        }

        private void OnItemSelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null && e.CurrentSelection.Count > 0)
            {
                Item selectedItem = (Item)e.CurrentSelection.FirstOrDefault();
                Navigation.PushAsync(new ItemDetailPage(selectedItem));
                ((CollectionView)sender).SelectedItem = null; // Сбросить выбор после обработки
            }
        }
    }
}