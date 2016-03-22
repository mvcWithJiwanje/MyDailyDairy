using MyDailyDairy.Data.EF;
using MyDailyDiary.Repository.Data.Repositories;
using System.Data.Entity;
using System.Linq;
using Uow.Package.Models;

namespace Uow.Package.Data.Repositories
{
    public class LanguageRepository : Repository<Language>, ILanguageRepository
    {
        public LanguageRepository(DbContext dbContext)
            : base(dbContext)
        {
        }        
    }
}