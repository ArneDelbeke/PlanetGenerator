using System;

namespace PlanetGenerator
{
    public class TemperatureGenerator
    {
        private readonly Random _rnd = new();

        private const decimal EarthMaxTemp = 56.7m;
        private const decimal EarthMinTemp = -89.2m;
        private const decimal EarthAvgTemp = 16m;

        public TemperatureRange GenerateTemperatureRange()
        {
            var minTemp = EarthMinTemp * _rnd.Next(750, 1750);
            var avgTemp = EarthAvgTemp * _rnd.Next(750, 1250);
            var maxTemp = EarthMaxTemp * _rnd.Next(750, 1750);

            var maxTemperature = _rnd.Next((int)avgTemp, (int)maxTemp);
            var minTemperature = _rnd.Next((int)minTemp, (int)avgTemp);

            return new TemperatureRange((float)minTemperature/1000, (float)maxTemperature/1000);
        }

        public float GenerateAverageTemperature(TemperatureRange tempRange)
        {
            var range = (decimal)tempRange.MaxTemperature - (decimal)tempRange.MinTemperature;

            if(tempRange.MinTemperature > 0)
                range = (decimal)tempRange.MaxTemperature + (decimal)tempRange.MinTemperature;

            var sum1 = ((range / 2) * _rnd.Next(50, 95)) / 100;
            var result = range - sum1;
           
            var minValue = ((decimal)tempRange.MaxTemperature - result) * 1000;
            var maxValue = ((decimal)tempRange.MinTemperature + result) * 1000;

            var average = _rnd.Next((int)minValue, (int)maxValue);

            return (float)average / 1000;
        }
    }
}
