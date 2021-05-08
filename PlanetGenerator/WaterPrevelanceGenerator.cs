using System;

namespace PlanetGenerator
{
    public class WaterPrevelanceGenerator
    {
        private readonly Random _rnd = new();
        private decimal _maxWater;
        public WaterPrevelance GenerateWaterPrevelance()
        {

            decimal waterPercentage = _rnd.Next(10000);
            waterPercentage /= 100;
            _maxWater = 100000.0m;

            var oceanWater = GetOceanWater();
            var salineLakes = GetSalineLakes();
            var freshWaterLakes = GetFreshWaterLakes();
            var freshGroundWater = GetFreshGroundWater();
            var glaciers = GetGlaciers();
            var swamps = GetSwamps();
            var rivers = GetRivers();
            var groundIceAndPermafrost = GetGroundIce();
            var salineGroundWater = GetSalineGroundWater();
            var soilMoisture = GetSoilMoisture();
            var atmosphere = GetAtmosphere();

            var waterDistribution = new WaterDistribution()
            {
                OceanWater = oceanWater,
                SalineLakes = salineLakes,
                SalineGroundWater = salineGroundWater,
                Glaciers = glaciers,
                FreshWaterLakes = freshWaterLakes,
                Atmosphere = atmosphere,
                Rivers = rivers,
                Swamps = swamps,
                GroundIceAndPermafrost = groundIceAndPermafrost,
                FreshGroundWater = freshGroundWater,
                SoilMoisture = soilMoisture
            };

            var waterPrev = new WaterPrevelance()
            {
                WaterPercentage = waterPercentage,
                WaterDistribution = waterDistribution
            };

            return waterPrev;
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
