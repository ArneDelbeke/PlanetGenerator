using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

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
            var planetType = PlanetTypeSelector();
            var radius = _sizeGenerator.GeneratePlanetRadius();
            var size = _sizeGenerator.PlanetSize(radius);

            var lengthOfDay = _timeSpanGenerator.LengthOfDay();
            var lengthOfYear = _timeSpanGenerator.LengthOfYear();
            var localDaysInYear = _timeSpanGenerator.LengthOfYearInLocalDays(lengthOfDay.TotalHours, lengthOfYear.TotalHours);

            var tempRange = _tempGenerator.GenerateTemperatureRange();
            var avgTemp = _tempGenerator.GenerateAverageTemperature(tempRange);

            var waterPrevelance = _waterGenerator.GenerateWaterPrevelance();

            var planet = new Planet
            {   
                Name = "Planet", 
                PlanetType = planetType, 
                Moons = null, 
                PlanetColors = new Color[1],
                Size = size,
                Radius = radius,
                TemperatureRange = tempRange,
                AverageTemperature = avgTemp,
                WaterPrevelance = waterPrevelance,
                IsLifeSupporting = true,
                LengthOfDay = lengthOfDay,
                LengthOfYear = lengthOfYear,
                LocalDaysInYear = localDaysInYear
            };

            return planet;
        }

        private static PlanetType PlanetTypeSelector()
        {
            var rnd = new Random();
            var enumLength = Enum.GetNames(typeof(PlanetType)).Length;
            var randomPlanetSelector = rnd.Next(enumLength);

            var planetType = randomPlanetSelector switch
            {
                0 => PlanetType.Desert,
                1 => PlanetType.Earthlike,
                2 => PlanetType.Frozen,
                3 => PlanetType.GassGiant,
                4 => PlanetType.Humid,
                5 => PlanetType.IceGiant,
                6 => PlanetType.Ocean,
                7 => PlanetType.Rocky,
                8 => PlanetType.RockyFurnace,
                _ => PlanetType.Earthlike
            };
                
            return planetType;
        }
    }
}
