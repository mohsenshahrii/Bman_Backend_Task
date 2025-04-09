using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherEventSystem
{
    public class WeatherAppSub
    {
        private readonly string _appId;

        public WeatherAppSub(string appId)
        {
            _appId = appId;
        }

        public void OnWeatherUpdate(string weatherCondition)
        {
            Console.WriteLine($"{_appId} received update: Weather is now {weatherCondition}");
        }

        public string Id => _appId;
    }
}
