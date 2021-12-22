using ClinicCore.Storages;
using Integration.Interface.Repository;
using Integration.Notifications.Model;

namespace Integration.Notifications.Repository
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
