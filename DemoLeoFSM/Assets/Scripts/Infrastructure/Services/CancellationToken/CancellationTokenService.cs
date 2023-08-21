using System.Threading;

namespace Infrastructure.Services.CancellationToken
{
    public class CancellationTokenService : ICancellationTokenService
    {
        private readonly System.Threading.CancellationToken _cancellationToken;
        private readonly CancellationTokenSource _cancellationTokenSource;

        public CancellationTokenService()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            _cancellationToken = _cancellationTokenSource.Token;
        }

        public System.Threading.CancellationToken GetCancellationToken() =>
            _cancellationToken;

        public CancellationTokenSource GetCancellationTokenSource() =>
            _cancellationTokenSource;
    }
}