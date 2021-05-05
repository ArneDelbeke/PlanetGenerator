namespace PlanetGenerator
{
    public class TemperatureRange
    {
        public float MinTemperature { get; set; }
        public float MaxTemperature { get; set; }

        public TemperatureRange(float minTemperature, float maxTemperature)
            => (MinTemperature, MaxTemperature) = (minTemperature, maxTemperature);
    }
}
