using BTG.Task.Domain.Entities;
using BTG.Task.Domain.Services.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTG.Task.Domain.Services
{
    public static class NotificationService
    {
        public static void SendClosedNotification(TaskAssignment task)
        {
            IWorkNotification worker = task.CompletedOn!.Value >= task.DeadLine!.Value ?
                new EmailNotification() : new TeamsNotification();

            NotificationSender sender = new(worker);
            sender.Notify(task.Responsible);
        }
    }
}
