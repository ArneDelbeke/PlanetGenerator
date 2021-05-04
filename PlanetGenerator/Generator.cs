using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetGenerator
{
    public class Generator
    {
        private readonly SizeGenerator _sizeGenerator;
        private readonly TimeSpanGenerator _timeSpanGenator;

        public Generator(SizeGenerator sizeGenerator, TimeSpanGenerator timeSpanGenerator)
        {
            _sizeGenerator = sizeGenerator;
            _timeSpanGenator = timeSpanGenerator;
        }

        public Planet GeneratePlanet()
        {

            var radius = _sizeGenerator.GeneratePlanetRadius();
            var size = _sizeGenerator.PlanetSize(radius);

            var LenghtOfDay = _timeSpanGenator.LengthOfDay();
            var LenghtOfYear = _timeSpanGenator.LenghtOfYear();
            var LocalDaysInYear = _timeSpanGenator.LengthOfYearInLocalDays(LenghtOfDay.TotalHours, LenghtOfYear.TotalHours);

            var planet = new Planet
            {   
                Name = "Bitchplanet", 
                PlanetType = PlanetType.Earth, 
                Moons = null, 
                PlanetColors = new Color[1],
                Size = size,
                Radius = radius,
                TemperatureRange = new Dictionary<float, float>(0),
                AverageTemperature = 0,
                WaterPrevelance = new Dictionary<decimal, decimal>(0),
                IsLifeSupporting = true,
                LengthOfDay = LenghtOfDay,
                LengthOfYear = LenghtOfYear,
                LocalDaysInYear = LocalDaysInYear
            };

            return planet;
        }

    }
}
