using PTO.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace PTO.Service.Renweb
{
    public static class RenwebManager
    {
        public static string SoapUrl = "https://dis-tx.client.renweb.com/parentsweb/webservices/school/pw_sch_directory.asmx";

        public static string FamilySearchAction = "http://www.renweb.com/webservices/pwSchool/directory/pw_sch_directory_family";

        public static void BuildFamilySearch(
            StringBuilder payload,
            RenwebUserType userType = RenwebUserType.Parent,
            RenwebDirectoryType directoryType = RenwebDirectoryType.Parent,
            int userId = 15328,
            string nameFilter = "",
            string gradeFilter = "",
            string classFilter = "",
            string schoolCode = "",
            string districtCode = "DIS-TX"
        )
        {
            var sb = new StringBuilder();

            sb.AppendFormat(@"<ns0:UserType>{0}</ns0:UserType>", EnumHelper.GetDescription(userType));
            sb.AppendFormat(@"<ns0:UserID>{0}</ns0:UserID>", userId);
            sb.AppendFormat(@"<ns0:FilterName>{0}</ns0:FilterName>", nameFilter);
            sb.AppendFormat(@"<ns0:DirectoryType>{0}</ns0:DirectoryType>", EnumHelper.GetDescription(directoryType));
            sb.AppendFormat(@"<ns0:Criteria>{0}</ns0:Criteria>", gradeFilter); // Grade string i.e., CP
            sb.AppendFormat(@"<ns0:classCriteria>{0}</ns0:classCriteria>", classFilter);
            sb.AppendFormat(@"<ns0:SchoolCode>{0}</ns0:SchoolCode>", schoolCode);
            sb.AppendFormat(@"<ns0:District>{0}</ns0:District>", districtCode);

            payload.AppendFormat(@"<ns0:pw_sch_directory_family>{0}</ns0:pw_sch_directory_family>", sb.ToString());
        }

        public static string FamilyMembersAction = "http://www.renweb.com/webservices/pwSchool/directory/pw_sch_directory_family_members";

        public static void BuildFamilyMembersSearch(
            StringBuilder payload,
            RenwebUserType userType = RenwebUserType.Parent,
            int userId = 15328,
            int searchedPersonId = 13191,
            int addressId = 10572,
            string schoolCode = "",
            string districtCode = "DIS-TX"
        )
        {
            var sb = new StringBuilder();
            sb.AppendFormat(@"<ns0:UserType>{0}</ns0:UserType>", EnumHelper.GetDescription(userType));
            sb.AppendFormat(@"<ns0:UserID>{0}</ns0:UserID>", userId);
            sb.AppendFormat(@"<ns0:SchoolCode>{0}</ns0:SchoolCode>", schoolCode);
            sb.AppendFormat(@"<ns0:District>{0}</ns0:District>", districtCode);
            sb.AppendFormat(@"<ns0:Person>{0}</ns0:Person>", searchedPersonId);
            sb.AppendFormat(@"<ns0:Address>{0}</ns0:Address>", addressId);
            payload.AppendFormat(@"<ns0:pw_sch_directory_family_members>{0}</ns0:pw_sch_directory_family_members>", sb.ToString());
        }

        public static string SchoolAction = "http://www.renweb.com/webservices/pwSchool/directory/pw_sch_directory_school";

        public static void BuildSchoolSearch(
            StringBuilder payload,
            RenwebUserType userType = RenwebUserType.Parent,
            int userId = 15328,
            string nameFilter = "",
            string schoolCode = "",
            string districtCode = "DIS-TX"
        )
        {
            var sb = new StringBuilder();
            sb.AppendFormat(@"<ns0:UserType>{0}</ns0:UserType>", EnumHelper.GetDescription(userType));
            sb.AppendFormat(@"<ns0:UserID>{0}</ns0:UserID>", userId);
            sb.AppendFormat(@"<ns0:FilterName>{0}</ns0:FilterName>", nameFilter);
            sb.AppendFormat(@"<ns0:SchoolCode>{0}</ns0:SchoolCode>", schoolCode);
            sb.AppendFormat(@"<ns0:District>{0}</ns0:District>", districtCode);
            payload.AppendFormat(@"<ns0:pw_sch_directory_school>{0}</ns0:pw_sch_directory_school>", sb.ToString());
        }
    }
}