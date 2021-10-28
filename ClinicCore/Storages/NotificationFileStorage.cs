using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;


namespace ClinicCore.Storages
{
    class NotificationFileStorage
    {
        private string fileLocation;

        public NotificationFileStorage()
        {
            this.fileLocation = "../../../FileStorage/notifications.json";
        }

        public List<Notification> GetAll()
        {
            /*String text = File.ReadAllText(this.fileLocation);
            List<Notification> notifications = JsonConvert.DeserializeObject<List<Notification>>(text);

            return notifications;*/
            return null;
        }

        public void SaveNotifications(List<Notification> notifications)
        {
            /*var file = JsonConvert.SerializeObject(notifications, Formatting.Indented);
            using (StreamWriter writer = new StreamWriter(this.fileLocation))
            {
                writer.Write(file);
            }*/
        }
    }
}
