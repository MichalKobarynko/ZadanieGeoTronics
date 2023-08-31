using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadanieGeoTronics.Zadanie1
{
    public class NMEAHandler
    {
        public static NMEAMessage ParseMessage(string message)
        {
            NMEAMessage nmea = new NMEAMessage();


            try
            {
                int checksumIndex = message.IndexOf('*');

                if (checksumIndex != -1)
                {
                    nmea.Checksum = int.Parse(message.Substring(checksumIndex + 1), NumberStyles.HexNumber);
                    message = message.Substring(0, checksumIndex);
                }

                string[] fields = message.Split(',');


                nmea.HeaderType = fields[0];
                nmea.Time = TimeSpan.ParseExact(fields[1], "hhmmss\\.ff", null);
                nmea.Latitude = double.Parse(fields[2].Replace('.', ',')) / 100;
                nmea.LatitudeDirection = fields[3];
                nmea.Longitude = double.Parse(fields[4].Replace('.', ',')) / 100;
                nmea.LongitudeDirection = fields[5];
                nmea.Quality = int.Parse(fields[6]);
                nmea.Satellites = int.Parse(fields[7]);
                nmea.HDOP = double.Parse(fields[8].Replace('.', ','));
                nmea.Altitude = double.Parse(fields[9].Replace('.', ','));
                nmea.AltitudeDirection = fields[10];
                nmea.GeoidalHeight = double.Parse(fields[11].Replace('.', ','));
                nmea.GeoidalDirection = fields[12];
                nmea.AgeOfDGPSData = double.Parse(fields[13].Replace('.', ','));
                nmea.DGPSStationID = int.Parse(fields[14]);
                return nmea;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public static void DisplayMessage(NMEAMessage message)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"Nagłówek:                               {message.HeaderType}");
            Console.WriteLine($"Czas:                                   {message.Time}");
            Console.WriteLine($"Szerokość geog.:                        {message.Latitude}");
            Console.WriteLine($"Szerokość geog. (kierunek):             {message.LatitudeDirection}");
            Console.WriteLine($"Długość geog.:                          {message.Longitude}");
            Console.WriteLine($"Długość geog. (kierunek):               {message.LongitudeDirection}");
            Console.WriteLine($"Jakośc odczytu:                         {message.Quality}");
            Console.WriteLine($"Ilość satelit:                          {message.Satellites}");
            Console.WriteLine($"Horyzontalna dokładność pozycji:        {message.HDOP}");
            Console.WriteLine($"Wysokośc nad poziomem morza:            {message.Altitude}");
            Console.WriteLine($"Wysokośc nad poziomem morza (kierunem): {message.AltitudeDirection}");
            Console.WriteLine($"Wysokośc geoidy:                        {message.GeoidalHeight}");
            Console.WriteLine($"Wysokośc geoidy (kierunek):             {message.GeoidalDirection}");
            Console.WriteLine($"Wiek danych:                            {message.AgeOfDGPSData}");
            Console.WriteLine($"ID stacji DGPS:                         {message.DGPSStationID}");
            Console.WriteLine($"Suma kontrolna:                         {message.Checksum}");

        }
    }
}
