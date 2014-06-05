using AutoMapper;
using PTO.Core.Enums;
using PTO.Core.Extensions;
using PTO.Entity;
using PTO.Entity.Enums;
using PTO.Entity.Extensions;
using PTO.Entity.Renweb;
using PTO.Service.Renweb;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PTO.Service
{
    public partial class UserService
    {
        public RenwebImportStatus ImportRenwebFamily(List<RenwebFamilyMembersResult> results)
        {
            // First check to see if they family has already been processed.
            // If the family has already been processed, we don't need to process them again.
            // We can also call this a success because they have already been successfully added or updated.
            if (!IsFamilyImportNeeded(results))
                return RenwebImportStatus.AlreadyExists;

            var success = RenwebImportStatus.Success;
            var family = new List<User>();

            results.ForEach(familyMember =>
            {
                try
                {
                    var existingResult = _service.RenwebFamilyMembersResults.Get(x =>
                        x.Email.Equals(familyMember.Email)
                        &&
                        x.FirstName.Equals(familyMember.FirstName)
                        &&
                        x.LastName.Equals(familyMember.LastName)
                        &&
                        x.StudentEntry.Equals(familyMember.StudentEntry)
                    );
                    if (existingResult == null)
                    {
                        familyMember.IsProcessed = true;
                        _service.RenwebFamilyMembersResults.Insert(familyMember);
                        family.Add(InsertFromRenwebFamilyMemberResult(familyMember));
                    }
                    else
                    {
                        Mapper.Map(familyMember, existingResult);
                        existingResult.IsProcessed = true;
                        _service.RenwebFamilyMembersResults.Update(existingResult);
                        var existingUser = _service.Users
                            .Query().Include(x => x.Emails).GetAll()
                            // First filter to reasonable size list
                            .Where(x =>
                                x.FirstName.Equals(familyMember.FirstName.Replace("*", string.Empty))
                                &&
                                x.LastName.Equals(familyMember.LastName.Replace("*", string.Empty))
                            )
                            .ToList()
                            // then, complete check to see if user exists by looking at in-memory data
                            .SingleOrDefault(x =>
                                (
                                    (familyMember.Email.HasValue() && x.Emails.Any() && x.Emails.Select(y => y.Address).ToList().Contains(familyMember.Email))
                                    ||
                                    (!familyMember.Email.HasValue() && !x.Emails.Any())
                                )
                                && (
                                    (familyMember.IsStudent && x.UserType.Equals(UserType.Student)) ||
                                    (!familyMember.IsStudent && x.UserType.Equals(UserType.Parent))
                                )
                            );

                        if (existingUser != null)
                            family.Add(UpdateFromRenwebFamilyMemberResult(existingUser, existingResult));
                        else
                            family.Add(InsertFromRenwebFamilyMemberResult(existingResult));
                    }
                }
                catch
                {
                    success = RenwebImportStatus.Failure;
                }
            });

            // for each of the family members that we added, define their relationships to one another.
            family.ForEach(familyMember =>
            {
                try
                {
                    // get all of the family members that aren't the current person of interest (POI).
                    var otherFamilyMembers = family.Except(new List<User> { familyMember });
                    if (otherFamilyMembers.Any())
                    {
                        otherFamilyMembers.ToList().ForEach(otherMember =>
                        {
                            // determine the relationship type to the POI
                            // default, when the POI is a student and the other family member is a parent
                            var relationType = RelationType.Parent;
                            if (familyMember.UserType.Equals(UserType.Student) && otherMember.UserType.Equals(UserType.Student))
                            {
                                // when both people are students, assume they are siblings.
                                relationType = RelationType.Sibling;
                            }
                            else if (familyMember.UserType.Equals(UserType.Parent) && otherMember.UserType.Equals(UserType.Parent)) {
                                // when both people are parents, assume they are spouses.
                                relationType = RelationType.Spouse;
                            }
                            else if (familyMember.UserType.Equals(UserType.Parent) && otherMember.UserType.Equals(UserType.Student))
                            {
                                // when POI is a parent and the other person is a student, assume parent-child relationship.
                                relationType = RelationType.Child;
                            }

                            _service.Relationships.AddRelationship(familyMember, otherMember, relationType);
                        });
                    }
                }
                catch
                {
                    success = RenwebImportStatus.Failure;
                }
            });

            return success;
        }

        public User InsertFromRenwebFamilyMemberResult(RenwebFamilyMembersResult renweb)
        {
            if (renweb == null)
                throw new NullReferenceException("Renweb user is null.");

            var newUser = renweb.IsStudent
                ? new Student().MergeUserDetailsFromRenwebFamilyMember(renweb)
                : new Parent().MergeUserDetailsFromRenwebFamilyMember(renweb);

            Insert(newUser);
            return newUser;
        }

        public User UpdateFromRenwebFamilyMemberResult(User existingUser, RenwebFamilyMembersResult renweb)
        {
            if (existingUser == null)
                throw new NullReferenceException("Existing user is null.");

            existingUser = existingUser.MergeUserDetailsFromRenwebFamilyMember(renweb);
            Update(existingUser);
            return existingUser;
        }

        private bool IsFamilyImportNeeded(List<RenwebFamilyMembersResult> results)
        {
            if (!results.Any())
                return false;

            var members = _service.RenwebFamilyMembersResults
                .ToList()
                .Where(x =>
                    results.Select(y => y.FirstName).Contains(x.FirstName) &&
                    results.Select(y => y.LastName).Contains(x.LastName) &&
                    results.Select(y => y.Email).Contains(x.Email) &&
                    results.Select(y => y.StudentEntry).Contains(x.StudentEntry) &&
                    results.Select(y => y.Home).Contains(x.Home) &&
                    results.Select(y => y.Work).Contains(x.Work) &&
                    results.Select(y => y.Other).Contains(x.Other) &&
                    results.Select(y => y.Address).Contains(x.Address) &&
                    results.Select(y => y.Address2).Contains(x.Address2) &&
                    results.Select(y => y.CSZ).Contains(x.CSZ) &&
                    results.Select(y => y.Country).Contains(x.Country) &&
                    results.Select(y => y.Photo).Contains(x.Photo) &&
                    results.Select(y => y.ActiveTab).Contains(x.ActiveTab) &&
                    results.Select(y => y.PicResized).Contains(x.PicResized)
                )
                .ToList();
            var alreadyProcessed = members.Any() && members.All(x => x.IsProcessed);

            return !alreadyProcessed;
        }
    }
}
