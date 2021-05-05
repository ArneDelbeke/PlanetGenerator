namespace PlanetGenerator
{
    public class WaterPrevelance
    {
        public decimal WaterPercentage { get; set; }
        public WaterDistribution WaterDistribution { get; set; }

        public decimal FreshWater()
        {
            return WaterDistribution.FreshWaterLakes + WaterDistribution.FreshGroundWater +
                 WaterDistribution.Atmosphere + WaterDistribution.Glaciers + WaterDistribution.GroundIceAndPermafrost +
                 WaterDistribution.SoilMoisture + WaterDistribution.Swamps + WaterDistribution.Rivers;
        }

        public decimal SaltWater()
        {
            return WaterDistribution.SalineLakes + WaterDistribution.SalineGroundWater +
                   WaterDistribution.OceanWater;
        }

        public decimal SurfaceWater()
        {
            return WaterDistribution.OceanWater + WaterDistribution.FreshWaterLakes + WaterDistribution.Glaciers +
            WaterDistribution.Atmosphere + WaterDistribution.SalineLakes + WaterDistribution.Rivers + WaterDistribution.Swamps;
        }

        public decimal SubterraneanWater()
        {
            return WaterDistribution.FreshGroundWater + WaterDistribution.GroundIceAndPermafrost +
                   WaterDistribution.SoilMoisture + WaterDistribution.SalineGroundWater;
        }
    }
}
