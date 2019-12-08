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

        public static IEnumerable<IEnumerable<T>> Batch<T>(this IEnumerable<T> items,
                                                       int maxItems)
        {
            return items.Select((item, inx) => new { item, inx })
                        .GroupBy(x => x.inx / maxItems)
                        .Select(g => g.Select(x => x.item));
        }
    }


}
