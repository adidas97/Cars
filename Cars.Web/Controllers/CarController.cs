using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cars.Data.Models;
using Cars.Services.IServices;
using Cars.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cars.Web.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService service;
        

        public CarController(ICarService service)
        {
            this.service = service;
            
        }

        public IActionResult Index()
        {
            var cars = service.ListingOfCars();
            return View(cars);
        }

        [HttpPost]
        public IActionResult EditById(int id, CreateCarViewModel model)
        {
            service.Edit(id, model.Description, model.Price, model.YearOfBuilding,model.HorsePower,model.TypeOfEngine,model.TypeOfGearbox,model.Category);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult EditById(int id)
        {
            var car = service.EditById(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(new CreateCarViewModel
            {
                Category = car.Category,
                HorsePower = car.HorsePower,
                TypeOfEngine = car.TypeOfEngine,
                TypeOfGearbox = car.TypeOfGearbox,
                YearOfBuilding = car.YearOfBuilding,
                Price = car.Price,
                Description = car.Description
            });
        }

        public IActionResult Destroy(int id) => View(id);

        public IActionResult DeletingCar(int id)
        {

            service.DeleteCar(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateCar()
        {
            var makes = service.GetMakes();

            ViewBag.Makes = makes;
            return View();
        }
        [HttpPost]
        public IActionResult CreateCar(CreateCarViewModel model)
        {
            var car = new Car
        {
            MakeId = model.MakeId,
            ModelId = model.ModelId,
            Price = model.Price,
            Description = model.Description,
            Category = model.Category,
            HorsePower = model.HorsePower,
            TypeOfEngine = model.TypeOfEngine,
            TypeOfGearbox = model.TypeOfGearbox,
            YearOfBuilding = model.YearOfBuilding
           

        };

        service.CreateCar(car);

            return RedirectToAction(nameof(Index));
    }

    public JsonResult GetModels(int MakeId)
        {

            var models = service.GetModels(MakeId);

            return Json(new SelectList(models, "ModelId", "NameOfModel"));

        }

        public IActionResult Details(int id)
        {
            var car = service.GetCarById(id);

            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

    }
}