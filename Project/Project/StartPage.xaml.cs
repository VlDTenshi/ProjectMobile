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
    public partial class StartPage : ContentPage
    {
        List<ContentPage> pages = new List<ContentPage>() { new MainPage(), new ShopPage() };
        List<string> tekst = new List<string> { "Ava Weather leht", "Ava ShopPlace" };
        StackLayout st;
        public StartPage()
        {
            st = new StackLayout();
            {
                //Orientation = StackOrientation.Vertical,
                BackgroundColor = Color.YellowGreen;
            };
            for (int i = 0; i < pages.Count; i++)
            {
                Button button = new Button
                {
                    Text = tekst[i],
                    TabIndex = i,
                    BackgroundColor = Color.Bisque,
                    TextColor = Color.White,
                    FontFamily = "MyFont.ttf"
                };
                st.Children.Add(button);
                button.Clicked += Button_Clicked;
            }
            ScrollView sv = new ScrollView { Content = st };
            Content = sv;
            
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            await Navigation.PushAsync(pages[btn.TabIndex]);
        }
    }
}