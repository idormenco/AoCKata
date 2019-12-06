using System.Collections.Generic;
using System.Linq;

namespace Kata
{
	public static class Orbit
	{
		public static Dictionary<string, string> Parse(List<string> orbits)
		{
			Dictionary<string, string> map = new Dictionary<string, string>();

			Dictionary<string, List<string>> parentNodes = new Dictionary<string, List<string>>();

			foreach (var orbit in orbits)
			{
				var objects = orbit.Trim().Split(")");

				if (parentNodes.ContainsKey(objects[0]))
				{
					parentNodes[objects[0]].Add(objects[1]);
				}
				else
				{
					parentNodes.Add(objects[0], new List<string> { objects[1] });
				}
			}

			Queue<string> toBeProcessed = new Queue<string>();

			toBeProcessed.Enqueue("COM");

			do
			{
				var node = toBeProcessed.Dequeue();
				var path = map.ContainsKey(node) ? map[node] : node;

				if (!parentNodes.ContainsKey(node))
				{
					continue;
				}

				foreach (var child in parentNodes[node])
				{
					toBeProcessed.Enqueue(child);
					map.Add(child, path + ">" + child);
				}

			} while (toBeProcessed.Count > 0);

			return map;

		}
		public static int GetTotalNumberOfOrbits(Dictionary<string, string> tree)
		{
			var sum = tree.Select(x => x.Value).Select(x => x.Count(y => y == '>')).Sum();
			return sum;
		}

		public static int GetTotalNumberOfJumps(Dictionary<string, string> map)
		{
			var you = map.Values.First(x => x.Contains("YOU")).Replace(">YOU", "");
			var san = map.Values.First(x => x.Contains("SAN")).Replace(">SAN", "");

			var youPath = new Queue<string>(you.Split(">"));
			var sanPath = new Queue<string>(san.Split(">"));

			do
			{
				var a = youPath.Dequeue();
				var b = sanPath.Dequeue();

				if (a == b)
				{
					continue;
				}

				int jumps = youPath.Count + sanPath.Count + 2;

				return jumps;
			} while (true);
		}
	}
}