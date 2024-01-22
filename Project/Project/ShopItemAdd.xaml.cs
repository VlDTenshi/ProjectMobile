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
	public partial class ShopItemAdd : ContentPage
	{
		public ShopItemAdd ()
		{
			InitializeComponent ();
            ToolbarItems.Add(new ToolbarItem("Back", null, async () => await Navigation.PopAsync()));
        }
        private async void AddItemButton(object sender, EventArgs e)
        {
            string title = titleField.Text.Trim();
            string desc = descField.Text.Trim();
            string image = imageField.Text.Trim();
            int price = Convert.ToInt32(priceField.Text.Trim());
            if (title.Length < 5)
            {
                await DisplayAlert("Error", "Title min 5", "Close");
                return;
            }
            else if (desc.Length < 10)
            {
                await DisplayAlert("Error", "Desc min 10", "Close");
                return;
            }
            else if (image.Length < 15)
            {
                await DisplayAlert("Error", "Image min 10", "Close");
                return;
            }
            else if (price < 20)
            {
                await DisplayAlert("Error", "Price min 20", "Close");
                return;
            }
            Item item = new Item
            {
                Title = title,
                Desc = desc,
                Image = image,
                Price = price,
            };
            App.Db.SaveItem(item);
            
            titleField.Text = "";
            descField.Text = "";
            imageField.Text = "";
            priceField.Text = "";
        }
        private bool isPasting = false;
        private void imageField_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (isPasting)
            {
                isPasting = false;
                // Ваш код обработки вставленного текста (например, валидация URL)
                string pastedText = e.NewTextValue;
                if (!IsValidUrl(pastedText))
                {
                    DisplayAlert("Error", "Invalid Image URL", "Close");
                    // Можно также отменить вставку
                    // imageField.Text = e.OldTextValue;
                }
            }
        }

        private bool IsValidUrl(string url)
        {
            Uri uriResult;
            bool result = Uri.TryCreate(url, UriKind.Absolute, out uriResult) &&
                          (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
            return result;
        }
    }
}