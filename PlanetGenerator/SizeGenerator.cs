using System;
using System.Linq;
using System.Runtime.ConstrainedExecution;

namespace PlanetGenerator
{
    public class SizeGenerator
    {
        private const int EarthRadius = 6371;
        private static readonly int[] PlanetRadiusArr = { 950, 2370, 1300, 1900, 2326, 2440, 3390, 6052, 6371, 24622, 25362, 58232, 69911 };
        private readonly Random rnd = new Random();

        public int GeneratePlanetRadius()
        {
            var avgRadius = Queryable.Average(PlanetRadiusArr.AsQueryable());

            var minValue = PlanetRadiusArr.Min();
            var maxValue = PlanetRadiusArr.Max() + (avgRadius / 2);
            int probability = rnd.Next(0, 3);
            int radius = probability switch
            {
                0 or 1
                => rnd.Next((int)minValue, (int)avgRadius),
                2
                => rnd.Next((int)avgRadius, (int)maxValue),
                _ => throw new NotImplementedException()
            };

            return radius;
        }

        public float PlanetSize(int radius)
        {
            return (float)Math.Round(radius / (float)EarthRadius, 2);
        }
    }
}
