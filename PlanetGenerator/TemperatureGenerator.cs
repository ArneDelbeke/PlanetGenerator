using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetGenerator
{
    public class TemperatureGenerator
    {
        private readonly Random rnd = new Random();
       
        private decimal earthMaxTemp = 56.7m;
        private decimal earthMinTemp = -89.2m;
        private decimal earthAvgTemp = 16m;

        public TemperatureRange GenerateTemperatureRange()
        {
            decimal minTemp = earthMinTemp * rnd.Next(750, 1750);
            decimal avgTemp = earthAvgTemp * rnd.Next(750, 1250);
            decimal maxTemp = earthMaxTemp * rnd.Next(750, 1250);

            var maxTemperature = rnd.Next((int)avgTemp, (int)maxTemp);
            var minTemperature = rnd.Next((int)minTemp, (int)avgTemp);

            return new TemperatureRange((float)minTemperature/1000, (float)maxTemperature/1000);
        }

        public float GenerateAverageTemperature(TemperatureRange tempRange)
        {
            decimal range = (decimal)tempRange.MaxTemperature - (decimal)tempRange.MinTemperature;

            if(tempRange.MinTemperature > 0)
                range = (decimal)tempRange.MaxTemperature + (decimal)tempRange.MinTemperature;

            var sum1 = ((range / 2) * rnd.Next(50, 95)) / 100;
            var result = range - sum1;
           
            decimal minValue = ((decimal)tempRange.MaxTemperature - result) * 1000;
            decimal maxValue = ((decimal)tempRange.MinTemperature + result) * 1000;

            var average = rnd.Next((int)minValue, (int)maxValue);

            return (float)average / 1000;
        }
    }
}
