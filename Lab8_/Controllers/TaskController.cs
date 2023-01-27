using Microsoft.AspNetCore.Mvc;
using Lab8_.Models;
using System.Text.Json;

namespace Lab8_.Controllers {
    [Serializable]
    public class TaskController : Controller {
        private readonly ILogger<TaskController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public TaskController(ILogger<TaskController> logger, IWebHostEnvironment webHostEnvironment) {
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Task1() {
            ModelData model = new ModelData();
            model._dT = DateTime.Now;
            model._appEnv = _webHostEnvironment.EnvironmentName;// ???
            model._appName = _webHostEnvironment.ApplicationName;// ???
            model._appHost = this.Request.Host.Value;
            model._appProtocol = this.Request.Protocol;
            return View(model);
        }
        public IActionResult Task2() {


            ViewBag.JsonString = JsonSerializer.Serialize(new IndexController());
            //return new JsonResult(this);
            //return new JsonResult(new IndexController());
            return View();


        }
        public IActionResult Task3(string? str1, int? str2, double str3) {
            ViewData["str1"] = str1;
            ViewData["str2"] = str2;
            ViewData["str3"] = str3;
            return View();
        }
    }
}
