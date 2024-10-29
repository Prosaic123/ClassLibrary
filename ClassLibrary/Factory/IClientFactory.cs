using ClassLibrary.Client;

namespace ClassLibrary.Factory
{
    public interface IClientFactory
    {
        IClient Creat(ClientOptions options, ClientType clientType);

        IClient Get(string ipAddress);
    }
}