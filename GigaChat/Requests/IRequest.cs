namespace GigaChat.Requests
{
    public interface IRequest<T>
    {
        Task<T?> Send();
    }
}