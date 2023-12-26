namespace BTG.Task.Api.Services.Notification
{
    public class TeamsNotification : IWorkNotification
    {
        public void Send(string mailTarget, string message)
        {
            // CONNECTION WITH GRAPH FOR AUTH
            // CONNECTION WITH TEAMS API
            Console.WriteLine($"Enviando mensagem via Teams para o destinatário: <{mailTarget}>");
            Console.WriteLine($"Mensagem de envio: <{message}>");
            Console.WriteLine($"Mensagem enviada com sucesso");
        }
    }
}
