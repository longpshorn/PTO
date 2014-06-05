
// ReSharper disable CheckNamespace
namespace PTO.Infrastructure
// ReSharper restore CheckNamespace
{
    using System;
    using Entity;
    using Entity.Renweb;
    //using Entity.Email;
    using Core.Interfaces;

    // ReSharper disable PartialTypeWithSinglePart
    /// <summary>
    /// Non-generic repository interface for the <see cref="PTO.Entity.Course"/> entity
    /// </summary>
    public partial interface ICourseRepository : IEntityRepository<Course, int>
    {
    }

    /// <summary>
    /// Non-generic repository for the <see cref="PTO.Entity.Course"/> entity
    /// </summary>
    public partial class CourseRepository : EntityRepository<Course, int, AppContext>, ICourseRepository
    {
        public CourseRepository(ISession<AppContext> session)
            : base(session)
        {
        }
    }
    /// <summary>
    /// Non-generic repository interface for the <see cref="PTO.Entity.Enrollment"/> entity
    /// </summary>
    public partial interface IEnrollmentRepository : IEntityRepository<Enrollment, int>
    {
    }

    /// <summary>
    /// Non-generic repository for the <see cref="PTO.Entity.Enrollment"/> entity
    /// </summary>
    public partial class EnrollmentRepository : EntityRepository<Enrollment, int, AppContext>, IEnrollmentRepository
    {
        public EnrollmentRepository(ISession<AppContext> session)
            : base(session)
        {
        }
    }
    /// <summary>
    /// Non-generic repository interface for the <see cref="PTO.Entity.Parent"/> entity
    /// </summary>
    public partial interface IParentRepository : IEntityRepository<Parent, int>
    {
    }

    /// <summary>
    /// Non-generic repository for the <see cref="PTO.Entity.Parent"/> entity
    /// </summary>
    public partial class ParentRepository : EntityRepository<Parent, int, AppContext>, IParentRepository
    {
        public ParentRepository(ISession<AppContext> session)
            : base(session)
        {
        }
    }
    /// <summary>
    /// Non-generic repository interface for the <see cref="PTO.Entity.Relationship"/> entity
    /// </summary>
    public partial interface IRelationshipRepository : IEntityRepository<Relationship, int>
    {
    }

    /// <summary>
    /// Non-generic repository for the <see cref="PTO.Entity.Relationship"/> entity
    /// </summary>
    public partial class RelationshipRepository : EntityRepository<Relationship, int, AppContext>, IRelationshipRepository
    {
        public RelationshipRepository(ISession<AppContext> session)
            : base(session)
        {
        }
    }
    /// <summary>
    /// Non-generic repository interface for the <see cref="PTO.Entity.Student"/> entity
    /// </summary>
    public partial interface IStudentRepository : IEntityRepository<Student, int>
    {
    }

    /// <summary>
    /// Non-generic repository for the <see cref="PTO.Entity.Student"/> entity
    /// </summary>
    public partial class StudentRepository : EntityRepository<Student, int, AppContext>, IStudentRepository
    {
        public StudentRepository(ISession<AppContext> session)
            : base(session)
        {
        }
    }
    /// <summary>
    /// Non-generic repository interface for the <see cref="PTO.Entity.User"/> entity
    /// </summary>
    public partial interface IUserRepository : IEntityRepository<User, int>
    {
    }

    /// <summary>
    /// Non-generic repository for the <see cref="PTO.Entity.User"/> entity
    /// </summary>
    public partial class UserRepository : EntityRepository<User, int, AppContext>, IUserRepository
    {
        public UserRepository(ISession<AppContext> session)
            : base(session)
        {
        }
    }
    /// <summary>
    /// Non-generic repository interface for the <see cref="PTO.Entity.UserAddress"/> entity
    /// </summary>
    public partial interface IUserAddressRepository : IEntityRepository<UserAddress, int>
    {
    }

    /// <summary>
    /// Non-generic repository for the <see cref="PTO.Entity.UserAddress"/> entity
    /// </summary>
    public partial class UserAddressRepository : EntityRepository<UserAddress, int, AppContext>, IUserAddressRepository
    {
        public UserAddressRepository(ISession<AppContext> session)
            : base(session)
        {
        }
    }
    /// <summary>
    /// Non-generic repository interface for the <see cref="PTO.Entity.RenwebClassInfoResult"/> entity
    /// </summary>
    public partial interface IRenwebClassInfoResultRepository : IEntityRepository<RenwebClassInfoResult, int>
    {
    }

    /// <summary>
    /// Non-generic repository for the <see cref="PTO.Entity.RenwebClassInfoResult"/> entity
    /// </summary>
    public partial class RenwebClassInfoResultRepository : EntityRepository<RenwebClassInfoResult, int, AppContext>, IRenwebClassInfoResultRepository
    {
        public RenwebClassInfoResultRepository(ISession<AppContext> session)
            : base(session)
        {
        }
    }
    /// <summary>
    /// Non-generic repository interface for the <see cref="PTO.Entity.RenwebFamilyMembersResult"/> entity
    /// </summary>
    public partial interface IRenwebFamilyMembersResultRepository : IEntityRepository<RenwebFamilyMembersResult, int>
    {
    }

    /// <summary>
    /// Non-generic repository for the <see cref="PTO.Entity.RenwebFamilyMembersResult"/> entity
    /// </summary>
    public partial class RenwebFamilyMembersResultRepository : EntityRepository<RenwebFamilyMembersResult, int, AppContext>, IRenwebFamilyMembersResultRepository
    {
        public RenwebFamilyMembersResultRepository(ISession<AppContext> session)
            : base(session)
        {
        }
    }
    /// <summary>
    /// Non-generic repository interface for the <see cref="PTO.Entity.RenwebFamilyResult"/> entity
    /// </summary>
    public partial interface IRenwebFamilyResultRepository : IEntityRepository<RenwebFamilyResult, int>
    {
    }

    /// <summary>
    /// Non-generic repository for the <see cref="PTO.Entity.RenwebFamilyResult"/> entity
    /// </summary>
    public partial class RenwebFamilyResultRepository : EntityRepository<RenwebFamilyResult, int, AppContext>, IRenwebFamilyResultRepository
    {
        public RenwebFamilyResultRepository(ISession<AppContext> session)
            : base(session)
        {
        }
    }
    /// <summary>
    /// Non-generic repository interface for the <see cref="PTO.Entity.RenwebGradeLevelResult"/> entity
    /// </summary>
    public partial interface IRenwebGradeLevelResultRepository : IEntityRepository<RenwebGradeLevelResult, int>
    {
    }

    /// <summary>
    /// Non-generic repository for the <see cref="PTO.Entity.RenwebGradeLevelResult"/> entity
    /// </summary>
    public partial class RenwebGradeLevelResultRepository : EntityRepository<RenwebGradeLevelResult, int, AppContext>, IRenwebGradeLevelResultRepository
    {
        public RenwebGradeLevelResultRepository(ISession<AppContext> session)
            : base(session)
        {
        }
    }
    /// <summary>
    /// Non-generic repository interface for the <see cref="PTO.Entity.RenwebSchoolResult"/> entity
    /// </summary>
    public partial interface IRenwebSchoolResultRepository : IEntityRepository<RenwebSchoolResult, int>
    {
    }

    /// <summary>
    /// Non-generic repository for the <see cref="PTO.Entity.RenwebSchoolResult"/> entity
    /// </summary>
    public partial class RenwebSchoolResultRepository : EntityRepository<RenwebSchoolResult, int, AppContext>, IRenwebSchoolResultRepository
    {
        public RenwebSchoolResultRepository(ISession<AppContext> session)
            : base(session)
        {
        }
    }
    // ReSharper restore PartialTypeWithSinglePart
}
