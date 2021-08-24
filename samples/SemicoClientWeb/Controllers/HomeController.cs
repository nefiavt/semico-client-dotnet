using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SemicoClient.Services;
using SemicoClientWeb.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace SemicoClientWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISemicoClientService semicoClient;
        private readonly IWebHostEnvironment appEnv;

        public HomeController(ILogger<HomeController> logger, ISemicoClientService semicoClient, IWebHostEnvironment appEnv)
        {
            _logger = logger;
            this.semicoClient = semicoClient;
            this.appEnv = appEnv;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string btn)
        {

            byte[] template = await System.IO.File.ReadAllBytesAsync($@"{appEnv.ContentRootPath}/Templates/DocX/simple.docx");
            byte[] jsonData = await System.IO.File.ReadAllBytesAsync($@"{appEnv.ContentRootPath}/Templates/DocX/simple.json");

            Stream document = await semicoClient.GenerateDocument(template, jsonData);



            return File(document, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "simple.docx");
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
