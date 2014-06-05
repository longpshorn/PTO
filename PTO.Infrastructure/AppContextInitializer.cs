using PTO.Core.Enums;
using PTO.Entity;
using System.Collections.Generic;
using System.Data.Entity;

namespace PTO.Infrastructure
{
    public class AppContextInitializer : DropCreateDatabaseAlways<AppContext>
    {
        protected override void Seed(AppContext context)
        {
            var users = new List<User> {
                new User {
                    FirstName = "Patrick",
                    MiddleName = "J",
                    LastName = "Smith",
                    UserType = UserType.Parent,
                    AccountInfo = new UserAccountInfo {
                        LoginEmail = "patrick.j.smith1@gmail.com",
                        IsValidLoginEmail = true,
                        Password = "password",
                        Salt = "salt"
                    },
                    Addresses = new List<UserAddress> {
                        new UserAddress {
                            Line1 = "7506 Woodthrush Dr.",
                            City = "Dallas",
                            State = "TX",
                            Zip = "75230"
                        }
                    },
                    Emails = new List<UserEmail> {
                        new UserEmail { Address = "patrick.j.smith1@gmail.com" }
                    },
                    Phones = new List<UserPhone> {
                        new UserPhone { Number = "5125678977" }
                    }
                },
                new User {
                    FirstName = "Julie",
                    MiddleName = "V",
                    LastName = "Smith",
                    UserType = UserType.Parent,
                    AccountInfo = new UserAccountInfo {
                        LoginEmail = "spaceelady@gmail.com",
                        IsValidLoginEmail = true,
                        Password = "password",
                        Salt = "salt"
                    },
                    Addresses = new List<UserAddress> {
                        new UserAddress {
                            Line1 = "7506 Woodthrush Dr.",
                            City = "Dallas",
                            State = "TX",
                            Zip = "75230"
                        }
                    },
                    Emails = new List<UserEmail> {
                        new UserEmail { Address = "spaceelady@gmail.com" }
                    },
                    Phones = new List<UserPhone> {
                        new UserPhone { Number = "9407657560" }
                    }
                }
            };

            users.ForEach(x => context.Users.Add(x));
            base.Seed(context);
        }
    }
}
