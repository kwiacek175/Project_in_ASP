using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Pages.Alcohols
{
    public class IndexModel : PageModel
    {
        private readonly WebApplication1Context _context;

        public IndexModel(WebApplication1Context context)
        {
            _context = context;
        }

        public IList<Alcohol> Alcohol { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            string currencyRateEUR = await ShowCurRate("EUR");
            ViewData["CurrencyRateEUR"] = currencyRateEUR;
            string currencyRateUSD = await ShowCurRate("USD");
            ViewData["CurrencyRateUSD"] = currencyRateUSD;
            string currencyRateCHF = await ShowCurRate("CHF");
            ViewData["CurrencyRateCHF"] = currencyRateCHF;
            string currencyRateGBP = await ShowCurRate("GBP");
            ViewData["CurrencyRateGBP"] = currencyRateGBP;

            string weather = await downloadWeather("Wroclaw");
            ViewData["WeatherFarenheight"] = weather;
            double w = (Convert.ToDouble(weather)-32)*0.55;
            string weath = string.Format("{0:0}", w);
            ViewData["WeatherCelsi"] = weath;

            Alcohol = await _context.Alcohol.ToListAsync();

            return Page();
        }

        private async Task<string> downloadData(string code)
        {
            string table = "A";
            HttpClient client = new HttpClient();
            string call = "http://api.nbp.pl/api/exchangerates/rates/" + table + "/" + code + "/?format=json";
            string json = await client.GetStringAsync(call);
            return json;
        }

        private async Task<string> ShowCurRate(string code)
        {
            string json = await downloadData(code);
            Currency cur = JsonConvert.DeserializeObject<Currency>(json);
            string m = string.Empty;
            m = cur.rates[0].mid.ToString();
            return m;
        }
          
        private async Task<string> downloadWeather(string cityName)
        {
            HttpClient client = new HttpClient();
            var apiKey = "77ddc5807aff734585b8bee62e50275b";
            var openWeatherURL = $"https://api.openweathermap.org/data/2.5/weather?q={cityName}&appid={apiKey}&units=imperial";
            var Report = client.GetStringAsync(openWeatherURL).Result;
            var Temp = JObject.Parse(Report)["main"]["temp"].ToString();
            return Temp;
        }
    }
}
