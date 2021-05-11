using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace PlanetGenerator
{
    public class Generator
    {
        private readonly SizeGenerator _sizeGenerator;
        private readonly TimeSpanGenerator _timeSpanGenerator;
        private readonly TemperatureGenerator _tempGenerator;
        private readonly WaterPrevelanceGenerator _waterGenerator;
        private readonly MoonGenerator _moonGenerator;
        private Pantheons.Root _root = new();

        public Generator(SizeGenerator sizeGenerator, TimeSpanGenerator timeSpanGenerator,
            TemperatureGenerator tempGenerator, MoonGenerator moonGenerator,
            WaterPrevelanceGenerator waterGenerator)
        {
            _sizeGenerator = sizeGenerator;
            _timeSpanGenerator = timeSpanGenerator;
            _tempGenerator = tempGenerator;
            _waterGenerator = waterGenerator;
            _moonGenerator = moonGenerator;
        }

        public Planet GeneratePlanet()
        {
            LoadJson();
            var god = SelectGod();
            var name = $"{god.Name}";
            var nameDescription = $"{god.Description}";

            var planetType = PlanetTypeSelector();
            var radius = _sizeGenerator.GeneratePlanetRadius();
            var size = _sizeGenerator.PlanetSize(radius);
            
            var lengthOfDay = _timeSpanGenerator.LengthOfDay();
            var lengthOfYear = _timeSpanGenerator.LengthOfYear();
            var localDaysInYear = _timeSpanGenerator.LengthOfYearInLocalDays(lengthOfDay.TotalHours, lengthOfYear.TotalHours);

            var tempRange = _tempGenerator.GenerateTemperatureRange();
            var avgTemp = _tempGenerator.GenerateAverageTemperature(tempRange);

            var waterPrevelance = _waterGenerator.GenerateWaterPrevelance(planetType);
            var moons = _moonGenerator.GenerateMoons();

            var isLifeSupporting = GetLifeSupportingValue(planetType);

            var planet = new Planet
            {   
                Name = name, 
                NameDescription = nameDescription,
                Moons = moons,
                PlanetType = planetType, 
                Size = size,
                Radius = radius,
                TemperatureRange = tempRange,
                AverageTemperature = avgTemp,
                WaterPrevelance = waterPrevelance,
                IsLifeSupporting = isLifeSupporting,
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

        public bool GetLifeSupportingValue(PlanetType planetType)
        {
            var isLifeSupporting = planetType switch
            {
                PlanetType.Desert or PlanetType.Earthlike or PlanetType.Rocky or PlanetType.Ocean or PlanetType.Humid
                    => true,
                _ => false
            };

            return isLifeSupporting;
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

            gods.AddRange(_root.africanGods); gods.AddRange(_root.australianAboriginal); gods.AddRange(_root.aztecGods);
            gods.AddRange(_root.balticGods); gods.AddRange(_root.buddhistGods); gods.AddRange(_root.canaaniteGods);
            gods.AddRange(_root.caribbeanGods); gods.AddRange(_root.celticGods); gods.AddRange(_root.chineseGods);
            gods.AddRange(_root.egyptianGods); gods.AddRange(_root.etruscanGods);
            gods.AddRange(_root.finnishGods); gods.AddRange(_root.germanicGods); gods.AddRange(_root.greekGods);
            gods.AddRange(_root.hawaiianGods); gods.AddRange(_root.hinduGods); gods.AddRange(_root.hittiteGods);
            gods.AddRange(_root.incaGods); gods.AddRange(_root.indonesianGods); gods.AddRange(_root.japaneseGods);
            gods.AddRange(_root.latvianGods); gods.AddRange(_root.lithuanianGods); gods.AddRange(_root.maoriGods);
            gods.AddRange(_root.mayaGods); gods.AddRange(_root.melanesianGods); gods.AddRange(_root.mesoamericanGods);
            gods.AddRange(_root.mesopotamianGods); gods.AddRange(_root.micronesianGods); gods.AddRange(_root.middleEasternGods);
            gods.AddRange(_root.nativeAmericanGods); gods.AddRange(_root.norseGods); gods.AddRange(_root.oceanicGods);
            gods.AddRange(_root.polynesianGods); gods.AddRange(_root.romanGods); gods.AddRange(_root.samiGods);
            gods.AddRange(_root.siberianGods); gods.AddRange(_root.slavicGods); gods.AddRange(_root.southAmerican);
            gods.AddRange(_root.southeastAsian); gods.AddRange(_root.thaiGods); gods.AddRange(_root.vodouGods);
            gods.AddRange(_root.yorubaGods); gods.AddRange(_root.christianSaints);

            return gods;
        }

        public void LoadJson()
        {
            using var r =
                new StreamReader(@"C:\Users\arne_\Desktop\Innovative Proj\PlanetGenerator\PlanetGenerator\result.json");
            var json = r.ReadToEnd();
            _root = JsonConvert.DeserializeObject<Pantheons.Root>(json);
        }
    }
}
