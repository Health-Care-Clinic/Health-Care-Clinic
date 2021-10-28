using ClinicCore.Storages;
using Model;
using System;
using System.Collections.Generic;

namespace ClinicCore.Service
{
    public class NotificationService
    {
        private NotificationFileStorage nfs = new NotificationFileStorage();

        public List<Notification> AllNotifications { get; set; }

        private static NotificationService instance = null;
        public static NotificationService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new NotificationService();
                }
                return instance;
            }
        }

        private NotificationService()
        {
            AllNotifications = nfs.GetAll();
        }

        public List<Notification> GetAllByUser(int userId)
        {
            List<Notification> userNotifications = new List<Notification>();

            foreach (Notification notif in AllNotifications)
            {
                foreach (int id in notif.Recipients)
                {
                    if (userId == id)
                        userNotifications.Add(notif);
                }
            }

            return userNotifications;
        }

        public void ReloadNotifications()
        {
            AllNotifications = nfs.GetAll();
        }

        public void AddNotification(Notification notification)
        {
            AllNotifications.Insert(0, notification);

            nfs.SaveNotifications(AllNotifications);
        }

        public void UpdateNotification(Notification notification)
        {

            for (int i = 0; i < AllNotifications.Count; i++)
            {
                if (notification.Id.Equals(AllNotifications[i].Id))
                {
                    AllNotifications.Remove(AllNotifications[i]);
                    AllNotifications.Insert(i, notification);
                }
            }

            nfs.SaveNotifications(AllNotifications);
        }

        public void DeleteNotification(Notification notification)
        {
            for (int i = 0; i < AllNotifications.Count; i++)
            {
                if (notification.Id.Equals(AllNotifications[i].Id))
                {
                    AllNotifications.Remove(AllNotifications[i]);
                }
            }

            nfs.SaveNotifications(AllNotifications);
        }

        public void SendAppointmentCancelationNotification(DoctorAppointment docAppointment)
        {
            string title = "Otkazan pregled";

            string text = "Pregled koji ste imali " + docAppointment.AppointmentStart.ToString("dd.MM.yyyy.") + " u "
                + docAppointment.AppointmentStart.ToString("HH:mm") + "h je otkazan.";

            Notification notification = new Notification(title, text, DateTime.Now);
            notification.Recipients.Add(docAppointment.Patient.Id);
            notification.Recipients.Add(docAppointment.Doctor.Id);

            AddNotification(notification);
        }

        public void SendAppointmentRescheduledNotification(DoctorAppointment oldApp, DoctorAppointment appointment)
        {
            string title = "Pomeren pregled";

            string text = "Pregled koji ste imali " + oldApp.AppointmentStart.ToString("dd.MM.yyyy.") + " u "
                + oldApp.AppointmentStart.ToString("HH:mm") + "h je pomeren za "
                + appointment.AppointmentStart.ToString("dd.MM.yyyy.") + " u " + appointment.AppointmentStart.ToString("HH:mm") + "h.";

            Notification notification = new Notification(title, text, DateTime.Now);
            notification.Recipients.Add(appointment.Patient.Id);
            notification.Recipients.Add(appointment.Doctor.Id);

            AddNotification(notification);
        }


        public List<Notification> GetPrescriptionNotification(int doctorId)
        {
            List<Notification> notifications = new List<Notification>();
            foreach (Notification notification in AllNotifications)
            {
                if (notification.Recipients.Contains(doctorId) && notification.Title.Contains("Izdavanje recepta"))
                {
                    notifications.Add(notification);
                }
            }

            return notifications;
        }

    }
}
