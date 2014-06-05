using AutoMapper;
using AutoMapper.QueryableExtensions;
using ProgressiveJs.Extensions;
using ProgressiveJs.Helpers;
using PTO.Service;
using PTO.Web.Models.Users;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace PTO.Web.ApiControllers
{
    public class UserController : ApiController
    {
        private readonly IAppService _service;

        public UserController(IAppService service)
        {
            _service = service;
        }

        // GET api/user
        public IEnumerable<UserViewModel> Get()
        {
            return _service.Users.GetAll().ToList().AsQueryable().Project().To<UserViewModel>().ToList();
        }

        // GET api/user/5
        public UserViewModel Get(int id)
        {
            var user = _service.Users.Query().Include(x => x.Emails).Include(x => x.Addresses).Get(x => x.Id.Equals(id));
            return Mapper.Map<UserViewModel>(user);
        }

        // POST api/user
        public void Post([FromBody]string value)
        {
        }

        // PUT api/user/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/user/5
        public void Delete(int id)
        {
        }
    }
}
