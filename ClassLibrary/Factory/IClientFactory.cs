using ClassLibrary.Client;

namespace ClassLibrary.Factory
{
    public interface IClientFactory
    {
        IClient Creat(ClientOptions options);

        IClient Get(string type);
    }
}