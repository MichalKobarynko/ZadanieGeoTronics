using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using ZadanieGeoTronics.Zadanie1;

namespace ZadanieGeoTronics.Zadanie2
{
    public class ParseNMEAMessageHandler : IRequestHandler<ParseNmeaMessageRequest, NMEAMessage>
    {
        private readonly Channel<NMEAMessage> Chanel;

        public ParseNMEAMessageHandler(Channel<NMEAMessage> chanel)
        {
            this.Chanel = chanel;
        }
        public async Task<NMEAMessage> Handle(ParseNmeaMessageRequest request, CancellationToken cancellationToken)
        {
            while(!cancellationToken.IsCancellationRequested)
            {
                var nmea = NMEAHandler.ParseMessage(request.NmeaString);

                await Chanel.Writer.WriteAsync(nmea, cancellationToken);

                await Task.Delay(1000, cancellationToken);
            }

            return null;
        }
    }
}
