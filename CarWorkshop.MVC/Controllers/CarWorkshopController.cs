using CarWorkshop.Application.CarWorkshop;
using CarWorkshop.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarWorkshop.MVC.Controllers
{
    public class CarWorkshopController : Controller
    {
        private readonly ICarWorkshopeService _carWorkshopeService;

        public CarWorkshopController(ICarWorkshopeService carWorkshopeService)
        {
            _carWorkshopeService = carWorkshopeService;
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task <IActionResult> Create(CarWorkshopDto carWorkshop)
        {
            await _carWorkshopeService.Create(carWorkshop);
            return RedirectToAction(nameof(Create));
        }
    }
}
