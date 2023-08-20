using System.Threading;

namespace Infrastructure.Services.CancellationToken
{
    internal interface ICancellationTokenService
    {
        public System.Threading.CancellationToken GetCancellationToken();
        public CancellationTokenSource GetCancellationTokenSource();
    }
}