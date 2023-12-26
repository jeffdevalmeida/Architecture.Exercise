namespace BTG.Task.Domain.Services.Notification
{
    public class TeamsNotification : IWorkNotification
    {
        public void Send(string mailTarget)
        {
            // CONNECTION WITH GRAPH FOR AUTH
            // CONNECTION WITH TEAMS API
            Console.WriteLine($"Enviando mensagem via Teams para o destinatário: <{mailTarget}>");
            Console.WriteLine($"Mensagem de envio: <'Olá {mailTarget}, parabéns pela conclusão da sua tarefa no prazo definido!'>");
            Console.WriteLine($"Mensagem enviada com sucesso");
        }
    }
}
