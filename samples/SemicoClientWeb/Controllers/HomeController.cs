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
using SemicoClient.Models;

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
        public async Task<IActionResult> Index(string generateBtn)
        {
            byte[] template = await System.IO.File.ReadAllBytesAsync($@"{appEnv.ContentRootPath}/Templates/DocX/simple.docx");
            byte[] jsonData = await System.IO.File.ReadAllBytesAsync($@"{appEnv.ContentRootPath}/Templates/DocX/simple.json");


            if (generateBtn == "docx")
            {
                Stream document = await semicoClient.GenerateDocument(template, jsonData);

                return File(document, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "simple.docx");
            }
            else
            {
                DocumentOptions documentOptions = new DocumentOptions
                {
                    ConvertToPdf = true,
                    PdfOptions = new PdfOptions
                    {
                        AdditionalMetadata = "More metadata",
                        Application = "Semico Sample Web",
                        Author = "Nefia",
                        Producer = "Semico",
                        Subject = "Semico client",
                        Title = "PDF generation",
                    }
                };

                Stream document = await semicoClient.GenerateDocument(template, jsonData, documentOptions);

                return File(document, "application/pdf", "simple.pdf");
            }
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
