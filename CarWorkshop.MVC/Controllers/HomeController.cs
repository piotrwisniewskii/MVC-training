using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CarWorkshop.MVC.Models;

namespace CarWorkshop.MVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult About()
    {
        var about = new AboutModel();
        about.Title = "O mnie";
        about.Description = "Rozpoczynam nową przygodę!";
        about.Tags = new List<string> {"to","tamto","siamto" };
        return View(about);
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

    public IActionResult listGenerator()
    {
        var list = new ListGenerator();
        list.playerList.AddRange(new List<string> { "piotr", "łotr", "kot", "bot" });
        return View(list);
    }

    public IActionResult RandomListGenerator()
    {
        var list = new ListGenerator();
        var random = new Random();
        list.playerList.AddRange(new List<string> { "piotr", "łotr", "kot", "bot" });
        var randomizedList = random.Next(list.playerList.Count);
        return View(randomizedList);
    }
}
