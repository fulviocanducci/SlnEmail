using FluentEmail.Core;
using FluentEmail.Razor;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web.Models;

namespace Web.Controllers
{
   public class HomeController : Controller
   {
      private readonly ILogger<HomeController> _logger;
      private readonly IFluentEmail _fluentEmail;

      public HomeController(ILogger<HomeController> logger, IFluentEmail fluentEmail)
      {
         _logger = logger;
         _fluentEmail = fluentEmail;
      }

      public IActionResult Index()
      {
         return View();
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

      public IActionResult SendEmail()
      {
         var template = "Dear @Model.Name, You are totally @Model.Compliment.";
         Email.DefaultRenderer = new RazorRenderer();
         var email = _fluentEmail
            .SetFrom("recoverymiles@s2milhas.com.br")
             .To("recoverymiles@s2milhas.com.br")
             .Subject("woo nuget")
             //.UsingTemplate(template, new { Name = "Luke", Compliment = "Awesome" })
             .UsingTemplateFromFile($"{Directory.GetCurrentDirectory()}/Template/Base.cshtml", new BaseCshtml());
         email.Send();
         return View();
      }
   }
}

public class BaseCshtml
{
   public string Name { get; set; } = "Luke";
   public string Compliment { get; set; } = "Awesome";
}