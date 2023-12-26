namespace BTG.Task.Api.Services.Notification
{
    public class NotificationSender
    {
        private readonly IWorkNotification _worker;

        public NotificationSender(IWorkNotification worker)
        {
            _worker = worker;
        }

        public void Notify(string email, string message)
        {
            Console.WriteLine("Iniciando processo de notificação...");
            _worker.Send(email, message);
            Console.WriteLine("Encerrando processo de notificação...");
        }
    }
}
