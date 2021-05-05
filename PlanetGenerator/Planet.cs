using System;
using System.Collections.Generic;
using System.Drawing;

namespace PlanetGenerator
{
    public class Planet
    {
        public string Name { get; set; }
        public PlanetType PlanetType { get; set; }
        public ICollection<Moon>? Moons { get; set; }
        public Color[] PlanetColors { get; set; }
        public float Size { get; set; }
        public int Radius { get; set; }
        public TemperatureRange TemperatureRange { get; set; }
        public float AverageTemperature { get; set; }
        public WaterPrevelance WaterPrevelance { get; set; }
        public bool IsLifeSupporting { get; set; }
        public TimeSpan LengthOfDay { get; set; }
        public TimeSpan LengthOfYear { get; set; }
        public double LocalDaysInYear { get; set; }
    }
}
