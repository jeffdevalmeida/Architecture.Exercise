namespace BTG.Task.Domain.Services.Notification
{
    public class NotificationSender
    {
        private readonly IWorkNotification _worker;

        public NotificationSender(IWorkNotification worker)
        {
            _worker = worker;
        }

        public void Notify(string email)
        {
            Console.WriteLine("Iniciando processo de notificação...");
            _worker.Send(email);
            Console.WriteLine("Encerrando processo de notificação...");
        }
    }
}
