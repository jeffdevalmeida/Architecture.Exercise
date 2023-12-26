namespace BTG.Task.Domain.Services.Notification
{
    public class EmailNotification : IWorkNotification
    {
        public void Send(string mailTarget)
        {
            // SMTP CONNECTION
            // CREDENTIALS VALIDATION
            // ETC
            Console.WriteLine("Enviando notificação por e-mail");
            Console.WriteLine($"Destinatário: <{mailTarget}>");
            Console.WriteLine($"Adicionando cópia oculta para o diretor");
            Console.WriteLine($"Corpo da mensagem: <'Olá {mailTarget}, identifiquei que você concluiu uma atividade! Parabéns! Mas, sua " +
                $"atividade foi entregue fora do prazo definido. Fique atento nas definições de prazos das atividades!'>");
            Console.WriteLine("SMTP disparado");
        }
    }
}
