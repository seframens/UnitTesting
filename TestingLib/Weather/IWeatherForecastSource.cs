using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingLib.Weather
{
    public interface IWeatherForecastSource
    {
        WeatherForecast GetForecast(DateTime date);
    }

}
