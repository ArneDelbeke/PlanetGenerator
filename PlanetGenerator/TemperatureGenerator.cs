using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetGenerator
{
    public class TemperatureGenerator
    {
        private class PlanetTemp
        {
            private readonly decimal _maxTemp;
            private readonly decimal _minTemp;

            public PlanetTemp(decimal maxTemp, decimal minTemp)
            {
                _maxTemp = maxTemp;
                _minTemp = minTemp;
            }
        }

        private static readonly PlanetTemp Earth = new(0.0m, 0.0m);
        private static readonly PlanetTemp Mercury = new(0.0m, 0.0m);
        private static readonly PlanetTemp Venus = new(0.0m, 0.0m);
        private static readonly PlanetTemp Mars = new(0.0m, 0.0m);
        private static readonly PlanetTemp Jupiter = new(0.0m, 0.0m);
        private static readonly PlanetTemp Saturn = new(0.0m, 0.0m);
        private static readonly PlanetTemp Uranus = new(0.0m, 0.0m);
        private static readonly PlanetTemp Neptune = new(0.0m, 0.0m);

        private readonly PlanetTemp[] PlanetTempArr =
        {
            Earth, Mercury, Venus, Mars, Jupiter, Saturn, Uranus, Neptune
        };

        public TemperatureRange GenerateTemperatureRange()
        {
            var maxTemperature = 71.3f;
            var minTemperature = -34.9f;
            var tempRange = new TemperatureRange(minTemperature, maxTemperature);



            return tempRange;
        }
    }
}
