using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalityLibrary
{
    public class Calculation
    {
        public static class Distance
        {
            public static int GetFromPoints(Point p1, Point p2)
            {
                return (int)Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
            }
        }

    }
}
