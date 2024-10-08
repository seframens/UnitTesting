using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingLib.Weather
{
    public class WeatherForecastService
    {
        private readonly IWeatherForecastSource _weatherForecastSource;

        public WeatherForecastService(IWeatherForecastSource weatherForecastSource)
        {
            _weatherForecastSource = weatherForecastSource;
        }

        public WeatherForecast GetWeatherForecast(DateTime date)
        {
            return _weatherForecastSource.GetForecast(date);
        }
    }
}
