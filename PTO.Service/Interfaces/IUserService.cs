using PTO.Entity;
using PTO.Entity.Enums;
using PTO.Entity.Renweb;
using PTO.Service.Renweb;
using System.Collections.Generic;

namespace PTO.Service
{
    public partial interface IUserService
    {
        RenwebImportStatus ImportRenwebFamily(List<RenwebFamilyMembersResult> results);

        User InsertFromRenwebFamilyMemberResult(RenwebFamilyMembersResult renwebResult);

        User UpdateFromRenwebFamilyMemberResult(User existingUser, RenwebFamilyMembersResult renwebResult);
    }
}
