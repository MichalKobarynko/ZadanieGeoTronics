using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using ZadanieGeoTronics.Zadanie1;

namespace ZadanieGeoTronics.Zadanie3
{
    public class ReceiveParsedNmeaMessageHandler : IRequestHandler<ReceiveParsedNmeaMessageRequest, Unit>
    {
        private readonly Channel<NMEAMessage> Chanel;

        public ReceiveParsedNmeaMessageHandler(Channel<NMEAMessage> chanel)
        {
            this.Chanel = chanel;
        }

        public async Task<Unit> Handle(ReceiveParsedNmeaMessageRequest request, CancellationToken cancellationToken)
        {
            try
            {
                while (await Chanel.Reader.WaitToReadAsync(cancellationToken))
                {
                    if (Chanel.Reader.TryRead(out var item))
                    {
                        NMEAHandler.DisplayMessage(item);
                    }
                }
            }
            catch (OperationCanceledException)
            {
                return Unit.Value;
            }

            return Unit.Value;
        }
    }
}
