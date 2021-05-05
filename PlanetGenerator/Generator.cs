using System.Collections.Generic;
using System.Drawing;

namespace PlanetGenerator
{
    public class Generator
    {
        private readonly SizeGenerator _sizeGenerator;
        private readonly TimeSpanGenerator _timeSpanGenerator;
        private readonly TemperatureGenerator _tempGenerator;
        private readonly WaterPrevelanceGenerator _waterGenerator;

        public Generator(SizeGenerator sizeGenerator, TimeSpanGenerator timeSpanGenerator, TemperatureGenerator tempGenerator,
            WaterPrevelanceGenerator waterGenerator)
        {
            _sizeGenerator = sizeGenerator;
            _timeSpanGenerator = timeSpanGenerator;
            _tempGenerator = tempGenerator;
            _waterGenerator = waterGenerator;
        }

        public Planet GeneratePlanet()
        {

            var radius = _sizeGenerator.GeneratePlanetRadius();
            var size = _sizeGenerator.PlanetSize(radius);

            var lengthOfDay = _timeSpanGenerator.LengthOfDay();
            var lengthOfYear = _timeSpanGenerator.LengthOfYear();
            var localDaysInYear = _timeSpanGenerator.LengthOfYearInLocalDays(lengthOfDay.TotalHours, lengthOfYear.TotalHours);

            var tempRange = _tempGenerator.GenerateTemperatureRange();
            var waterPrevelance = _waterGenerator.GenerateWaterPrevelance();

            var planet = new Planet
            {   
                Name = "Planet", 
                PlanetType = PlanetType.Earth, 
                Moons = null, 
                PlanetColors = new Color[1],
                Size = size,
                Radius = radius,
                TemperatureRange = tempRange,
                AverageTemperature = 0,
                WaterPrevelance = waterPrevelance,
                IsLifeSupporting = true,
                LengthOfDay = lengthOfDay,
                LengthOfYear = lengthOfYear,
                LocalDaysInYear = localDaysInYear
            };

            return planet;
        }

    }
}
