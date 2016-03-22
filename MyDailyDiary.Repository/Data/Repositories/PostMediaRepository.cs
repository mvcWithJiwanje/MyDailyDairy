using MyDailyDairy.Data.EF;
using MyDailyDiary.Repository.Data.Repositories;
using System.Data.Entity;
using System.Linq;
using Uow.Package.Models;

namespace Uow.Package.Data.Repositories
{
    public class PostMediaRepository : Repository<PostMedia>, IPostMediaRepository
    {
        public PostMediaRepository(DbContext dbContext)
            : base(dbContext)
        {
        }        
    }
}