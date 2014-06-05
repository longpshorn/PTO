using PTO.Core;
using PTO.Core.Extensions;
using PTO.Entity.Renweb;
using PTO.Service.Renweb;
using PTO.Web.RenwebDirectoryService;
using PTO.Web.RenwebClassService;
using System.Linq;

namespace PTO.Web.Services
{
    public class RenwebService : IRenwebService
    {
        public IQueryable<RenwebFamilyResult> ParentsWebFamilySearch(
            int userId = 15328,
            RenwebUserType userType = RenwebUserType.Parent,
            RenwebDirectoryType directoryType = RenwebDirectoryType.Parent,
            string nameFilter = "",
            string gradeFilter = "",
            string classFilter = "",
            string schoolCode = "",
            string districtCode = "DIS-TX"
        )
        {
            var request = new pw_sch_directory_familyRequest
            {
                UserID = userId,
                UserType = EnumHelper.GetDescription(userType),
                DirectoryType = EnumHelper.GetDescription(directoryType),
                District = districtCode,
                SchoolCode = schoolCode,
                Criteria = gradeFilter,
                FilterName = nameFilter,
                classCriteria = classFilter
            };

            var client = new pw_sch_directorySoapClient();

            var results = client.pw_sch_directory_family(request)
                .pw_sch_directory_familyResult
                .CreateDataReader()
                .DataReaderMapToList<RenwebFamilyResult>()
                .AsQueryable();

            return results;
        }

        public IQueryable<RenwebFamilyMembersResult> ParentsWebFamilyMembersSearch(
            int personId,
            int addressId,
            int userId = 15328,
            RenwebUserType userType = RenwebUserType.Parent,
            string schoolCode = "",
            string districtCode = "DIS-TX"
        )
        {
            var request = new pw_sch_directory_family_membersRequest
            {
                UserID = userId,
                UserType = EnumHelper.GetDescription(userType),
                Person = personId,
                Address = addressId,
                District = districtCode,
                SchoolCode = schoolCode
            };

            var client = new pw_sch_directorySoapClient();

            var results = client.pw_sch_directory_family_members(request)
                .pw_sch_directory_family_membersResult
                .CreateDataReader()
                .DataReaderMapToList<RenwebFamilyMembersResult>()
                .AsQueryable();

            return results;
        }

        public IQueryable<RenwebGradeLevelResult> ParentsWebGradeLevelsSearch(
            int userId = 15328,
            RenwebUserType userType = RenwebUserType.Parent,
            string schoolCode = "",
            string districtCode = "DIS-TX"
        )
        {
            var request = new pw_sch_directory_family_gradelevelRequest
            {
                UserID = userId,
                UserType = EnumHelper.GetDescription(userType),
                District = districtCode,
                SchoolCode = schoolCode
            };

            var client = new pw_sch_directorySoapClient();

            var results = client.pw_sch_directory_family_gradelevel(request)
                .pw_sch_directory_family_gradelevelResult
                .CreateDataReader()
                .DataReaderMapToList<RenwebGradeLevelResult>()
                .AsQueryable();

            return results;
        }

        public IQueryable<RenwebSchoolResult> ParentsWebSchoolSearch(
            int userId = 15328,
            RenwebUserType userType = RenwebUserType.Parent,
            string nameFilter = "",
            string schoolCode = "",
            string districtCode = "DIS-TX"
        )
        {
            var request = new pw_sch_directory_schoolRequest
            {
                UserID = userId,
                UserType = EnumHelper.GetDescription(userType),
                FilterName = nameFilter,
                District = districtCode,
                SchoolCode = schoolCode
            };

            var client = new pw_sch_directorySoapClient();

            var results = client.pw_sch_directory_school(request)
                .pw_sch_directory_schoolResult
                .CreateDataReader()
                .DataReaderMapToList<RenwebSchoolResult>()
                .AsQueryable();

            return results;
        }

        public IQueryable<RenwebClassInfoResult> ParentsWebClassesSearch(
            int userId = 15328,
            RenwebUserType userType = RenwebUserType.Parent,
            string studentId = "0",
            string classId = "0",
            int termId = 0,
            string schoolCode = "",
            string districtCode = "DIS-TX"
        )
        {
            var request = new pw_sch_classRequest
            {
                UserID = userId,
                UserType = EnumHelper.GetDescription(userType),
                studentID = studentId,
                ClassID = classId,
                termID = termId,
                District = districtCode,
                SchoolCode = schoolCode
            };

            var client = new pw_sch_classSiteSoapClient();

            var results = client.pw_sch_class(request)
                .pw_sch_classResult
                .CreateDataReader()
                .DataReaderMapToList<RenwebClassInfoResult>()
                .AsQueryable();

            return results;
        }
    }
}
