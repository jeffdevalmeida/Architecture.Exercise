namespace BTG.Task.Api.Services.Notification
{
    public class EmailNotification : IWorkNotification
    {
        public void Send(string mailTarget, string message)
        {
            // SMTP CONNECTION
            // CREDENTIALS VALIDATION
            // ETC
            Console.WriteLine("Enviando notificação por e-mail");
            Console.WriteLine($"Destinatário: <{mailTarget}>");
            Console.WriteLine($"Adicionando cópia oculta para o diretor");
            Console.WriteLine($"Corpo da mensagem: <{message}>");
            Console.WriteLine("SMTP disparado");
        }
    }
}
