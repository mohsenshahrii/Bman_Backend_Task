using System;
using System.Collections.Generic;

namespace WeatherEventSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var eventManager = new EventManager();

            var weatherStation = new WeatherStationPub(eventManager);

            var mobileApp = new WeatherAppSub("MobileApp");
            var localStation = new WeatherAppSub("LocalStation");

            eventManager.Subscribe(mobileApp.Id, mobileApp.OnWeatherUpdate);
            eventManager.Subscribe(localStation.Id, localStation.OnWeatherUpdate);

            weatherStation.UpdateWeather("Sunny");
            weatherStation.UpdateWeather("Rainy");

            eventManager.Unsubscribe(mobileApp.Id);

            weatherStation.UpdateWeather("Stormy");

            Console.ReadLine();
        }
    }
}