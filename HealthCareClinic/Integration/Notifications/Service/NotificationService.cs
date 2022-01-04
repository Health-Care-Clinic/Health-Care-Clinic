using System;
using System.Collections.Generic;
using Integration.Interface.Repository;
using Integration.Interface.Service;
using Integration.Notifications.Model;

namespace Integration.Notifications.Service
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;

        public NotificationService(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public void Add(Notification entity)
        {
            _notificationRepository.Add(entity);
        }

        public IEnumerable<Notification> GetAll()
        {
            var notifications = _notificationRepository.GetAll();
            return notifications;
        }

        public Notification GetOneById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Notification entity)
        {
            _notificationRepository.Remove(entity);
        }

        public void SaveChanges()
        {
            _notificationRepository.Save();
        }

        public void MarkAllAsSeen()
        {
            var notifications = GetAll();

            foreach (Notification notification in notifications)
            {
                Remove(notification);
                notification.Seen = true;
                Add(notification);
            }
        }

        public void CreateNewFileNotification(string filename)
        {
            Notification fileNotifiction = new Notification("New File Downloaded", "File " + filename + " has been downloded. It can be found in assets folder.");
            Add(fileNotifiction);
            SaveChanges();
        }

        public IEnumerable<Notification> CreateDummy()
        {
            Notification n1 = new Notification("Hello Notification", " Ut tortor pretium viverra suspendisse. Consectetur purus ut faucibus pulvinar elementum. Senectus et netus et malesuada fames ac turpis egestas.", new DateTime(2021, 12, 4, 14, 38, 11), false);
            Add(n1);
            Notification n2 = new Notification("Test 1", "Eu scelerisque felis imperdiet proin. Arcu ac tortor dignissim convallis aenean et. Nisi scelerisque eu ultrices vitae auctor eu augue ut lectus.", new DateTime(2021, 12, 5, 18, 31, 17), false);
            Add(n2);
            Notification n3 = new Notification("Test 2", "In tellus integer feugiat scelerisque varius. Amet nulla facilisi morbi tempus iaculis urna id.", new DateTime(2021, 12, 7, 11, 25, 41), false);
            Add(n3);
            Notification n4 = new Notification("Test 3", "Ac feugiat sed lectus vestibulum mattis. Integer feugiat scelerisque varius morbi. In pellentesque massa placerat duis ultricies lacus sed turpis tincidunt.", new DateTime(2021, 12, 7, 15, 2, 46), false);
            Add(n4);
            return GetAll();
        }

        

    }
}
