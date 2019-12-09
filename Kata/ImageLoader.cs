using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata
{
    public class Layer
    {
        public int Index { get; set; }
        public List<int[]> Pixels { get; set; }
    }
    public static class ImageLoader
    {
        public static List<Layer> ImageToLayers(string image, int lengthOfLayer, int heightOfLayer)
        {
            var layers = image.ToCharArray()
                .Select(x => (int)(x - 48))
                .Batch(lengthOfLayer * heightOfLayer)
                .Select((pixels, index) => new Layer()
                {
                    Index = index,
                    Pixels = pixels.Batch(lengthOfLayer).Select(x=>x.ToArray()).ToList()
                })
                .ToList();

            return layers;
        }

        public static List<int[]> ReduceLayers(List<Layer> layers, int lengthOfLayer, int heightOfLayer)
        {
            var lst = new List<int[]>();

            for (int i = 0; i < heightOfLayer; i++)
            {
                var row = new int[lengthOfLayer];
                for (int j = 0; j < lengthOfLayer; j++)
                {
                    int pixel = layers.Select(x => x.Pixels[i][j]).First(x => x != 2);
                    row[j] = pixel;
                }

                lst.Add(row);
            }

            return lst;
        }

        public static void PrintImage(List<int[]> image, int lengthOfLayer, int heightOfLayer)
        {
            for (int i = 0; i < heightOfLayer; i++)
            {
                for (int j = 0; j < lengthOfLayer; j++)
                {
                    Console.ForegroundColor = image[i][j] == 0 ? ConsoleColor.Green : ConsoleColor.Red;
                    Console.Write("█");
                }

                Console.WriteLine();
            }
        }

        public static IEnumerable<IEnumerable<T>> Batch<T>(this IEnumerable<T> items,
                                                       int maxItems)
        {
            return items.Select((item, inx) => new { item, inx })
                        .GroupBy(x => x.inx / maxItems)
                        .Select(g => g.Select(x => x.item));
        }
    }


}
