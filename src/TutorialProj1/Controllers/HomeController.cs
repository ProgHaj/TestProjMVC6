using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.Framework.OptionsModel;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TutorialProj1.Controllers
{
    [Route("home")]
    public class HomeController : Controller
    {
        private MyConfig _config;

        public HomeController(MyConfig config)
        {
            _config = config;

        }
        [Route("")]
        [Route("~/")]
        public IActionResult Index()
        {
            ViewBag.AppName = _config.SiteName;
            return View("Index");
        }

        [Route("projects")]
        public IActionResult Project()
        {
            _config.Owner = "test";
            ViewBag.AppName = _config.SiteName;
            return View("Projects");
        }

        [Route("about")]
        public IActionResult About()
        {
            ViewBag.AppName = _config.Owner;
            return View("About");
        }
    }
}
