using System;
using System.Diagnostics.CodeAnalysis;

namespace PlanetGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            SizeGenerator sizeGenerator = new SizeGenerator();
            TimeSpanGenerator timeSpanGenerator = new TimeSpanGenerator();

            Generator generator = new Generator(sizeGenerator, timeSpanGenerator);

            RefreshPlanet(generator);

            while (Console.ReadKey().Key == ConsoleKey.Spacebar)
            {
                RefreshPlanet(generator);
            }
        }

        static void RefreshPlanet(Generator generator)
        {
            Console.Clear();
            Console.WriteLine("Press SPACEBAR to generate a new planet \n");
            var planet = GeneratePlanet(generator);
            ShowPlanetInfo(planet);
        }

        private static void ShowPlanetInfo(Planet planet)
        {
            Console.WriteLine($"Radius: {planet.Radius} km");
            Console.WriteLine($"Size: {planet.Size} x Earth");
            Console.WriteLine($"Duration of day: {Math.Round(planet.LengthOfDay.TotalHours)} hours");
            Console.WriteLine($"Duration of year: {Math.Round(planet.LengthOfYear.TotalDays)} earth days");
            Console.WriteLine($"Duration of year in local days: {planet.LocalDaysInYear} {planet.Name} days");
        }

        private static Planet GeneratePlanet(Generator generator)
        {
            return generator.GeneratePlanet();
        }
    }
}
