namespace ClassLibrary.Client
{
    public interface IClient
    {
        Task ConnectAsync(ClientOptions options, CancellationToken cancellationToken);
    }
}