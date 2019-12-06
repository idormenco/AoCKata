using System;
using System.Collections.Generic;

namespace Kata
{
	public class Wiers
	{
		public class Point
		{
			public double X;
			public double Y;

			public Point(double x, double y)
			{
				this.X = x;
				this.Y = y;
			}

		};

		// Given three colinear points p, q, r, the function checks if 
		// point q lies on line segment 'pr' 
		static bool OnSegment(Point p, Point q, Point r)
		{
			if (q.X <= Math.Max(p.X, r.X) && q.X >= Math.Min(p.X, r.X) &&
				q.Y <= Math.Max(p.Y, r.Y) && q.Y >= Math.Min(p.Y, r.Y))
				return true;

			return false;
		}

		// To find orientation of ordered triplet (p, q, r). 
		// The function returns following values 
		// 0 --> p, q and r are colinear 
		// 1 --> Clockwise 
		// 2 --> Counterclockwise 
		static double Orientation(Point p, Point q, Point r)
		{
			// See https://www.geeksforgeeks.org/orientation-3-ordered-points/ 
			// for details of below formula. 
			double val = (q.Y - p.Y) * (r.X - q.X) -
					(q.X - p.X) * (r.Y - q.Y);

			if (val == 0) return 0; // colinear 

			return (val > 0) ? 1 : 2; // clock or counterclock wise 
		}

		// The main function that returns true if line segment 'p1q1' 
		// and 'p2q2' intersect. 
		static bool DoIntersect(Point p1, Point q1, Point p2, Point q2)
		{
			// Find the four orientations needed for general and 
			// special cases 
			var o1 = Orientation(p1, q1, p2);
			var o2 = Orientation(p1, q1, q2);
			var o3 = Orientation(p2, q2, p1);
			var o4 = Orientation(p2, q2, q1);

			// General case 
			if (o1 != o2 && o3 != o4)
				return true;

			// Special Cases 
			// p1, q1 and p2 are colinear and p2 lies on segment p1q1 
			if (o1 == 0 && OnSegment(p1, p2, q1)) return true;

			// p1, q1 and q2 are colinear and q2 lies on segment p1q1 
			if (o2 == 0 && OnSegment(p1, q2, q1)) return true;

			// p2, q2 and p1 are colinear and p1 lies on segment p2q2 
			if (o3 == 0 && OnSegment(p2, p1, q2)) return true;

			// p2, q2 and q1 are colinear and q1 lies on segment p2q2 
			if (o4 == 0 && OnSegment(p2, q1, q2)) return true;

			return false; // Doesn't fall in any of the above cases 
		}

		public static Point LineLineIntersection(Point A, Point B, Point C, Point D)
		{
			// Line AB represented as a1x + b1y = c1  
			double a1 = B.Y - A.Y;
			double b1 = A.X - B.X;
			double c1 = a1 * (A.X) + b1 * (A.Y);

			// Line CD represented as a2x + b2y = c2  
			double a2 = D.Y - C.Y;
			double b2 = C.X - D.X;
			double c2 = a2 * (C.X) + b2 * (C.Y);

			double determinant = a1 * b2 - a2 * b1;

			if (determinant == 0)
			{
				// The lines are parallel. This is simplified  
				// by returning a pair of FLT_MAX  
				return new Point(int.MaxValue, int.MaxValue);
			}
			else
			{
				double x = (b2 * c1 - b1 * c2) / determinant;
				double y = (a1 * c2 - a2 * c1) / determinant;
				return new Point(x, y);
			}
		}
		private static double GetDistance(double x1, double y1, double x2, double y2)
		{
			return Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
		}


		private static List<(Point start, Point finish)> PathToSegments(List<string> path)
		{
			var segments = new List<(Point start, Point finish)>();
			var start = new Point(0, 0);
			foreach (var p in path)
			{
				var direction = p[0];
				var count = double.Parse(p.Substring(1));
				Point end = null;
				if (direction == 'U')
				{
					end = new Point(start.X, start.Y + count);

				}

				if (direction == 'D')
				{
					end = new Point(start.X, start.Y - count);

				}

				if (direction == 'R')
				{
					end = new Point(start.X + count, start.Y);
				}

				if (direction == 'L')
				{
					end = new Point(start.X - count, start.Y);
				}


				segments.Add((start, end));

				start = end;
			}

			return segments;
		}

		private static double PathToIntersection(List<string> path, Point intersection)
		{
			var segments = new List<(Point start, Point finish)>();
			var start = new Point(0, 0);
			double distance = 0;
			foreach (var p in path)
			{
				var direction = p[0];
				var count = double.Parse(p.Substring(1));
				Point end = null;
				if (direction == 'U')
				{
					end = new Point(start.X, start.Y + count);

				}

				if (direction == 'D')
				{
					end = new Point(start.X, start.Y - count);

				}

				if (direction == 'R')
				{
					end = new Point(start.X + count, start.Y);
				}

				if (direction == 'L')
				{
					end = new Point(start.X - count, start.Y);
				}

				segments.Add((start, end));

				if (OnSegment(start, intersection, end))
				{
					if (start.X == intersection.X)
					{
						distance += Math.Abs(Math.Abs(start.Y) - Math.Abs(intersection.Y));
						return distance;

					}
					if (start.Y == intersection.Y)
					{
						distance += Math.Abs(Math.Abs(start.X) - Math.Abs(intersection.X));
						return distance;
					}
				}
				else
				{
					distance += count;
				}

				start = end;
			}

			return distance;
		}
	}
}