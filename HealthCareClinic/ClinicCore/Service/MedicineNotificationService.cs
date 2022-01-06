using Model;
using Storages;
using System.Collections.Generic;

namespace Service
{
    public class MedicineNotificationService
    {
        private MedicineNotificationStorage mnfs = new MedicineNotificationStorage();
        public List<MedicineNotification> AllNotification { get; set; } = new List<MedicineNotification>();

        private static MedicineNotificationService instance = null;
        public static MedicineNotificationService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MedicineNotificationService();
                }
                return instance;
            }
        }

        private MedicineNotificationService()
        {
            AllNotification = mnfs.GetAll();
        }
        public List<MedicineNotification> GetAllByDoctorId(int idDoctor)
        {
            List<MedicineNotification> notificationForDoctor = new List<MedicineNotification>();
            foreach(MedicineNotification medicineNotification in AllNotification)
            {
                if (medicineNotification.RecieverIds.Contains(idDoctor))
                {
                    notificationForDoctor.Add(medicineNotification);
                }
            }
            return notificationForDoctor;
        }

        public void AddNotification(MedicineNotification medicineNotification)
        {
            AllNotification.Add(medicineNotification);
            mnfs.Save(AllNotification);
        }

        public void UpdateMedicineNotification(MedicineNotification reviewdNotification)
        {
            for(int i = 0; i< AllNotification.Count; i++)
            {
                if (AllNotification[i].Medicine.Name.Equals(reviewdNotification.Medicine.Name))
                {
                    AllNotification.RemoveAt(i);
                    AllNotification.Insert(i, reviewdNotification);
                    mnfs.Save(AllNotification);
                }
            }
        }

        public void AddApprovalDeleteDoctor(MedicineNotification rewiewdNotification,int activeDoctor)
        {
            rewiewdNotification.ApprovalCounter++;

            rewiewdNotification.RecieverIds.Remove(activeDoctor);

            bool isApproved =  CheckIfMedicineIsApproved(rewiewdNotification);

            if (rewiewdNotification.RecieverIds.Count == 0 || isApproved)
            {
                DeleteMedicineNotification(rewiewdNotification);
            }
            else
            {
                UpdateMedicineNotification(rewiewdNotification);
            }
        }

        private  bool CheckIfMedicineIsApproved(MedicineNotification rewiewdNotification)
        {
            bool isApproved = false;
            if (rewiewdNotification.ApprovalCounter >= 2)
            {
                MedicineService.Instance.AddNewMedicine(rewiewdNotification.Medicine);
                isApproved = true;
            }
            return isApproved;
        }

        public void DeleteMedicineNotification(MedicineNotification reviewdNotification)
        {
            for (int i = 0; i < AllNotification.Count; i++)
            {
                if (AllNotification[i].Medicine.Name.Equals(reviewdNotification.Medicine.Name))
                {
                    AllNotification.RemoveAt(i);
                    mnfs.Save(AllNotification);
                }
            }
        }

        public void DeleteNotification(MedicineNotification medicineNotification)
        {
            AllNotification.Remove(medicineNotification);
            mnfs.Save(AllNotification);
        }

        public List<MedicineNotification> GetAll()
        {
            return AllNotification;
        }
    }
}
