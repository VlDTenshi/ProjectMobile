using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static System.Net.WebRequestMethods;

namespace Project
{
    public partial class MainPage : ContentPage
    {
        const string API = "7a1e82109b389955967ad299cc91f8ff";
        public MainPage()
        {
            InitializeComponent();
            ToolbarItems.Add(new ToolbarItem("Back", null, async () => await Navigation.PopAsync()));
        }

        private async void getData_Clicked(object sender, EventArgs e)
        {
            string city = anyInput.Text.Trim();
            if(city.Length < 2)
            {
                await DisplayAlert("Error", "The name of city can not be less than 2 signs", "Close");
                return;
            }
            HttpClient client = new HttpClient();
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={API}&units=metric";
            string response = await client.GetStringAsync(url);

            var json = JObject.Parse(response);
            //string temp = json["main"]["temp"].ToString();
            //viewResult.Text = "Weather now:" + temp;
            if (json["cod"].ToString() != "200")
            {
                // Если код не 200, что-то пошло не так
                string errorMessage = json["message"].ToString();
                await DisplayAlert("Error", $"Error from OpenWeatherMap API: {errorMessage}", "Close");
                return;
            }

            double temp = double.Parse(json["main"]["temp"].ToString());
            string weatherDescription = json["weather"][0]["description"].ToString();
            double windSpeed = double.Parse(json["wind"]["speed"].ToString());
            int humidity = int.Parse(json["main"]["humidity"].ToString());
            int clouds = int.Parse(json["clouds"]["all"].ToString());

            string resultText = $"Temperature: {temp}°C\nWeather: {weatherDescription}\nWind Speed: {windSpeed} m/s\nHumidity: {humidity}%\nCloudiness: {clouds}%";
            viewResult.Text = resultText;
        }
    }
}
