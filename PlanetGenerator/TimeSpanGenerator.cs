using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetGenerator
{
    public class TimeSpanGenerator
    {
        private static readonly int[] PlanetMinutesInDayArr = { 84960, 349920, 1436, 1459, 595, 639, 1034, 967, 545, 369, 240, 466, 480 };
        private static readonly double[] PlanetHoursInYearArr = { 2112, 5376, 8766, 103893, 254040, 735840, 1443648, 40320, 2172480, 2496600, 2706840, 4879320 };
        private static int HoursInEarthYear = 8766;
        private readonly Random rnd = new Random();

        public TimeSpan LengthOfDay()
        {
            var avgMinutesInDay = Queryable.Average(PlanetMinutesInDayArr.AsQueryable());
            var minValue = PlanetMinutesInDayArr.Min();
            var maxValue = PlanetMinutesInDayArr.Max();

            int probability = rnd.Next(0, 3);
            int minutes = probability switch
            {
                0 or 1
                => rnd.Next((minValue / 2), (int)avgMinutesInDay),
                2
                => rnd.Next((int)avgMinutesInDay, maxValue),
                _ => throw new NotImplementedException()
            };

            return TimeSpan.FromMinutes(minutes);
        }
        public TimeSpan LenghtOfYear()
        {
            var avgHoursInDay = Queryable.Average(PlanetHoursInYearArr.AsQueryable());
            var minValue = PlanetHoursInYearArr.Min();
            var maxValue = PlanetHoursInYearArr.Max();

            int probability = rnd.Next(0, 10);

            var hours = probability switch
            {
                1 or 2 or 3 or 4 or 5 or 6 or 7 or 8
                => rnd.Next((int)minValue/2, HoursInEarthYear*5),
                9
                => rnd.Next((int)avgHoursInDay, (int)maxValue),
                _ => rnd.Next((int)minValue, (int)avgHoursInDay)
            };

            return TimeSpan.FromHours(hours);
        }

        public double LengthOfYearInLocalDays(double HoursInDay, double HoursInYear)
        {
            return Math.Round(HoursInYear / HoursInDay, 2);
        }

    }
}
