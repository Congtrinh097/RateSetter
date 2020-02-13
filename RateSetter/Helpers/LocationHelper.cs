using System;
using System.Collections.Generic;
using System.Text;

namespace RateSetter.Helpers
{
    public class LocationHelper
    {
        public static double GetDistance(decimal lat1, decimal lon1, decimal lat2, decimal lon2, char unit = 'K') { 

            double dlat1 = Decimal.ToDouble(lat1);
            double dlat2 = Decimal.ToDouble(lat1);
            double dlong1 = Decimal.ToDouble(lon1);
            double dlong2 = Decimal.ToDouble(lon2);

            double dist = GetDistance(dlat1, dlong1, dlat2, dlong2);
            switch (unit)
            {
                case 'K': //Kilometers -> default
                    return dist * 1.609344;
                case 'N': //Nautical Miles 
                    return dist * 0.8684;
                case 'M': //Miles
                    return dist;
            }

            return dist;
        }

        private static double GetDistance( double latitude, double longitude, double otherLatitude, double otherLongitude )
        {
            var d1 = latitude * (Math.PI / 180.0);
            var num1 = longitude * (Math.PI / 180.0);
            var d2 = otherLatitude * (Math.PI / 180.0);
            var num2 = otherLongitude * (Math.PI / 180.0) - num1;
            var d3 = Math.Pow(Math.Sin((d2 - d1) / 2.0), 2.0) + Math.Cos(d1) * Math.Cos(d2) * Math.Pow(Math.Sin(num2 / 2.0), 2.0);
            return 6376500.0 * (2.0 * Math.Atan2(Math.Sqrt(d3), Math.Sqrt(1.0 - d3)));
        }
    }
}
