using System;
using System.Linq;

namespace PlanetGenerator
{
    public class SizeGenerator
    {
        private const int EarthRadius = 6371;
        private static readonly int[] PlanetRadiusArr = { 950, 2370, 1300, 1900, 2326, 2440, 3390, 6052, 6371, 24622, 25362, 58232, 69911 };
        private readonly Random _rnd = new();

        public int GeneratePlanetRadius()
        {
            var avgRadius = PlanetRadiusArr.AsQueryable().Average();

            var minValue = PlanetRadiusArr.Min();
            var maxValue = PlanetRadiusArr.Max() + (avgRadius / 2);
            var probability = _rnd.Next(0, 3);
            var radius = probability switch
            {
                0 or 1
                => _rnd.Next(minValue, (int)avgRadius),
                2
                => _rnd.Next((int)avgRadius, (int)maxValue),
                _ => throw new NotImplementedException()
            };

            return radius;
        }

        public virtual float PlanetSize(int radius)
        {
            return (float)Math.Round(radius / (float)EarthRadius, 2);
        }
    }
}
