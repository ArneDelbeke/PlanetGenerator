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
        private Pantheons.Root root = new();

        public Generator(SizeGenerator sizeGenerator, TimeSpanGenerator timeSpanGenerator,
            TemperatureGenerator tempGenerator,
            WaterPrevelanceGenerator waterGenerator)
        {
            _sizeGenerator = sizeGenerator;
            _timeSpanGenerator = timeSpanGenerator;
            _tempGenerator = tempGenerator;
            _waterGenerator = waterGenerator;
        }

        public Planet GeneratePlanet()
        {
            LoadJson();
            var god = SelectGod();
            var name = $"{god.Name} - {god.Description}";

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
                Name = name, 
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

        private PantheonBase SelectGod()
        {
            var gods = GetAllGods();

            var random = new Random();

            var number = random.Next(gods.Count - 1);

            return gods[number];
        }

        public List<PantheonBase> GetAllGods()
        {
            var gods = new List<PantheonBase>();

            gods.AddRange(root.africanGods); gods.AddRange(root.australianAboriginal); gods.AddRange(root.aztecGods);
            gods.AddRange(root.balticGods); gods.AddRange(root.buddhistGods); gods.AddRange(root.canaaniteGods);
            gods.AddRange(root.caribbeanGods); gods.AddRange(root.celticGods); gods.AddRange(root.chineseGods);
            gods.AddRange(root.egyptianGods); gods.AddRange(root.etruscanGods);
            gods.AddRange(root.finnishGods); gods.AddRange(root.germanicGods); gods.AddRange(root.greekGods);
            gods.AddRange(root.hawaiianGods); gods.AddRange(root.hinduGods); gods.AddRange(root.hittiteGods);
            gods.AddRange(root.incaGods); gods.AddRange(root.indonesianGods); gods.AddRange(root.japaneseGods);
            gods.AddRange(root.latvianGods); gods.AddRange(root.lithuanianGods); gods.AddRange(root.maoriGods);
            gods.AddRange(root.mayaGods); gods.AddRange(root.melanesianGods); gods.AddRange(root.mesoamericanGods);
            gods.AddRange(root.mesopotamianGods); gods.AddRange(root.micronesianGods); gods.AddRange(root.middleEasternGods);
            gods.AddRange(root.nativeAmericanGods); gods.AddRange(root.norseGods); gods.AddRange(root.oceanicGods);
            gods.AddRange(root.polynesianGods); gods.AddRange(root.romanGods); gods.AddRange(root.samiGods);
            gods.AddRange(root.siberianGods); gods.AddRange(root.slavicGods); gods.AddRange(root.southAmerican);
            gods.AddRange(root.southeastAsian); gods.AddRange(root.thaiGods); gods.AddRange(root.vodouGods);
            gods.AddRange(root.yorubaGods); gods.AddRange(root.christianSaints);

            return gods;
        }

        public void LoadJson()
        {
            // C:\Users\arne_\source\repos\PlanetGenerator\PlanetGenerator\result.json -- Laptop
            // C:\Users\arne_\Desktop\Innovative Proj\PlanetGenerator\PlanetGenerator\result.json -- Desktop
            string json;
            using (StreamReader r =
                new StreamReader(@"C:\Users\arne_\source\repos\PlanetGenerator\PlanetGenerator\result.json"))
            {
                json = r.ReadToEnd();
                root = JsonConvert.DeserializeObject<Pantheons.Root>(json);
            }
        }
    }
}
