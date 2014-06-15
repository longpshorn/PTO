
// ReSharper disable CheckNamespace
namespace PTO.Service
// ReSharper restore CheckNamespace
{
    using System;
    using Entity;
    using Entity.Renweb;
    //using Entity.Email;
    using Core.Interfaces;
    using PTO.Infrastructure;

    // ReSharper disable PartialTypeWithSinglePart
    /// <summary>
    /// Non-generic service interface for the <see cref="PTO.Entity.Course"/> entity
    /// </summary>
    public partial interface ICourseService : IEntityService<Course, int>
    {
    }

    /// <summary>
    /// Non-generic service for the <see cref="PTO.Entity.Course"/> entity
    /// </summary>
    public partial class CourseService : EntityService<Course, int, AppContext>, ICourseService
    {
        public CourseService(ISession<AppContext> session, IAppService service, Func<ICourseRepository> repository)
            : base(session, service, repository)
        {
        }

        protected new ICourseRepository Repository
        {
            get { return base.Repository as ICourseRepository; }
        }
    }
    /// <summary>
    /// Non-generic service interface for the <see cref="PTO.Entity.Enrollment"/> entity
    /// </summary>
    public partial interface IEnrollmentService : IEntityService<Enrollment, int>
    {
    }

    /// <summary>
    /// Non-generic service for the <see cref="PTO.Entity.Enrollment"/> entity
    /// </summary>
    public partial class EnrollmentService : EntityService<Enrollment, int, AppContext>, IEnrollmentService
    {
        public EnrollmentService(ISession<AppContext> session, IAppService service, Func<IEnrollmentRepository> repository)
            : base(session, service, repository)
        {
        }

        protected new IEnrollmentRepository Repository
        {
            get { return base.Repository as IEnrollmentRepository; }
        }
    }
    /// <summary>
    /// Non-generic service interface for the <see cref="PTO.Entity.Parent"/> entity
    /// </summary>
    public partial interface IParentService : IEntityService<Parent, int>
    {
    }

    /// <summary>
    /// Non-generic service for the <see cref="PTO.Entity.Parent"/> entity
    /// </summary>
    public partial class ParentService : EntityService<Parent, int, AppContext>, IParentService
    {
        public ParentService(ISession<AppContext> session, IAppService service, Func<IParentRepository> repository)
            : base(session, service, repository)
        {
        }

        protected new IParentRepository Repository
        {
            get { return base.Repository as IParentRepository; }
        }
    }
    /// <summary>
    /// Non-generic service interface for the <see cref="PTO.Entity.Relationship"/> entity
    /// </summary>
    public partial interface IRelationshipService : IEntityService<Relationship, int>
    {
    }

    /// <summary>
    /// Non-generic service for the <see cref="PTO.Entity.Relationship"/> entity
    /// </summary>
    public partial class RelationshipService : EntityService<Relationship, int, AppContext>, IRelationshipService
    {
        public RelationshipService(ISession<AppContext> session, IAppService service, Func<IRelationshipRepository> repository)
            : base(session, service, repository)
        {
        }

        protected new IRelationshipRepository Repository
        {
            get { return base.Repository as IRelationshipRepository; }
        }
    }
    /// <summary>
    /// Non-generic service interface for the <see cref="PTO.Entity.Student"/> entity
    /// </summary>
    public partial interface IStudentService : IEntityService<Student, int>
    {
    }

    /// <summary>
    /// Non-generic service for the <see cref="PTO.Entity.Student"/> entity
    /// </summary>
    public partial class StudentService : EntityService<Student, int, AppContext>, IStudentService
    {
        public StudentService(ISession<AppContext> session, IAppService service, Func<IStudentRepository> repository)
            : base(session, service, repository)
        {
        }

        protected new IStudentRepository Repository
        {
            get { return base.Repository as IStudentRepository; }
        }
    }
    /// <summary>
    /// Non-generic service interface for the <see cref="PTO.Entity.User"/> entity
    /// </summary>
    public partial interface IUserService : IEntityService<User, int>
    {
    }

    /// <summary>
    /// Non-generic service for the <see cref="PTO.Entity.User"/> entity
    /// </summary>
    public partial class UserService : EntityService<User, int, AppContext>, IUserService
    {
        public UserService(ISession<AppContext> session, IAppService service, Func<IUserRepository> repository)
            : base(session, service, repository)
        {
        }

        protected new IUserRepository Repository
        {
            get { return base.Repository as IUserRepository; }
        }
    }
    /// <summary>
    /// Non-generic service interface for the <see cref="PTO.Entity.UserAddress"/> entity
    /// </summary>
    public partial interface IUserAddressService : IEntityService<UserAddress, int>
    {
    }

    /// <summary>
    /// Non-generic service for the <see cref="PTO.Entity.UserAddress"/> entity
    /// </summary>
    public partial class UserAddressService : EntityService<UserAddress, int, AppContext>, IUserAddressService
    {
        public UserAddressService(ISession<AppContext> session, IAppService service, Func<IUserAddressRepository> repository)
            : base(session, service, repository)
        {
        }

        protected new IUserAddressRepository Repository
        {
            get { return base.Repository as IUserAddressRepository; }
        }
    }
    /// <summary>
    /// Non-generic service interface for the <see cref="PTO.Entity.RenwebClassInfoResult"/> entity
    /// </summary>
    public partial interface IRenwebClassInfoResultService : IEntityService<RenwebClassInfoResult, int>
    {
    }

    /// <summary>
    /// Non-generic service for the <see cref="PTO.Entity.RenwebClassInfoResult"/> entity
    /// </summary>
    public partial class RenwebClassInfoResultService : EntityService<RenwebClassInfoResult, int, AppContext>, IRenwebClassInfoResultService
    {
        public RenwebClassInfoResultService(ISession<AppContext> session, IAppService service, Func<IRenwebClassInfoResultRepository> repository)
            : base(session, service, repository)
        {
        }

        protected new IRenwebClassInfoResultRepository Repository
        {
            get { return base.Repository as IRenwebClassInfoResultRepository; }
        }
    }
    /// <summary>
    /// Non-generic service interface for the <see cref="PTO.Entity.RenwebFamilyMembersResult"/> entity
    /// </summary>
    public partial interface IRenwebFamilyMembersResultService : IEntityService<RenwebFamilyMembersResult, int>
    {
    }

    /// <summary>
    /// Non-generic service for the <see cref="PTO.Entity.RenwebFamilyMembersResult"/> entity
    /// </summary>
    public partial class RenwebFamilyMembersResultService : EntityService<RenwebFamilyMembersResult, int, AppContext>, IRenwebFamilyMembersResultService
    {
        public RenwebFamilyMembersResultService(ISession<AppContext> session, IAppService service, Func<IRenwebFamilyMembersResultRepository> repository)
            : base(session, service, repository)
        {
        }

        protected new IRenwebFamilyMembersResultRepository Repository
        {
            get { return base.Repository as IRenwebFamilyMembersResultRepository; }
        }
    }
    /// <summary>
    /// Non-generic service interface for the <see cref="PTO.Entity.RenwebFamilyResult"/> entity
    /// </summary>
    public partial interface IRenwebFamilyResultService : IEntityService<RenwebFamilyResult, int>
    {
    }

    /// <summary>
    /// Non-generic service for the <see cref="PTO.Entity.RenwebFamilyResult"/> entity
    /// </summary>
    public partial class RenwebFamilyResultService : EntityService<RenwebFamilyResult, int, AppContext>, IRenwebFamilyResultService
    {
        public RenwebFamilyResultService(ISession<AppContext> session, IAppService service, Func<IRenwebFamilyResultRepository> repository)
            : base(session, service, repository)
        {
        }

        protected new IRenwebFamilyResultRepository Repository
        {
            get { return base.Repository as IRenwebFamilyResultRepository; }
        }
    }
    /// <summary>
    /// Non-generic service interface for the <see cref="PTO.Entity.RenwebGradeLevelResult"/> entity
    /// </summary>
    public partial interface IRenwebGradeLevelResultService : IEntityService<RenwebGradeLevelResult, int>
    {
    }

    /// <summary>
    /// Non-generic service for the <see cref="PTO.Entity.RenwebGradeLevelResult"/> entity
    /// </summary>
    public partial class RenwebGradeLevelResultService : EntityService<RenwebGradeLevelResult, int, AppContext>, IRenwebGradeLevelResultService
    {
        public RenwebGradeLevelResultService(ISession<AppContext> session, IAppService service, Func<IRenwebGradeLevelResultRepository> repository)
            : base(session, service, repository)
        {
        }

        protected new IRenwebGradeLevelResultRepository Repository
        {
            get { return base.Repository as IRenwebGradeLevelResultRepository; }
        }
    }
    /// <summary>
    /// Non-generic service interface for the <see cref="PTO.Entity.RenwebSchoolResult"/> entity
    /// </summary>
    public partial interface IRenwebSchoolResultService : IEntityService<RenwebSchoolResult, int>
    {
    }

    /// <summary>
    /// Non-generic service for the <see cref="PTO.Entity.RenwebSchoolResult"/> entity
    /// </summary>
    public partial class RenwebSchoolResultService : EntityService<RenwebSchoolResult, int, AppContext>, IRenwebSchoolResultService
    {
        public RenwebSchoolResultService(ISession<AppContext> session, IAppService service, Func<IRenwebSchoolResultRepository> repository)
            : base(session, service, repository)
        {
        }

        protected new IRenwebSchoolResultRepository Repository
        {
            get { return base.Repository as IRenwebSchoolResultRepository; }
        }
    }

    public partial interface IAppService
    {
        void SaveChanges();
        void SaveChanges<AppContext>();
        ICourseService Courses { get; }
        IEnrollmentService Enrollments { get; }
        IParentService Parents { get; }
        IRelationshipService Relationships { get; }
        IStudentService Students { get; }
        IUserService Users { get; }
        IUserAddressService UserAddresses { get; }
        IRenwebClassInfoResultService RenwebClassInfoResults { get; }
        IRenwebFamilyMembersResultService RenwebFamilyMembersResults { get; }
        IRenwebFamilyResultService RenwebFamilyResults { get; }
        IRenwebGradeLevelResultService RenwebGradeLevelResults { get; }
        IRenwebSchoolResultService RenwebSchoolResults { get; }
    }

    public partial class AppService : IAppService
    {
        private readonly ISession<AppContext> _AppContextSession;

        private readonly Lazy<ICourseService> _courses;
        private readonly Lazy<IEnrollmentService> _enrollments;
        private readonly Lazy<IParentService> _parents;
        private readonly Lazy<IRelationshipService> _relationships;
        private readonly Lazy<IStudentService> _students;
        private readonly Lazy<IUserService> _users;
        private readonly Lazy<IUserAddressService> _useraddresses;
        private readonly Lazy<IRenwebClassInfoResultService> _renwebclassinforesults;
        private readonly Lazy<IRenwebFamilyMembersResultService> _renwebfamilymembersresults;
        private readonly Lazy<IRenwebFamilyResultService> _renwebfamilyresults;
        private readonly Lazy<IRenwebGradeLevelResultService> _renwebgradelevelresults;
        private readonly Lazy<IRenwebSchoolResultService> _renwebschoolresults;

        public AppService(
            ISession<AppContext> AppContextSession,
            Func<ICourseService> courses,
            Func<IEnrollmentService> enrollments,
            Func<IParentService> parents,
            Func<IRelationshipService> relationships,
            Func<IStudentService> students,
            Func<IUserService> users,
            Func<IUserAddressService> useraddresses,
            Func<IRenwebClassInfoResultService> renwebclassinforesults,
            Func<IRenwebFamilyMembersResultService> renwebfamilymembersresults,
            Func<IRenwebFamilyResultService> renwebfamilyresults,
            Func<IRenwebGradeLevelResultService> renwebgradelevelresults,
            Func<IRenwebSchoolResultService> renwebschoolresults
        )
        {
            _AppContextSession = AppContextSession;
            _courses = new Lazy<ICourseService>(courses);
            _enrollments = new Lazy<IEnrollmentService>(enrollments);
            _parents = new Lazy<IParentService>(parents);
            _relationships = new Lazy<IRelationshipService>(relationships);
            _students = new Lazy<IStudentService>(students);
            _users = new Lazy<IUserService>(users);
            _useraddresses = new Lazy<IUserAddressService>(useraddresses);
            _renwebclassinforesults = new Lazy<IRenwebClassInfoResultService>(renwebclassinforesults);
            _renwebfamilymembersresults = new Lazy<IRenwebFamilyMembersResultService>(renwebfamilymembersresults);
            _renwebfamilyresults = new Lazy<IRenwebFamilyResultService>(renwebfamilyresults);
            _renwebgradelevelresults = new Lazy<IRenwebGradeLevelResultService>(renwebgradelevelresults);
            _renwebschoolresults = new Lazy<IRenwebSchoolResultService>(renwebschoolresults);
        }

        public ICourseService Courses { get { return _courses.Value; } }
        public IEnrollmentService Enrollments { get { return _enrollments.Value; } }
        public IParentService Parents { get { return _parents.Value; } }
        public IRelationshipService Relationships { get { return _relationships.Value; } }
        public IStudentService Students { get { return _students.Value; } }
        public IUserService Users { get { return _users.Value; } }
        public IUserAddressService UserAddresses { get { return _useraddresses.Value; } }
        public IRenwebClassInfoResultService RenwebClassInfoResults { get { return _renwebclassinforesults.Value; } }
        public IRenwebFamilyMembersResultService RenwebFamilyMembersResults { get { return _renwebfamilymembersresults.Value; } }
        public IRenwebFamilyResultService RenwebFamilyResults { get { return _renwebfamilyresults.Value; } }
        public IRenwebGradeLevelResultService RenwebGradeLevelResults { get { return _renwebgradelevelresults.Value; } }
        public IRenwebSchoolResultService RenwebSchoolResults { get { return _renwebschoolresults.Value; } }

        public void SaveChanges<AppContext>() {
            _AppContextSession.Complete();
        }
        public void SaveChanges() {
            SaveChanges<AppContext>();
        }
    }
    // ReSharper restore PartialTypeWithSinglePart
}
