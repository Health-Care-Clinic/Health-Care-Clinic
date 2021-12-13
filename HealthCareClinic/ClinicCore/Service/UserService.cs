using System.Collections.Generic;

namespace Service
{
    public class UserService
    {
        public List<int> AllUserIDs { get; set; } = new List<int>();

        public int MaxId {get; set;}

        private static UserService instance = null;
        public static UserService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserService();
                }
                return instance;
            }
        }

        private UserService()
        {
        }

        public void GetAllUsersIDs()
        {

            AllUserIDs = AdministrationEmployeeService.Instance.GetEmployeIDs();
            AllUserIDs.AddRange(DoctorService.Instance.GetDoctorIds());
            AllUserIDs.AddRange(PatientService.Instance.GetPatientIDs());

        }

        public void FindMaxID()
        {
            int max = 0;
            foreach(int id in AllUserIDs)
            {
                if (max < id)
                {
                    max = id;
                }
            }

            MaxId = max;
        }

        public int GenerateUserID()
        {
            FindMaxID();
            AllUserIDs.Add(++MaxId);
            return MaxId;
        }

    }
}
