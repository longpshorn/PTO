using PTO.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PTO.Web.Models.Users
{
    public class UserViewModel
    {
        public UserViewModel()
        {
            Addresses = new List<AddressViewModel>();
            Emails = new List<EmailViewModel>();
        }

        public int Id { get; set; }

        public UserType UserType { get; set; }

        public string DisplayName { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public byte[] ImageData { get; set; }

        public string ImageMimeType { get; set; }

        public bool IsActive { get; set; }

        public List<AddressViewModel> Addresses { get; set; }

        public List<EmailViewModel> Emails { get; set; }
    }
}