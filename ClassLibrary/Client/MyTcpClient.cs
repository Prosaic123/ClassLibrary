using System.Net.Sockets;
using Microsoft.Extensions.Logging;

namespace ClassLibrary.Client
{
    public class MyTcpClient : IClient
    {
        private TcpClient _client;
        private readonly ILogger<MyTcpClient> _logger;

        private long _status = (long)ClientStatus.Disconnected;

        private NetworkStream? _stream;

        private CancellationTokenSource? _cancellationTokenSource;

        public MyTcpClient(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<MyTcpClient>();
        }

        public async Task ConnectAsync(ClientOptions options, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (ConnectIsPending())
            {
                _client = new TcpClient();

                await _client.ConnectAsync(options.IPAddress!, options.Port, cancellationToken).ConfigureAwait(false);

                _stream = _client.GetStream();

                Interlocked.Exchange(ref _status, (int)ClientStatus.Connected);

                _cancellationTokenSource = new CancellationTokenSource();

                // 开启TCP心跳线程
                _ = Task.Run(() => { });
            }
        }

        private bool ConnectIsPending() =>
            Interlocked.CompareExchange(
                ref _status,
                (int)ClientStatus.Connecting,
                (int)ClientStatus.Disconnected) == (int)ClientStatus.Disconnected;
    }
}