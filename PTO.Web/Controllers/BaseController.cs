using PTO.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PTO.Web.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IAppService _service;

        public BaseController(IAppService service)
        {
            _service = service;
        }
    }
}