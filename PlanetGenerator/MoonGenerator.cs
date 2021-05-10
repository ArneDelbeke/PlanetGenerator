using System;
using System.Linq;

namespace PlanetGenerator
{
    public class MoonGenerator
    {
        private static readonly int[] PlanetMoonsArr = {0, 0, 1, 2, 79, 62, 27, 14};

        public int GenerateMoons()
        {
            var random = new Random();

            var avgMoons = PlanetMoonsArr.AsQueryable().Average();
            var moonMedian = GetMoonsMedian(PlanetMoonsArr);
            var maxValue = PlanetMoonsArr.Max() + avgMoons;
            var probability = random.Next(0, 6);
            var totMoons = probability switch
            {
                0 
                    => 0,
                1 or 2 or 3
                    => random.Next(1, (int)moonMedian),
                4 or 5
                    => random.Next((int)moonMedian, (int)maxValue),
                _ => throw new NotImplementedException()
            };

            return totMoons;
        }

        public static decimal GetMoonsMedian(int[] arr)
        {
            Array.Sort(arr);
            var count = arr.Length;

            if (count % 2 == 0)
            {
                var a = arr[count / 2 - 1];
                var b = arr[count / 2];
                return (a + b) / 2m;
            }
            return arr[count / 2];
        }
    }
}
