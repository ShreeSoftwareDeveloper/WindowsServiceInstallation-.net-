using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.ServiceProcess;
using Windows_Service_Control.Models;

namespace Windows_Service_Control.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public ActionResult Index()
        {
            ServiceController service = new ServiceController("PositiveReportingService");
            ViewBag.Status = service.Status.ToString();

            return View();
        }

        [HttpPost]
        public ActionResult StartService()
        {
            ServiceController service = new ServiceController("PositiveReportingService");
            service.Start();
            ViewBag.Status = service.Status.ToString();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult StopService()
        {
            ServiceController service = new ServiceController("PositiveReportingService");
            service.Stop();
            ViewBag.Status = service.Status.ToString();
            return RedirectToAction("Index");
        }
    }
}
