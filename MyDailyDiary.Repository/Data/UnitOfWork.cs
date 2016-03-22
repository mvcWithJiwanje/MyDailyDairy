using MyDailyDiary.Repository.Data.Repositories;
using Uow.Package.Data.Repositories;

namespace Uow.Package.Data
{
    /// <summary>
    /// Unit of work provides access to repositories.  Operations on multiple repositories are atomic through
    /// the use of Commit().
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        //private readonly CustomerContext db = new CustomerContext();

        private readonly MyDailyDairy.Data.EF.MyDailyDiaryEntities db = new MyDailyDairy.Data.EF.MyDailyDiaryEntities();

        //private ICustomerRepository customers;
        //public ICustomerRepository Customers { get { return customers ?? (customers = new CustomerRepository(db)); } }

        private IUserRepository users;
        public IUserRepository Users { get { return users ?? (users = new UserRepository(db)); } }

        private IRoleRepository roles;
        public IRoleRepository Roles { get { return roles ?? (roles = new RoleRepository(db)); } }

        private IPostRepository posts;
        public IPostRepository Posts { get { return posts ?? (posts = new PostRepository(db)); } }

        private IPostMediaRepository postmedia;
        public IPostMediaRepository PostMedias { get { return postmedia ?? (postmedia = new PostMediaRepository(db)); } }

        private ILanguageRepository language;
        public ILanguageRepository Languages { get { return language ?? (language = new LanguageRepository(db)); } }

        private IPostNotificationRepository postnotification;
        public IPostNotificationRepository PostNotifications { get { return postnotification ?? (postnotification = new PostNotificationRepository(db)); } }


        /// <summary>
        /// Factoring method for starting a new UOW
        /// </summary>
        public static IUnitOfWork Begin()
        {
            return DataContainer.Resolve<IUnitOfWork>();
        }

        /// <summary>
        /// Commits changes made to all repositories
        /// </summary>
        public void Commit()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
