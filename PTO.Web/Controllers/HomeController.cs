using AutoMapper.QueryableExtensions;
using PagedList;
using PTO.Core.Enums;
using PTO.Entity;
using PTO.Service;
using PTO.Web.Filters;
using PTO.Web.Models.Users;
using System;
using System.Linq;
using System.Web.Mvc;

namespace PTO.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAppService _service;

        public HomeController(IAppService service)
        {
            _service = service;
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        public ActionResult GridUsers()
        {
            var viewModel = _service.Users.GetAll()
                .OrderBy(x => x.FirstName).ToList().AsQueryable()
                .Project().To<UserViewModel>().ToList();
            return View(viewModel);
        }

        public ActionResult Users(int page = 1, int pageSize = 1)
        {
            // will only contain 25 products max because of the pageSize
            var userList = _service.Users
                .Query()
                .Include(x => x.Emails)
                .GetAll()
                .OrderBy(x => x.FirstName);

            //_service.Users.LazyLoadingEnabled = true;
            //var userPagedList = _service.Users
            //    .OrderBy(x => x.FirstName)
            //    .ToPagedList(page, pageSize);

            //ViewBag.UsersPage = userPagedList;

            var userPagedList = userList
                .ToList()
                .AsQueryable()
                .Project()
                .To<UserViewModel>()
                .ToPagedList(page, pageSize);

            var model = new Tuple<IPagedList<UserViewModel>, string>(userPagedList, "Users");
            return View(model);
        }

        public ActionResult UserDetails(int id)
        {
            var user = _service.Users.Find(id);
            return View(user);
        }

        public ActionResult AddUser(string firstName, string lastName)
        {
            var userId = 0;

            var existingUser = _service.Users
                .Get(x =>
                    x.FirstName.Equals(firstName, StringComparison.CurrentCultureIgnoreCase)
                    &&
                    x.LastName.Equals(lastName, StringComparison.CurrentCultureIgnoreCase)
                );

            if (existingUser == null)
            {
                var newUser = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    UserType = UserType.Parent,
                    IsActive = false,
                    AccountInfo = new UserAccountInfo
                    {
                        LoginEmail = string.Format("{0}.{1}@gmail.com", firstName, lastName),
                        IsValidLoginEmail = false,
                        Password = "password",
                        Salt = "salt"
                    }
                };

                _service.Users.Insert(newUser);
                _service.SaveChanges();
                userId = newUser.Id;
            }

            if (userId != 0)
            {
                return RedirectToAction("UserDetails", new { id = userId });
            }
            return RedirectToAction("Users");
        }
    }
}
