using System;

namespace PlanetGenerator
{
    public class WaterPrevelanceGenerator
    {
        private readonly Random _rnd = new();
        private decimal _maxWater;
        private decimal _oceanWater;
        private decimal _salineLakes;
        private decimal _freshWaterLakes;
        private decimal _freshGroundWater;
        private decimal _glaciers;
        private decimal _swamps;
        private decimal _rivers;
        private decimal _groundIceAndPermafrost;
        private decimal _salineGroundWater;
        private decimal _soilMoisture;
        private decimal _atmosphere;

        private enum Possibility
        {
            No,
            VeryLow,
            Low,
            Medium, 
            High,
            VeryHigh,
            Skip
        }

        public WaterPrevelance GenerateWaterPrevelance(PlanetType planetType)
        {
            var waterPercentage = planetType switch
            {
                PlanetType.Desert
                    => _rnd.Next(500),
                PlanetType.GassGiant
                    => 0.0m,
                PlanetType.IceGiant
                    => 0.0m,
                PlanetType.Earthlike
                    => _rnd.Next(5000, 9000),
                PlanetType.Frozen
                    => _rnd.Next(500, 9000),
                PlanetType.Ocean
                    => _rnd.Next(9000, 10000),
                PlanetType.Humid
                    => _rnd.Next(5000, 8500),
                PlanetType.Rocky
                    => _rnd.Next(2500),
                PlanetType.RockyFurnace
                    => 0.0m
            };

            waterPercentage /= 100;
            _maxWater = 100000.0m;

            switch (planetType)
            {
                case PlanetType.Earthlike:
                    EarthLikePlanetWater();
                    break;
                case PlanetType.Rocky:
                    RockyPlanetWater();
                    break;
                case PlanetType.Desert:
                    DesertPlanetWater();
                    break;
                case PlanetType.Frozen:
                    FrozenPlanetWater();
                    break;
                case PlanetType.Humid:
                    HumidPlanetWater();
                    break;
                case PlanetType.Ocean:
                    OceanPlanetWater();
                    break;
                case PlanetType.IceGiant:
                case PlanetType.GassGiant:
                case PlanetType.RockyFurnace:
                    NoPlanetWater();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(planetType), planetType, null);
            }
            
            var waterDistribution = new WaterDistribution()
            {
                OceanWater = _oceanWater,
                SalineLakes = _salineLakes,
                SalineGroundWater = _salineGroundWater,
                Glaciers = _glaciers,
                FreshWaterLakes = _freshWaterLakes,
                Atmosphere = _atmosphere,
                Rivers = _rivers,
                Swamps = _swamps,
                GroundIceAndPermafrost = _groundIceAndPermafrost,
                FreshGroundWater = _freshGroundWater,
                SoilMoisture = _soilMoisture
            };

            var waterPrev = new WaterPrevelance()
            {
                WaterPercentage = waterPercentage,
                WaterDistribution = waterDistribution
            };

            return waterPrev;
        }

        private void EarthLikePlanetWater()
        {
             _oceanWater = GetOceanWater(Possibility.VeryHigh);
            _glaciers = GetGlaciers(Possibility.Low);
            _salineGroundWater = GetSalineGroundWater(Possibility.Medium);
            _freshGroundWater = GetFreshGroundWater(Possibility.Medium);
            _groundIceAndPermafrost = GetGroundIce(Possibility.Low);
            _freshWaterLakes = GetFreshWaterLakes(Possibility.Medium);
            _salineLakes = GetSalineLakes(Possibility.Medium);
            _soilMoisture = GetSoilMoisture(Possibility.Low);
            _atmosphere = GetAtmosphere(Possibility.VeryLow);
            _swamps = GetSwamps(Possibility.VeryLow);
            _rivers = _maxWater/1000;
        }

        private void RockyPlanetWater()
        {
            _freshGroundWater = GetFreshGroundWater(Possibility.Low);
            _salineGroundWater = GetSalineGroundWater(Possibility.Low);
            _soilMoisture = GetSoilMoisture(Possibility.VeryLow);
            _groundIceAndPermafrost = GetGroundIce(Possibility.VeryLow);
            _oceanWater = GetOceanWater(Possibility.High);
            _glaciers = GetGlaciers(Possibility.Medium);
            _freshWaterLakes = GetFreshWaterLakes(Possibility.Medium);
            _salineLakes = GetSalineLakes(Possibility.Medium);
            _swamps = GetSwamps(Possibility.VeryLow);
            _rivers = GetRivers(Possibility.VeryLow);
            _atmosphere = _maxWater / 1000;
        }

        private void HumidPlanetWater()
        {
            _oceanWater = GetOceanWater(Possibility.VeryHigh);
            _glaciers = GetGlaciers(Possibility.Low);
            _salineGroundWater = GetSalineGroundWater(Possibility.Medium);
            _freshGroundWater = GetFreshGroundWater(Possibility.Medium);
            _groundIceAndPermafrost = GetGroundIce(Possibility.Low);
            _freshWaterLakes = GetFreshWaterLakes(Possibility.Medium);
            _salineLakes = GetSalineLakes(Possibility.Medium);
            _soilMoisture = GetSoilMoisture(Possibility.Low);
            _atmosphere = GetAtmosphere(Possibility.VeryLow);
            _swamps = GetSwamps(Possibility.VeryLow);
            _rivers = _maxWater / 1000;
        }

        private void DesertPlanetWater()
        {
            _freshGroundWater = GetFreshGroundWater(Possibility.Low);
            _salineGroundWater = GetSalineGroundWater(Possibility.Low);
            _soilMoisture = GetSoilMoisture(Possibility.VeryLow);
            _groundIceAndPermafrost = GetGroundIce(Possibility.VeryLow);
            _oceanWater = GetOceanWater(Possibility.High);
            _glaciers = GetGlaciers(Possibility.Medium);
            _freshWaterLakes = GetFreshWaterLakes(Possibility.Medium);
            _salineLakes = GetSalineLakes(Possibility.Medium);
            _swamps = GetSwamps(Possibility.VeryLow);
            _rivers = GetRivers(Possibility.VeryLow);
            _atmosphere = _maxWater / 1000;
        }

        private void FrozenPlanetWater()
        {
            _freshGroundWater = GetFreshGroundWater(Possibility.Low);
            _salineGroundWater = GetSalineGroundWater(Possibility.Low);
            _soilMoisture = GetSoilMoisture(Possibility.VeryLow);
            _groundIceAndPermafrost = GetGroundIce(Possibility.VeryLow);
            _oceanWater = GetOceanWater(Possibility.High);
            _glaciers = GetGlaciers(Possibility.Medium);
            _freshWaterLakes = GetFreshWaterLakes(Possibility.Medium);
            _salineLakes = GetSalineLakes(Possibility.Medium);
            _swamps = GetSwamps(Possibility.VeryLow);
            _rivers = GetRivers(Possibility.VeryLow);
            _atmosphere = _maxWater / 1000;
        }

        private void OceanPlanetWater()
        {
            _oceanWater = GetOceanWater(Possibility.VeryHigh);
            _glaciers = GetGlaciers(Possibility.Low);
            _salineGroundWater = GetSalineGroundWater(Possibility.Medium);
            _freshGroundWater = GetFreshGroundWater(Possibility.Medium);
            _groundIceAndPermafrost = GetGroundIce(Possibility.Low);
            _freshWaterLakes = GetFreshWaterLakes(Possibility.Medium);
            _salineLakes = GetSalineLakes(Possibility.Medium);
            _soilMoisture = GetSoilMoisture(Possibility.Low);
            _atmosphere = GetAtmosphere(Possibility.VeryLow);
            _swamps = GetSwamps(Possibility.VeryLow);
            _rivers = _maxWater / 1000;
        }

        private void NoPlanetWater()
        {
            _oceanWater = 0;
            _salineLakes = 0;
            _freshWaterLakes = 0;
            _freshGroundWater = 0;
            _glaciers = 0;
            _swamps = 0;
            _rivers = 0;
            _groundIceAndPermafrost = 0;
            _salineGroundWater = 0;
            _soilMoisture = 0;
            _atmosphere = 0;
        }

        private decimal GetOceanWater(Possibility possibility)
        {
            decimal water = possibility switch
            {
                Possibility.VeryLow
                    => _rnd.Next((int)(_maxWater * 0.1m)),
                Possibility.Low
                    => _rnd.Next((int)(_maxWater * 0.1m),(int)(_maxWater * 0.25m)),
                Possibility.Medium
                    => _rnd.Next((int)(_maxWater * 0.25m),(int)(_maxWater * 0.7m)),
                Possibility.High
                    => _rnd.Next((int)(_maxWater * 0.7m),(int)(_maxWater * 0.85m)),
                Possibility.VeryHigh
                    => _rnd.Next((int)(_maxWater * 0.85m),(int)(_maxWater * 0.98m)),
                Possibility.No
                    => 0.0m,
                Possibility.Skip
                    => _rnd.Next((int)_maxWater)
            };

            _maxWater -= water;
            return water / 1000;
        }

        private decimal GetSalineLakes(Possibility possibility)
        {
            decimal water = possibility switch
            {
                Possibility.VeryLow
                    => _rnd.Next((int)(_maxWater * 0.1m)),
                Possibility.Low
                    => _rnd.Next((int)(_maxWater * 0.1m),(int)(_maxWater * 0.25m)),
                Possibility.Medium
                    => _rnd.Next((int)(_maxWater * 0.25m),(int)(_maxWater * 0.7m)),
                Possibility.High
                    => _rnd.Next((int)(_maxWater * 0.7m),(int)(_maxWater * 0.85m)),
                Possibility.VeryHigh
                    => _rnd.Next((int)(_maxWater * 0.85m),(int)(_maxWater * 0.98m)),
                Possibility.No
                    => 0.0m,
                Possibility.Skip
                    => _rnd.Next((int)_maxWater)
            };

            _maxWater -= water;
            return water / 1000;
        }

        private decimal GetSalineGroundWater(Possibility possibility)
        {
            decimal water = possibility switch
            {
                Possibility.VeryLow
                    => _rnd.Next((int)(_maxWater * 0.1m)),
                Possibility.Low
                    => _rnd.Next((int)(_maxWater * 0.1m),(int)(_maxWater * 0.25m)),
                Possibility.Medium
                    => _rnd.Next((int)(_maxWater * 0.25m),(int)(_maxWater * 0.7m)),
                Possibility.High
                    => _rnd.Next((int)(_maxWater * 0.7m),(int)(_maxWater * 0.85m)),
                Possibility.VeryHigh
                    => _rnd.Next((int)(_maxWater * 0.85m),(int)(_maxWater * 0.98m)),
                Possibility.No
                    => 0.0m,
                Possibility.Skip
                    => _rnd.Next((int)_maxWater)
            };

            _maxWater -= water;
            return water / 1000;
        }

        private decimal GetGlaciers(Possibility possibility)
        {
            decimal water = possibility switch
            {
                Possibility.VeryLow
                    => _rnd.Next((int)(_maxWater * 0.1m)),
                Possibility.Low
                    => _rnd.Next((int)(_maxWater * 0.1m),(int)(_maxWater * 0.25m)),
                Possibility.Medium
                    => _rnd.Next((int)(_maxWater * 0.25m),(int)(_maxWater * 0.7m)),
                Possibility.High
                    => _rnd.Next((int)(_maxWater * 0.7m),(int)(_maxWater * 0.85m)),
                Possibility.VeryHigh
                    => _rnd.Next((int)(_maxWater * 0.85m),(int)(_maxWater * 0.98m)),
                Possibility.No
                    => 0.0m,
                Possibility.Skip
                    => _rnd.Next((int)_maxWater)
            };

            _maxWater -= water;
            return water / 1000;
        }

        private decimal GetFreshWaterLakes(Possibility possibility)
        {
            decimal water = possibility switch
            {
                Possibility.VeryLow
                    => _rnd.Next((int)(_maxWater * 0.1m)),
                Possibility.Low
                    => _rnd.Next((int)(_maxWater * 0.1m),(int)(_maxWater * 0.25m)),
                Possibility.Medium
                    => _rnd.Next((int)(_maxWater * 0.25m),(int)(_maxWater * 0.7m)),
                Possibility.High
                    => _rnd.Next((int)(_maxWater * 0.7m),(int)(_maxWater * 0.85m)),
                Possibility.VeryHigh
                    => _rnd.Next((int)(_maxWater * 0.85m),(int)(_maxWater * 0.98m)),
                Possibility.No
                    => 0.0m,
                Possibility.Skip
                    => _rnd.Next((int)_maxWater)
            };

            _maxWater -= water;
            return water / 1000;
        }

        private decimal GetAtmosphere(Possibility possibility)
        {
            decimal water = possibility switch
            {
                Possibility.VeryLow
                    => _rnd.Next((int)(_maxWater * 0.1m)),
                Possibility.Low
                    => _rnd.Next((int)(_maxWater * 0.1m),(int)(_maxWater * 0.25m)),
                Possibility.Medium
                    => _rnd.Next((int)(_maxWater * 0.25m),(int)(_maxWater * 0.7m)),
                Possibility.High
                    => _rnd.Next((int)(_maxWater * 0.7m),(int)(_maxWater * 0.85m)),
                Possibility.VeryHigh
                    => _rnd.Next((int)(_maxWater * 0.85m),(int)(_maxWater * 0.98m)),
                Possibility.No
                    => 0.0m,
                Possibility.Skip
                    => _rnd.Next((int)_maxWater)
            };

            _maxWater -= water;
            return water / 1000;
        }

        private decimal GetSwamps(Possibility possibility)
        {
            decimal water = possibility switch
            {
                Possibility.VeryLow
                    => _rnd.Next((int)(_maxWater * 0.1m)),
                Possibility.Low
                    => _rnd.Next((int)(_maxWater * 0.1m),(int)(_maxWater * 0.25m)),
                Possibility.Medium
                    => _rnd.Next((int)(_maxWater * 0.25m),(int)(_maxWater * 0.7m)),
                Possibility.High
                    => _rnd.Next((int)(_maxWater * 0.7m),(int)(_maxWater * 0.85m)),
                Possibility.VeryHigh
                    => _rnd.Next((int)(_maxWater * 0.85m),(int)(_maxWater * 0.98m)),
                Possibility.No
                    => 0.0m,
                Possibility.Skip
                    => _rnd.Next((int)_maxWater)
            };

            _maxWater -= water;
            return water / 1000;
        }

        private decimal GetRivers(Possibility possibility)
        {
            decimal water = possibility switch
            {
                Possibility.VeryLow
                    => _rnd.Next((int)(_maxWater * 0.1m)),
                Possibility.Low
                    => _rnd.Next((int)(_maxWater * 0.1m),(int)(_maxWater * 0.25m)),
                Possibility.Medium
                    => _rnd.Next((int)(_maxWater * 0.25m),(int)(_maxWater * 0.7m)),
                Possibility.High
                    => _rnd.Next((int)(_maxWater * 0.7m),(int)(_maxWater * 0.85m)),
                Possibility.VeryHigh
                    => _rnd.Next((int)(_maxWater * 0.85m),(int)(_maxWater * 0.98m)),
                Possibility.No
                    => 0.0m,
                Possibility.Skip
                    => _rnd.Next((int)_maxWater)
            };

            _maxWater -= water;
            return water / 1000;
        }

        private decimal GetGroundIce(Possibility possibility)
        {
            decimal water = possibility switch
            {
                Possibility.VeryLow
                    => _rnd.Next((int)(_maxWater * 0.1m)),
                Possibility.Low
                    => _rnd.Next((int)(_maxWater * 0.1m),(int)(_maxWater * 0.25m)),
                Possibility.Medium
                    => _rnd.Next((int)(_maxWater * 0.25m),(int)(_maxWater * 0.7m)),
                Possibility.High
                    => _rnd.Next((int)(_maxWater * 0.7m),(int)(_maxWater * 0.85m)),
                Possibility.VeryHigh
                    => _rnd.Next((int)(_maxWater * 0.85m),(int)(_maxWater * 0.98m)),
                Possibility.No
                    => 0.0m,
                Possibility.Skip
                    => _rnd.Next((int)_maxWater)
            };

            _maxWater -= water;
            return water / 1000;
        }

        private decimal GetFreshGroundWater(Possibility possibility)
        {
            decimal water = possibility switch
            {
                Possibility.VeryLow
                    => _rnd.Next((int)(_maxWater * 0.1m)),
                Possibility.Low
                    => _rnd.Next((int)(_maxWater * 0.1m),(int)(_maxWater * 0.25m)),
                Possibility.Medium
                    => _rnd.Next((int)(_maxWater * 0.25m),(int)(_maxWater * 0.7m)),
                Possibility.High
                    => _rnd.Next((int)(_maxWater * 0.7m),(int)(_maxWater * 0.85m)),
                Possibility.VeryHigh
                    => _rnd.Next((int)(_maxWater * 0.85m),(int)(_maxWater * 0.98m)),
                Possibility.No
                    => 0.0m,
                Possibility.Skip
                    => _rnd.Next((int)_maxWater)
            };

            _maxWater -= water;
            return water / 1000;
        }

        private decimal GetSoilMoisture(Possibility possibility)
        {
            decimal water = possibility switch
            {
                Possibility.VeryLow
                    => _rnd.Next((int)(_maxWater * 0.1m)),
                Possibility.Low
                    => _rnd.Next((int)(_maxWater * 0.1m),(int)(_maxWater * 0.25m)),
                Possibility.Medium
                    => _rnd.Next((int)(_maxWater * 0.25m),(int)(_maxWater * 0.7m)),
                Possibility.High
                    => _rnd.Next((int)(_maxWater * 0.7m),(int)(_maxWater * 0.85m)),
                Possibility.VeryHigh
                    => _rnd.Next((int)(_maxWater * 0.85m),(int)(_maxWater * 0.98m)),
                Possibility.No
                    => 0.0m,
                Possibility.Skip
                    => _rnd.Next((int)_maxWater)
            };

            _maxWater -= water;
            return water / 1000;
        }
    }
}
