namespace ClinicCore.DTOs
{
    public class BranchWorkerDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Speciality { get; set; }

        public BranchWorkerDTO(string name, string surname, string specilaity)
        {
            Name = name;
            Surname = surname;
            Speciality = specilaity;
        }
    }
}
