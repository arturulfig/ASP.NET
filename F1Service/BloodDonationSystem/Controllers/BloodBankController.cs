using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloodDonationSystem.Models;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;


namespace BloodDonationSystem.Controllers
{
    public class BloodBankController : Controller
    {

        private DataAccessLayer dataAccessLayer;
        private string serverPath;
        private BloodBankViewModel viewModel;

        public ActionResult Index(int? page)
        {
            int pageSize = 100;
            int pageNumber = (page ?? 1);
            viewModel = new BloodBankViewModel();
            serverPath = Server.MapPath("/Database");
            dataAccessLayer = new DataAccessLayer(serverPath);

            public IActionResult Index()
        {
            return View();
        }
    }
}