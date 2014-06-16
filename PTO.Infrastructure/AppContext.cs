using PTO.Core;
using PTO.Core.Config;
using PTO.Core.Interfaces;
using PTO.Entity;
using PTO.Entity.Logging;
using PTO.Entity.Renweb;
using PTO.Infrastructure.Mapping;
using PTO.Infrastructure.Mapping.Logging;
using PTO.Infrastructure.Mapping.Renweb;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace PTO.Infrastructure
{
    public class AppContext : AppDbContext, IUnitOfWork
    {
        static AppContext()
        {
            //Database.SetInitializer(new AppContextInitializer());
            Database.SetInitializer<AppContext>(null);
        }

        public AppContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        //public DbSet<Email> ApplicationEmails { get; set; }
        //public DbSet<EmailUnsubscribed> EmailUnsubscribed { get; set; }
        //public DbSet<EmailBlacklist> EmailBlacklists { get; set; }
        //public DbSet<Recipient> Recipients { get; set; }
        //public DbSet<Template> Templates { get; set; }
        //public DbSet<TemplateSection> TemplateSections { get; set; }
        //public DbSet<Layout> Layouts { get; set; }
        //public DbSet<LayoutSection> LayoutSections { get; set; }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Relationship> Relationships { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserAccountInfo> UserAccountInfos { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<UserEmail> UserEmails { get; set; }
        public DbSet<UserLogin> UserLogins { get; set; }
        public DbSet<UserPhone> UserPhones { get; set; }

        // Logging
        public DbSet<Log> Logs { get; set; }

        // Renweb
        public DbSet<RenwebClassInfoResult> RenwebClassInfoResults { get; set; }
        public DbSet<RenwebFamilyMembersResult> RenwebFamilyMembersResults { get; set; }
        public DbSet<RenwebFamilyResult> RenwebFamilyResults { get; set; }
        public DbSet<RenwebGradeLevelResult> RenwebGradeLevelResults { get; set; }
        public DbSet<RenwebSchoolResult> RenwebSchoolResults { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Add discrimators for inheritance hierarchies first
            modelBuilder.Entity<User>()
                //.Map<Administration>(m => m.Requires("UserTypeId").HasValue("2"))
                //.Map<Staff>(m => m.Requires("UserTypeId").HasValue("2"))
                //.Map<Teacher>(m => m.Requires("UserTypeId").HasValue("3"))
                .Map<Student>(m => m.Requires("UserTypeId").HasValue("4"))
                .Map<Parent>(m => m.Requires("UserTypeId").HasValue("5"));

            //modelBuilder.Entity<Email>();


            // Configuration definitions

            // It is important that base classes be mapped before their subclasses
            modelBuilder.Configurations.Add(new UserMap());
            //modelBuilder.Configurations.Add(new AdministrationMap());
            //modelBuilder.Configurations.Add(new StaffMap());
            //modelBuilder.Configurations.Add(new TeacherMap());
            modelBuilder.Configurations.Add(new StudentMap());
            modelBuilder.Configurations.Add(new ParentMap());

            modelBuilder.Configurations.Add(new CourseMap());
            modelBuilder.Configurations.Add(new EnrollmentMap());
            modelBuilder.Configurations.Add(new RelationshipMap());
            modelBuilder.Configurations.Add(new SemesterMap());

            modelBuilder.Configurations.Add(new UserAccountInfoMap());
            modelBuilder.Configurations.Add(new UserAddressMap());
            modelBuilder.Configurations.Add(new UserEmailMap());
            modelBuilder.Configurations.Add(new UserLoginMap());
            modelBuilder.Configurations.Add(new UserPhoneMap());

            // Logging
            modelBuilder.Configurations.Add(new LogMap());

            // Renweb
            modelBuilder.Configurations.Add(new RenwebClassInfoResultMap());
            modelBuilder.Configurations.Add(new RenwebFamilyMembersResultMap());
            modelBuilder.Configurations.Add(new RenwebFamilyResultMap());
            modelBuilder.Configurations.Add(new RenwebGradeLevelResultMap());
            modelBuilder.Configurations.Add(new RenwebSchoolResultMap());
        }

        public override int SaveChanges()
        {
            Configuration.ValidateOnSaveEnabled = AppConfig.Current.Application.Data.AutomaticValidateOnSaveEnabled;
            SetRowAuditData();
            FindDeletedChildren();

            return base.SaveChanges();
        }

        private void FindDeletedChildren()
        {
            var removedUserAccountInfo = UserAccountInfos
                .Local
                .Where(x => x.User == null)
                .ToList();
            var removedUserAddresses = UserAddresses
                .Local
                .Where(x => x.User == null)
                .ToList();
            var removedUserEmails = UserEmails
                .Local
                .Where(x => x.User == null)
                .ToList();
            var removedUserLogins = UserLogins
                .Local
                .Where(x => x.User == null)
                .ToList();
            var removedUserPhones = UserPhones
                .Local
                .Where(x => x.User == null)
                .ToList();

            try
            {
                Configuration.AutoDetectChangesEnabled = false;

                removedUserAccountInfo.ForEach(x => UserAccountInfos.Remove(x));
                removedUserAddresses.ForEach(x => UserAddresses.Remove(x));
                removedUserEmails.ForEach(x => UserEmails.Remove(x));
                removedUserLogins.ForEach(x => UserLogins.Remove(x));
                removedUserPhones.ForEach(x => UserPhones.Remove(x));
            }
            finally
            {
                Configuration.AutoDetectChangesEnabled = true;
            }
        }

        private void SetRowAuditData()
        {
            var addedUpdatedEntities = GetAddedUpdatedEntities();
            var currentDateTime = DateTime.Now;
            var user = GetUser();

            addedUpdatedEntities.ToList().ForEach(e =>
            {
                var entityBase = e.Entity as IAuditEntity;
                if (entityBase == null)
                {
                    return;
                }
                if (e.State == EntityState.Added)
                {
                    entityBase.CreatedBy = user;
                    entityBase.CreatedDate = currentDateTime;
                }

                entityBase.UpdatedBy = user;
                entityBase.UpdatedDate = currentDateTime;
            });
        }

        private IEnumerable<ObjectStateEntry> GetAddedUpdatedEntities()
        {
            var context = ((IObjectContextAdapter)this).ObjectContext;

            return context.ObjectStateManager
                .GetObjectStateEntries(EntityState.Added | EntityState.Modified)
                .Where(x => !x.IsRelationship && x.Entity is IAuditEntity);
        }

        private static int GetUser()
        {
            var returnValue = 1; // System User
            var user = SessionUser.Current;

            if (user != null)
            {
                returnValue = user.Id;
            }

            return returnValue;
        }
    }
}
