using ClinicCore.Service;
using Integration.Notifications.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Interface.Service
{
    public interface INotificationService : IService<Notification>
    {
        void SaveChanges();

        void MarkAllAsSeen();

        void CreateNewFileNotification(string filename);

        IEnumerable<Notification> CreateDummy();

        //int CheckForNewFileNotifications();

        //int GetUnseenNotificationsNumber();
    }
}
