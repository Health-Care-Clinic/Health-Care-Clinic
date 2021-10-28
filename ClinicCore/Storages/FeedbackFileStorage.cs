using ClinicCore.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace ClinicCore.Storages
{
    class FeedbackFileStorage
    {
        private string fileLocation;

        public FeedbackFileStorage()
        {
            this.fileLocation = "../../../FileStorage/feedbackMessages.json";
        }
        public List<FeedbackMessage> GetAll()
        {
            /*String text = File.ReadAllText(this.fileLocation);
            List<FeedbackMessage> messages = JsonConvert.DeserializeObject<List<FeedbackMessage>>(text);

            return messages;*/
            return null;
        }

        public void SaveMessage(List<FeedbackMessage> messages)
        {
            /*var file = JsonConvert.SerializeObject(messages, Formatting.Indented);
            using (StreamWriter writer = new StreamWriter(this.fileLocation))
            {
                writer.Write(file);
            }*/
        }
    }
}
