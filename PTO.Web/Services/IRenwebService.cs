using PTO.Entity.Renweb;
using PTO.Service.Renweb;
using System.Linq;

namespace PTO.Web.Services
{
    public interface IRenwebService
    {
        IQueryable<RenwebFamilyResult> ParentsWebFamilySearch(
            int userId = 15328,
            RenwebUserType userType = RenwebUserType.Parent,
            RenwebDirectoryType directoryType = RenwebDirectoryType.Parent,
            string nameFilter = "",
            string gradeFilter = "",
            string classFilter = "",
            string schoolCode = "",
            string districtCode = "DIS-TX"
        );

        IQueryable<RenwebFamilyMembersResult> ParentsWebFamilyMembersSearch(
            int personId,
            int addressId,
            int userId = 15328,
            RenwebUserType userType = RenwebUserType.Parent,
            string schoolCode = "",
            string districtCode = "DIS-TX"
        );

        IQueryable<RenwebGradeLevelResult> ParentsWebGradeLevelsSearch(
            int userId = 15328,
            RenwebUserType userType = RenwebUserType.Parent,
            string schoolCode = "",
            string districtCode = "DIS-TX"
        );

        IQueryable<RenwebSchoolResult> ParentsWebSchoolSearch(
            int userId = 15328,
            RenwebUserType userType = RenwebUserType.Parent,
            string nameFilter = "",
            string schoolCode = "",
            string districtCode = "DIS-TX"
        );

        IQueryable<RenwebClassInfoResult> ParentsWebClassesSearch(
            int userId = 15328,
            RenwebUserType userType = RenwebUserType.Parent,
            string studentId = "0",
            string classId = "0",
            int termId = 0,
            string schoolCode = "",
            string districtCode = "DIS-TX"
        );
    }
}
