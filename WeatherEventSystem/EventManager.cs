using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherEventSystem
{
    // define event delegate
    public delegate void WeatherUpdateHandler(string weatherCondition);

    public class EventManager
    {
        private readonly Dictionary<string, WeatherUpdateHandler> _subscribers;

        public EventManager()
        {
            _subscribers = new Dictionary<string, WeatherUpdateHandler>();
        }

        public void Subscribe(string subscriberId, WeatherUpdateHandler handler)
        {
            if (!_subscribers.ContainsKey(subscriberId))
            {
                _subscribers[subscriberId] = handler;
                Console.WriteLine($"{subscriberId} subscribed to weather updates.");
            }
            else
            {
                _subscribers[subscriberId] += handler;
            }
        }

        public void Unsubscribe(string subscriberId)
        {
            if (_subscribers.ContainsKey(subscriberId))
            {
                _subscribers.Remove(subscriberId);
                Console.WriteLine($"{subscriberId} unsubscribed from weather updates.");
            }
        }

        public void NotifySubscribers(string weatherCondition)
        {
            foreach (var subscriber in _subscribers)
            {
                subscriber.Value?.Invoke(weatherCondition);
            }
        }
    }
}
