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

        public WaterPrevelance GenerateWaterPrevelance(PlanetType planetType)
        {
            decimal waterPercentage = _rnd.Next(10000);
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
            _oceanWater = GetOceanWater();
            _salineLakes = GetSalineLakes();
            _freshWaterLakes = GetFreshWaterLakes();
            _freshGroundWater = GetFreshGroundWater();
            _glaciers = GetGlaciers();
            _swamps = GetSwamps();
            _rivers = GetRivers();
            _groundIceAndPermafrost = GetGroundIce();
            _salineGroundWater = GetSalineGroundWater();
            _soilMoisture = GetSoilMoisture();
            _atmosphere = GetAtmosphere();
        }

        private void RockyPlanetWater()
        {

        }

        private void HumidPlanetWater()
        {

        }

        private void DesertPlanetWater()
        {

        }

        private void FrozenPlanetWater()
        {

        }

        private void OceanPlanetWater()
        {

        }

        private void NoPlanetWater()
        {

        }

        private decimal GetOceanWater()
        {
            var water = (decimal)_rnd.Next((int)_maxWater);
            _maxWater -= water;

            return water / 1000;
        }

        private decimal GetSalineLakes()
        {
            var water = (decimal)_rnd.Next((int)_maxWater);
            _maxWater -= water;

            return water / 1000;
        }

        private decimal GetSalineGroundWater()
        {
            var water = (decimal)_rnd.Next((int)_maxWater);
            _maxWater -= water;

            return water / 1000;
        }

        private decimal GetGlaciers()
        {
            var water = (decimal)_rnd.Next((int)_maxWater);
            _maxWater -= water;

            return water / 1000;
        }

        private decimal GetFreshWaterLakes()
        {
            var water = (decimal)_rnd.Next((int)_maxWater);
            _maxWater -= water;

            return water / 1000;
        }

        private decimal GetAtmosphere()
        {
            var water = (decimal)_rnd.Next((int)_maxWater);
            _maxWater -= water;

            return water / 1000;
        }

        private decimal GetSwamps()
        {
            var water = (decimal)_rnd.Next((int)_maxWater);
            _maxWater -= water;

            return water / 1000;
        }

        private decimal GetRivers()
        {
            var water = (decimal)_rnd.Next((int)_maxWater);
            _maxWater -= water;

            return water / 1000;
        }

        private decimal GetGroundIce()
        {
            var water = (decimal)_rnd.Next((int)_maxWater);
            _maxWater -= water;

            return water / 1000;
        }

        private decimal GetFreshGroundWater()
        {
            var water = (decimal)_rnd.Next((int)_maxWater);
            _maxWater -= water;

            return water / 1000;
        }

        private decimal GetSoilMoisture()
        {
            var water = (decimal)_rnd.Next((int)_maxWater);
            _maxWater -= water;

            return water / 1000;
        }
    }
}
