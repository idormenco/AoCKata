using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata
{
    public static class Asteroids
    {
        public static (List<MapPoint> map, int size) ParseMap(List<string> input)
        {
            List<MapPoint> map = new List<MapPoint>();
            int y = 0;
            int size = 0;
            foreach (var row in input)
            {
                var x = 0;
                foreach (var c in row)
                {
                    var mp = new MapPoint()
                    {
                        Coordinates = new Wiers.Point(x, y),
                        IsAsteroid = c == '#'
                    };
                    x++;

                    map.Add(mp);
                }
                size = row.Length;
                y++;
            }

            return (map, size);
        }

        public static void PrintMap(List<MapPoint> map, int rowLength)
        {
            var rowedMap = map.Batch(rowLength).Select(x => x.ToList()).ToList();
            foreach (var row in rowedMap)
            {
                Console.WriteLine(string.Join("", row.Select(x => x.IsAsteroid ? '#' : '.')));
            }
        }

        public static void PrintVizibilityMap(List<MapPoint> map, int rowLength)
        {
            var rowedMap = map.Batch(rowLength).Select(x => x.ToList()).ToList();
            foreach (var row in rowedMap)
            {
                Console.WriteLine(string.Join("", row.Select(x => x.IsAsteroid ? x.VisibleAsteroids.Count.ToString() : ".")));
            }
        }

        public static (List<MapPoint> map, int size) ComputeVisibility(List<MapPoint> input, int size)
        {
            IEnumerable<MapPoint> asteroids = input.Where(x => x.IsAsteroid);
            Queue<MapPoint> asteroidsQ = new Queue<MapPoint>(asteroids);


            foreach (var a in asteroidsQ)
            {
                a.AsteroidsToBeProcessed = new List<MapPoint>(asteroids);
            }

            do
            {
                MapPoint a = asteroidsQ.Dequeue();
                
                if(a.AsteroidsToBeProcessed.Count == 0)
                {
                    continue;
                }

                foreach (var candidate in a.AsteroidsToBeProcessed)
                {

                }



            } while (asteroidsQ.Any());

            return (input, size);
        }


    }
}
