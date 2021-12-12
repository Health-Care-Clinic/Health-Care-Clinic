namespace ClinicCore.DTOs
{
    public class WorkDayDTO
    {
        public string Monday { get; set; }
        public string Tuesday { get; set; }
        public string Wednesday { get; set; }
        public string Thursday { get; set; }
        public string Friday { get; set; }
        public string Saturday { get; set; }

        public WorkDayDTO(string monday, string tuesday, string wednesday, string thursday, string friday, string saturday)
        {
            Monday = monday;
            Tuesday = tuesday;
            Wednesday = wednesday;
            Thursday = thursday;
            Friday = friday;
            Saturday = saturday;
        }
    }
}
