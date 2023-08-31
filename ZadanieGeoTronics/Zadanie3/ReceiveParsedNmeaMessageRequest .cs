using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZadanieGeoTronics.Zadanie1;

namespace ZadanieGeoTronics.Zadanie3
{
    public class ReceiveParsedNmeaMessageRequest : IRequest<Unit>
    {
        public string ParsedNmeaData { get; set; }
    }
}
