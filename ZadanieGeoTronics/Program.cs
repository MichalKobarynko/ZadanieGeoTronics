using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using ZadanieGeoTronics.Zadanie1;
using ZadanieGeoTronics.Zadanie2;
using ZadanieGeoTronics.Zadanie3;
using ZadanieGeoTronics.Zadanie4;

namespace ZadanieGeoTronics
{
    internal class Program
    {
        public static string messageString = "$GPGGA,122741.00,5002.02175749,N,02202.23163845,E,2,10,0.8,259.914,M,0.000,M,5.0,0136*7A";
        static void Main(string[] args)
        {
            Channel<NMEAMessage> channel = Channel.CreateUnbounded<NMEAMessage>();

            var services = new ServiceCollection().AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly))
                                                  .AddSingleton(channel)
                                                  .BuildServiceProvider();

            
            var mediator = services.GetRequiredService<IMediator>();

            //Uruchomienie klasy handlera z zadania 2
            var result1 = mediator.Send(new ParseNmeaMessageRequest(messageString));

            //Uruchomienie klasy handlera z zadania 3
            var result2 = mediator.Send(new ReceiveParsedNmeaMessageRequest());
            

            while (true)
            {
                //Rozwiązanie zadania 1
                Zadanie1();

                //Rozwiązanie zadania 4
                Zadanie4();

                Console.ReadKey();
            }
        }
        private static void Zadanie1()
        {
            var nmea = NMEAHandler.ParseMessage(messageString);
            NMEAHandler.DisplayMessage(nmea);
        }

        private static void Zadanie4()
        {
            double lat1 = 53.806096, lon1 = 20.411462;
            double lat2 = 53.785235, lon2 = 20.564721;
            double lat3 = 53.748066, lon3 = 20.427405;

            double distance12 = Helpers.DistanceBetweenPoints(lat1, lon1, lat2, lon2);
            double distance23 = Helpers.DistanceBetweenPoints(lat2, lon2, lat3, lon3);
            double distance31 = Helpers.DistanceBetweenPoints(lat3, lon3, lat1, lon1);

            double area = Helpers.TriangleArea(distance12, distance23, distance31);
            Console.WriteLine();
            Console.WriteLine($"Pole trójkąta wynosi: {area} km2");
        }
    }
}
