using Geocoding;
using PTO.Service;
using PTO.Web.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PTO.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAppService _service;
        private readonly IGeocoder _geocoder;

        public AdminController(IAppService service, IGeocoder geocoder)
        {
            _service = service;
            _geocoder = geocoder;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Map()
        {
            return View();
        }

        [UnitOfWork]
        public ActionResult BatchGeocode()
        {
            var userAddresses = _service.UserAddresses
                .GetAll()
                .Where(x => x.Location == null)
                .Distinct()
                .ToList();

            var addresses = new Dictionary<string, Tuple<List<int>, List<Address>>>();
            userAddresses.ForEach(x =>
            {
                if (addresses.ContainsKey(x.Formatted))
                    addresses[x.Formatted].Item1.Add(x.Id);
                else
                    addresses.Add(x.Formatted, new Tuple<List<int>, List<Address>>(new List<int> { x.Id }, new List<Address>()));
            });

            foreach (var address in addresses)
            {
                try
                {
                    var codedAddresses = _geocoder.Geocode(address.Key).ToList();
                    address.Value.Item2.AddRange(codedAddresses);

                    var coordinates = codedAddresses.First().Coordinates;
                    address.Value.Item1.ForEach(x => {
                        var userAddress = userAddresses.Single(y => y.Id.Equals(x));
                        userAddress.UpdateLocation(coordinates.Latitude, coordinates.Longitude);
                        _service.UserAddresses.Update(userAddress);
                    });
                }
                catch { }
            }

            return View("Index", addresses);
        }
    }
}