using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassLibrary.Client
{
    public class TcpClient : IClient
    {
        private readonly TcpClient _client;

        public TcpClient(string ipAddress, int port)
        {
            _client = new TcpClient(ipAddress, port);
        }

        public Task ConnectAsync()
        {
            throw new NotImplementedException();
        }
    }
}