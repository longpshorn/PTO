using AutoMapper;
using PagedList;
using PTO.Core.Enums;
using PTO.Entity.Renweb;
using PTO.Service;
using PTO.Service.Renweb;
using PTO.Web.Filters;
using PTO.Web.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;

namespace PTO.Web.Controllers
{
    public class RenwebController : Controller
    {
        private readonly IAppService _service;
        private readonly IRenwebService _renwebService;

        public RenwebController(IAppService service, IRenwebService renwebService)
        {
            _service = service;
            _renwebService = renwebService;
        }

        public ActionResult Index()
        {
            return RedirectToAction("FamilyResultsLocal");
        }

        public ActionResult FamilyResultsRemote(int page = 1, int pageSize = 50)
        {
            var resultList = _renwebService.ParentsWebFamilySearch(15328, RenwebUserType.Parent, RenwebDirectoryType.Parent);
            var results = RenwebFamilyResultReader.GetResults().ToList();

            var pagedList = results.Union(resultList)
                .OrderBy(x => x.Parents)
                .ToPagedList(page, pageSize);

            return View(pagedList);
        }

        public ActionResult FamilyResultsLocal(RenwebDirectoryType directoryType = RenwebDirectoryType.Parent, int page = 1, int pageSize = 50)
        {
            var results = _service.RenwebFamilyResults.GetAll()
                .OrderBy(x => x.Parents)
                .ToPagedList(page, pageSize);

            return View(results);
        }

        public ActionResult FamilyMembersResultsLocal(int page = 1, int pageSize = 50)
        {
            var results = _service.RenwebFamilyMembersResults.GetAll()
                .OrderBy(x => x.LastName)
                .ToPagedList(page, pageSize);

            return View(results);
        }

        [UnitOfWork]
        public ActionResult PullFamilyResults(RenwebDirectoryType directoryType = RenwebDirectoryType.Parent, int page = 1, int pageSize = 3)
        {
            var results = _renwebService.ParentsWebFamilySearch(15328, RenwebUserType.Parent, directoryType).ToList();
            var successfulLoads = new List<RenwebFamilyResult>();
            var unsuccessfulLoads = new List<RenwebFamilyResult>();

            results.ForEach(x =>
            {
                try
                {
                    var existingResult = _service.RenwebFamilyResults.Get(y => y.personID.Equals(x.personID));
                    if (existingResult == null)
                    {
                        _service.RenwebFamilyResults.Insert(x);
                    }
                    else
                    {
                        Mapper.Map(x, existingResult);
                        _service.RenwebFamilyResults.Update(existingResult);
                    }
                    successfulLoads.Add(x);
                }
                catch
                {
                    unsuccessfulLoads.Add(x);
                }
            });

            var viewModel = new Tuple<IPagedList<RenwebFamilyResult>, List<RenwebFamilyResult>>(
                successfulLoads.OrderBy(x => x.Parents).ToPagedList(page, pageSize),
                unsuccessfulLoads.OrderBy(x => x.Parents).ToList()
            );

            return View(viewModel);
        }

        [UnitOfWork]
        public ActionResult ResetFamilyMembers()
        {
            // Prepare the family members table for an update by setting the IsProcessed flag to false.
            _service.RenwebFamilyMembersResults.ToList().ForEach(x =>
            {
                x.IsProcessed = false;
                _service.RenwebFamilyMembersResults.Update(x);
            });
            return RedirectToAction("FamilyMembersResultsLocal");
        }

        [UnitOfWork]
        public ActionResult PullFamilyMembersResults(int page = 1, int pageSize = 3, RenwebDataSource dataSource = RenwebDataSource.Local)
        {
            var successfulLoads = new List<RenwebFamilyMembersResult>();
            var unsuccessfulLoads = new List<RenwebFamilyMembersResult>();

            var familyResults = _service.RenwebFamilyResults.GetAll(x => !x.IsProcessed).ToList();

            familyResults.ForEach(x =>
            {
                var results = _renwebService.ParentsWebFamilyMembersSearch(x.personID, x.AddressID).ToList();

                var status = _service.Users.ImportRenwebFamily(results);
                if (status.Equals(RenwebImportStatus.Success))
                    results.ForEach(y => successfulLoads.Add(y));
                else if (status.Equals(RenwebImportStatus.Failure))
                    results.ForEach(y => unsuccessfulLoads.Add(y));

                x.IsProcessed = true;
                _service.RenwebFamilyResults.Update(x);
            });

            var viewModel = new Tuple<IPagedList<RenwebFamilyMembersResult>, List<RenwebFamilyMembersResult>>(
                successfulLoads.OrderBy(x => x.LastName).ToPagedList(page, pageSize),
                unsuccessfulLoads.OrderBy(x => x.LastName).ToList()
            );

            return View(viewModel);
        }
    }
}