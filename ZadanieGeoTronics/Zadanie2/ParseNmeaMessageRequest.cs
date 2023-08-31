using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZadanieGeoTronics.Zadanie1;

namespace ZadanieGeoTronics.Zadanie2
{
    public class ParseNmeaMessageRequest : IRequest<NMEAMessage>
    {
        public string NmeaString { get; }

        public ParseNmeaMessageRequest(string nmeaString)
        {
            NmeaString = nmeaString;
        }
    }
}
