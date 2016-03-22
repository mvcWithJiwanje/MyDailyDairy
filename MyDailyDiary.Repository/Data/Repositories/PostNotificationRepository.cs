using MyDailyDairy.Data.EF;
using MyDailyDiary.Repository.Data.Repositories;
using System.Data.Entity;
using System.Linq;
using Uow.Package.Models;

namespace Uow.Package.Data.Repositories
{
    public class PostNotificationRepository : Repository<PostNotification>, IPostNotificationRepository
    {
        public PostNotificationRepository(DbContext dbContext)
            : base(dbContext)
        {
        }        
    }
}