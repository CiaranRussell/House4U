using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TemperatureConverter.Models
{
    public class Temperature
    {
        public static double ConvertCelsiusToFahrenheit(double celsius)
        {
            return (((9.0 / 5.0) * celsius) + 32);
        }
    }
}