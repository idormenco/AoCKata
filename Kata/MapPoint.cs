using System.Collections.Generic;
using static Kata.Wiers;

namespace Kata
{
    public class MapPoint
    {
        public Point Coordinates { get; set; }
        public bool IsAsteroid { get; set; }
        public List<MapPoint> VisibleAsteroids { get; set; } = new List<MapPoint>();
        public List<MapPoint> AsteroidsToBeProcessed { get; set; } = new List<MapPoint>();
    }
}