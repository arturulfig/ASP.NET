using BloodDonation.DAL;
using BloodDonation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace BloodDonation.Controllers
{
    public class BloodBankController : Controller
    {
        private readonly string _serverPath;
        private readonly DataAccessLayer _dataAccessLayer;
        private readonly BloodBankViewModel _viewModel;

        public BloodBankController()
        {
            //_serverPath = Server.MapPath("/Data");
            _dataAccessLayer = new DataAccessLayer(@"C:\Users\artur\Desktop\Semestr VI\Projekty ASP\ASP.NET\BloodDonation\BloodDonation\DataFiles\Data");
            _viewModel = new BloodBankViewModel();
        }
        // GET: BloodBank   
        public ActionResult Index(int? page)
        {
            int pageSize = 100;
            int pageNo = (page ?? 1);
            _viewModel.ListOfDonators = _dataAccessLayer.ListOfDonators;
            _viewModel.addStats();
            _viewModel.PagedDonators = _dataAccessLayer.ListOfDonators.ToPagedList(pageNo, pageSize);
            ViewBag.PageNo = pageNo;
            return View(_viewModel);
        }
    }
}