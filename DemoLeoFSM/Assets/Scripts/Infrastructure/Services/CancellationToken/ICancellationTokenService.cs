using System.Threading;

namespace Infrastructure.Services.CancellationToken
{
    public interface ICancellationTokenService
    {
        public System.Threading.CancellationToken GetCancellationToken();
        public CancellationTokenSource GetCancellationTokenSource();
    }
}