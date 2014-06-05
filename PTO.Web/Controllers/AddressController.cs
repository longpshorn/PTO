using AutoMapper;
using AutoMapper.QueryableExtensions;
using ProgressiveJs.Extensions;
using PTO.Core.Extensions;
using PTO.Service;
using PTO.Web.Models;
using PTO.Web.Models.Users;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PTO.Web.Controllers
{
    public class AddressController : BaseController
    {
        public AddressController(IAppService service)
            : base(service)
        {
        }

        public ActionResult Index()
        {
            var users = _service.Users
                .Query().Include(x => x.Addresses)
                .GetAll()//.Where(x => x.Addresses.Any())
                .ToList().AsQueryable()
                .Project().To<UserViewModel>();

            var addresses = new Dictionary<string, AddressViewModel>();

            var userAddresses = _service.UserAddresses.GetFamilyAddresses();
            userAddresses.ToList().ForEach(x =>
            {
                if (!addresses.ContainsKey(x.Key) && x.Value.Any())
                {
                    var address = _service.UserAddresses.Find(x.Value.First());
                    if (address != null)
                    {
                        if (!addresses.ContainsKey(address.Formatted))
                        {
                            var viewModel = Mapper.Map(address, new AddressViewModel());
                            addresses.Add(address.Formatted, viewModel);
                        }
                    }
                }

                x.Value.ForEach(y =>
                {
                    var user = users.SingleOrDefault(z => z.Addresses.Select(i => i.Id).Contains(y));
                    if (user != null)
                        addresses[x.Key].FamilyMembers = addresses[x.Key].FamilyMembers.HasValue()
                            ? string.Format("{0}, {1}", addresses[x.Key].FamilyMembers, user.DisplayName)
                            : user.DisplayName;
                });
            });

            return addresses.Select(x => x.Value).ToJsonNetResult();
        }
    }
}