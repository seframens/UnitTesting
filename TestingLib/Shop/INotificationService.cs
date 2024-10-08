namespace TestingLib.Shop
{
    public interface INotificationService
    {
        void SendNotification(string email, string message);
    }
}
