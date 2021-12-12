using System;

namespace Model
{
    public class Test
    {
        public String Name { get; set; }
        public DateTime SampleDate { get; set; }
        public String Result { get; set; }

        public Test(string name, DateTime sampleDate, string result)
        {
            Name = name;
            SampleDate = sampleDate;
            Result = result;
        }
    }
}