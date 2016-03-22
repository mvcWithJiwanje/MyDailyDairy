using MyDailyDairy.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uow.Package.Data.Repositories;

namespace MyDailyDiary.Repository.Data.Repositories
{
    public interface ILanguageRepository : IRepository<Language>
    {
    }
}
