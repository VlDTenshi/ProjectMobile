using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ItemDetailPage : ContentPage
	{
		public ItemDetailPage (Item selectedItem)
		{
			InitializeComponent ();
            BindingContext = selectedItem;
            ToolbarItems.Add(new ToolbarItem("Back", null, async () => await Navigation.PopAsync()));
            
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            // Получите текущий элемент из BindingContext
            Item selectedItem = (Item)BindingContext;

            // Здесь вызывайте ваш метод удаления элемента
            App.Db.DeleteItem(selectedItem);

            // Вернуться назад после удаления
            await Navigation.PopAsync();
        }
    }
}