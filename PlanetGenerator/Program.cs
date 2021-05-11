using System;

namespace PlanetGenerator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var sizeGenerator = new SizeGenerator();
            var timeSpanGenerator = new TimeSpanGenerator();
            var tempGenerator = new TemperatureGenerator();
            var waterGenerator = new WaterPrevelanceGenerator();
            var moonGenerator = new MoonGenerator();

            var generator = new Generator(sizeGenerator, timeSpanGenerator, tempGenerator, moonGenerator, waterGenerator);
            
            RefreshPlanet(generator);

            while (Console.ReadKey().Key == ConsoleKey.Spacebar)
            {
                RefreshPlanet(generator);
            }
        }

        private static void RefreshPlanet(Generator generator)
        {
            Console.Clear();
            Console.WriteLine("Press SPACEBAR to generate a new planet \n");
            var planet = GeneratePlanet(generator);
            ShowPlanetInfo(planet);
        }

        private static void ShowPlanetInfo(Planet planet)
        {
            Console.WriteLine($"{planet.Name.ToUpper()}");
            Console.WriteLine("");
            Console.WriteLine($"Showing statistics for planet {planet.Name}, named after the {planet.NameDescription} \n");
            
            Console.WriteLine($"Type: {planet.PlanetType}");
            Console.WriteLine($"Radius: {planet.Radius} km");
            Console.WriteLine($"Size: {planet.Size} x Earth");
            Console.WriteLine($"Life supporting: {planet.IsLifeSupporting}");
            Console.WriteLine($"Number of moons: {planet.Moons}");
            Console.WriteLine($"Duration of day: {Math.Round(planet.LengthOfDay.TotalHours)} hours");
            Console.WriteLine($"Duration of year: {Math.Round(planet.LengthOfYear.TotalDays)} earth days");
            Console.WriteLine($"Duration of year in local days: {planet.LocalDaysInYear} {planet.Name} days");
            Console.WriteLine($"Water prevalence: {planet.WaterPrevelance.WaterPercentage} %");
            Console.WriteLine($"Freshwater: {planet.WaterPrevelance.FreshWater()}");
            Console.WriteLine($"Saltwater: {planet.WaterPrevelance.SaltWater()}");
            Console.WriteLine($"Surface water: {planet.WaterPrevelance.SurfaceWater()}");
            Console.WriteLine($"Subterranean water: {planet.WaterPrevelance.SubterraneanWater()}");
            Console.WriteLine($"Temperature range: {planet.TemperatureRange.MinTemperature} °C / {planet.TemperatureRange.MaxTemperature} °C");
            Console.WriteLine($"Average surface temperature: {planet.AverageTemperature} °C");
        }

        private static Planet GeneratePlanet(Generator generator)
        {
            return generator.GeneratePlanet();
        }
    }
}
