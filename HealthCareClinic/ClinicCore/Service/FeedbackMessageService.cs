using ClinicCore.Model;
using ClinicCore.Storages;
using System.Collections.Generic;

namespace ClinicCore.Service
{
    public class FeedbackMessageService
    {
        public List<FeedbackMessage> AllMessages { get; set; }
        private FeedbackFileStorage ffs = new FeedbackFileStorage();

        private static FeedbackMessageService instance = null;
        public static FeedbackMessageService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FeedbackMessageService();
                }
                return instance;
            }
        }

        private FeedbackMessageService()
        {
            AllMessages = ffs.GetAll();
        }

        public void AddFeedbackMessage(FeedbackMessage message)
        {
            AllMessages.Insert(0, message);
            ffs.SaveMessage(AllMessages);
        }
    }
}
