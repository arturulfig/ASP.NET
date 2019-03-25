using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forms.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Forms.Controllers
{
    public class ConferenceController : Controller
    {
        public static IndexModel SavedUsers { get; set; } = new IndexModel();
        private readonly IHostingEnvironment _hostingEnvironment;
        public ConferenceController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            if (SavedUsers.GetUsers == null) SavedUsers.GetUsers = new List<ConferenceUser>();
        }

        // GET: Conference
        public ActionResult Index(int page = 1, int itemsPerPage = 5)
        {

            // Clone only SavedUsers.GetUsers
            var output = new IndexModel();
            output.CurrentPage = page;
            output.TotalPageCount = SavedUsers.GetUsers.Count / itemsPerPage;
            if (page > output.TotalPageCount && output.TotalPageCount != 0)
            {
                return Redirect("/Conference?page=" + output.TotalPageCount);
            }
            output.ConferenceUser = SavedUsers.ConferenceUser;
            output.GetUsers = new List<ConferenceUser>();
            output.GetUsers = SavedUsers.GetUsers;

            // page--;
            output.GetUsers = output.GetUsers.Skip(page - 1 * itemsPerPage).Take(itemsPerPage).ToList();

            return View(output);
        }

        // GET: Conference/Create
        public ActionResult Create()
        {
            return View();
        }

        public string LoadFromFile()
        {
            // System.Console.WriteLine(System.IO.File.ReadAllText(@"./MOCK_DATA.json"));
            // JObject o1 = JObject.Parse(System.IO.File.ReadAllText(@"./MOCK_DATA.json"));
            SavedUsers.GetUsers =
            JsonConvert.DeserializeObject<List<ConferenceUser>>(
                System.IO.File.ReadAllText(@"./MOCK_DATA.json")
            );
            return "Loaded";
        }

        public ActionResult DownloadUsers()
        {
            string json = JsonConvert.SerializeObject(SavedUsers.GetUsers);
            byte[] jsonBytes = Encoding.UTF8.GetBytes(json);
            return File(jsonBytes, "application/force-download", "users.json");
        }



        // [HttpPost]
        // public IActionResult Create(CreatePost model)
        // {
        //     // do other validations on your model as needed
        //     if (model.MyImage != null)
        //     {
        //         var uniqueFileName = GetUniqueFileName(model.MyImage.FileName);
        //         var uploads = Path.Combine(hostingEnvironment.WebRootPath, "uploads");
        //         var filePath = Path.Combine(uploads, uniqueFileName);
        //         model.MyImage.CopyTo(new FileStream(filePath, FileMode.Create));

        //         //to do : Save uniqueFileName  to your db table   
        //     }
        //     // to do  : Return something
        //     return RedirectToAction("Index", "Home");
        // }
        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(fileName);
        }

        // POST: Conference/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ConferenceUser conferenceUser, IFormFile avatar)
        {
            if (SavedUsers.GetUsers == null) SavedUsers.GetUsers = new List<ConferenceUser>();

            try
            {
                // full path to file in temp location
                // var filePath = @"C:\Users\Konrad\Documents\ASP.NET\Forms\Forms\wwwroot\avatars\" + SavedUsers.GetUsers.Count + ".png";

                if (avatar != null)
                {
                    var uniqueFileName = GetUniqueFileName(avatar.FileName);
                    var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "avatars");
                    var filePath = Path.Combine(uploads, uniqueFileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        avatar.CopyToAsync(stream);
                    }
                    conferenceUser.Avatar = uniqueFileName;
                }
                else
                {
                    conferenceUser.Avatar = "";
                }


                SavedUsers.GetUsers.Add(conferenceUser);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}