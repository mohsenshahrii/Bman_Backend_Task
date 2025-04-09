using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherEventSystem
{
    public class WeatherStationPub
    {
        private readonly EventManager _eventManager;

        public WeatherStationPub(EventManager eventManager)
        {
            _eventManager = eventManager;
        }

        public void UpdateWeather(string newCondition)
        {
            Console.WriteLine($"Weather Station: Weather changed to {newCondition}");
            _eventManager.NotifySubscribers(newCondition);
        }
    }

}
