using System;
using System.Collections.Generic;

namespace Model
{
    public class Manager : Employee
    {

        public Manager(int id, string name, string surname, DateTime birthDate, string email, string password, string address, double salary, DateTime employmentDate, List<WorkDay> workDays) : base(id, name, surname, birthDate, email, password, address, salary, employmentDate, workDays)
        {
        }

        private static Manager instance = null;

        private Manager()
        {
        }

        public static Manager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Manager();
                }
                return instance;
            }
        }


       


        public Boolean MakeAppointment(Room room)
        {
            throw new NotImplementedException();
        }

        public Boolean RemoveAppointment(Appointment appointment)
        {
            throw new NotImplementedException();
        }


    }
}
