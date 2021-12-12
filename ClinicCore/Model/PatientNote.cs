namespace ClinicCore.Model
{
    public class PatientNote
    {
        public int NotificationTime { get; set; }
        public bool IsNotifyChecked { get; set; }
        public string NoteContent { get; set; }
        public int AppointmentId { get; set; }

        public PatientNote(int notificationTime, bool isNotifyChecked, string noteContent, int appointmentId)
        {
            this.NotificationTime = notificationTime;
            this.IsNotifyChecked = isNotifyChecked;
            this.NoteContent = noteContent;
            this.AppointmentId = appointmentId;
        }
    }
}
