using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadanieGeoTronics.Zadanie4
{
    internal class Helpers
    {
        public const double EarthRadius = 6371;
        public static double ToRadians(double degres)
        {
            return degres * (Math.PI / 180);
        } 

        public static double DistanceBetweenPoints(
            double latitude1, 
            double longitude1, 
            double latitude2, 
            double longitude2)
        {
            double deltaLatitude = ToRadians(latitude2 - latitude1);
            double deltaLongitude = ToRadians(latitude2 - latitude1);

            double a = Math.Sin(deltaLatitude / 2) * Math.Sin(deltaLatitude / 2) +
                       Math.Cos(ToRadians(latitude1)) * Math.Cos(ToRadians(latitude2)) *
                       Math.Sin(deltaLongitude / 2) * Math.Sin(deltaLongitude / 2);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return EarthRadius * c;
        }

        public static double TriangleArea(double a, double b, double c)
        {
            double s = (a + b + c) / 2;
            return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
        }
    }
}
