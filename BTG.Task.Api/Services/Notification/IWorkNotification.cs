namespace BTG.Task.Api.Services.Notification
{
    public interface IWorkNotification
    {
        public void Send(string mailTarget, string message);
    }
}
