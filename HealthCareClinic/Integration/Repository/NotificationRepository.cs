using ClinicCore.Storages;
using Integration.Interface.Repository;
using Integration.Notifications.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Repository
{
    public class NotificationRepository : Repository<Notification>, INotificationRepository
    {
        public NotificationRepository(IntegrationDbContext dbContext) : base(dbContext)
        {
        }

        public IntegrationDbContext IntegrationDbContext
        {
            get { return Context as IntegrationDbContext; }
        }
    }
}
