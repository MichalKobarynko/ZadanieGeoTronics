using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadanieGeoTronics.Zadanie1
{
    public class NMEAMessage 
    {
        public string HeaderType { get; set; }
        public TimeSpan Time { get; set; }
        public double Latitude { get; set; }
        public string LatitudeDirection { get; set; }
        public double Longitude { get; set; }
        public string LongitudeDirection { get; set; }
        public int Quality { get; set; }
        public int Satellites { get; set; }
        public double HDOP { get; set; }
        public double Altitude { get; set; }
        public string AltitudeDirection { get; set; }
        public double GeoidalHeight { get; set; }
        public string GeoidalDirection { get; set; }
        public double AgeOfDGPSData { get; set; }
        public int DGPSStationID { get; set; }
        public int Checksum { get; set; }
    }
}
