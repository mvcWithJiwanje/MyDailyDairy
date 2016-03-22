using MyDailyDairy.Data.EF;
using MyDailyDiary.Repository.Data.Repositories;
using System.Data.Entity;
using System.Linq;
using Uow.Package.Models;

namespace Uow.Package.Data.Repositories
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(DbContext dbContext)
            : base(dbContext)
        {
        }        
    }
}