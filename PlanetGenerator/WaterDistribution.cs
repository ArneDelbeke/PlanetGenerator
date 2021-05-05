namespace PlanetGenerator
{
    public class WaterDistribution
    {
        // Saltwater
        public decimal OceanWater { get; set; }
        public decimal SalineLakes { get; set; }

        // Saltwater subterranean
        public decimal SalineGroundWater { get; set; }

        // Freshwater
        public decimal Glaciers { get; set; }
        public decimal FreshWaterLakes { get; set; }
        public decimal Atmosphere { get; set; }
        public decimal Rivers { get; set; }
        public decimal Swamps { get; set; }

        // Freshwater subterranean
        public decimal GroundIceAndPermafrost { get; set; }
        public decimal FreshGroundWater { get; set; }
        public decimal SoilMoisture { get; set; }
    }
}
