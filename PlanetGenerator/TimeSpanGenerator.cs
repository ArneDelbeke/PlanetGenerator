using System;
using System.Linq;

namespace PlanetGenerator
{
    public class TimeSpanGenerator
    {
        private static readonly int[] PlanetMinutesInDayArr = { 84960, 349920, 1436, 1459, 595, 639, 1034, 967, 545, 369, 240, 466, 480 };
        private static readonly double[] PlanetHoursInYearArr = { 2112, 5376, 8766, 103893, 254040, 735840, 1443648, 40320, 2172480, 2496600, 2706840, 4879320 };
        private const int HoursInEarthYear = 8766;
        private readonly Random _rnd = new();

        public TimeSpan LengthOfDay()
        {
            var avgMinutesInDay = PlanetMinutesInDayArr.AsQueryable().Average();
            var minValue = PlanetMinutesInDayArr.Min();
            var maxValue = PlanetMinutesInDayArr.Max();

            var probability = _rnd.Next(0, 3);
            var minutes = probability switch
            {
                0 or 1
                => _rnd.Next((minValue / 2), (int)avgMinutesInDay),
                2
                => _rnd.Next((int)avgMinutesInDay, maxValue),
                _ => throw new NotImplementedException()
            };

            return TimeSpan.FromMinutes(minutes);
        }
        public TimeSpan LengthOfYear()
        {
            var avgHoursInDay = PlanetHoursInYearArr.AsQueryable().Average();
            var minValue = PlanetHoursInYearArr.Min();
            var maxValue = PlanetHoursInYearArr.Max();

            var probability = _rnd.Next(0, 10);

            var hours = probability switch
            {
                1 or 2 or 3 or 4 or 5 or 6 or 7 or 8
                => _rnd.Next((int)minValue/2, HoursInEarthYear*5),
                9
                => _rnd.Next((int)avgHoursInDay, (int)maxValue),
                _ => _rnd.Next((int)minValue, (int)avgHoursInDay)
            };

            return TimeSpan.FromHours(hours);
        }

        public virtual double LengthOfYearInLocalDays(double hoursInDay, double hoursInYear)
        {
            return Math.Round(hoursInYear / hoursInDay, 2);
        }

    }
}
