namespace BTG.Task.Domain.Services.Notification
{
    public interface IWorkNotification
    {
        public void Send(string mailTarget);
    }
}
