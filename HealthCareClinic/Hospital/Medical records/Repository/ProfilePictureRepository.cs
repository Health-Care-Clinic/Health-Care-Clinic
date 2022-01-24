using Hospital.Mapper;
using Hospital.Medical_records.Model;
using Hospital.Medical_records.Repository.Interface;
using Hospital.Shared_model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hospital.Medical_records.Repository
{
    public class ProfilePictureRepository : Repository<ProfilePicture>, IProfilePictureRepository
    {
        private readonly HospitalDbContext dbContext;

        public ProfilePictureRepository(HospitalDbContext context) : base(context)
        {
            dbContext = context;
        }

        public ProfilePicture GetByPatientId(int patientId)
        {
            return dbContext.ProfilePictures.SingleOrDefault(pic => pic.PatientId == patientId);
        }
    }
}
