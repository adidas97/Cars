using Cars.Data;
using Cars.Data.Models;
using Cars.Services.IServices;
using Cars.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cars.Services.ServicesImplementation
{
    public class CarService : ICarService
    {
        private readonly CarsDbContext db;


        public CarService(CarsDbContext db)
        {
            this.db = db;

        }

        public void CreateCar(Car model)
        {
            var car = new Car
            {
                Make = model.Make,
                Model = model.Model,
                MakeId = model.MakeId,
                ModelId = model.ModelId,
                Category = model.Category,
                Description = model.Description,
                HorsePower = model.HorsePower,
                Image = model.Image,
                Price = model.Price,
                TypeOfEngine = model.TypeOfEngine,
                TypeOfGearbox = model.TypeOfGearbox,
                YearOfBuilding = model.YearOfBuilding
            };

            db.Cars.Add(car);

            db.SaveChanges();
        }

        public void DeleteCar(int id)
        {
            var car = db.Cars.Find(id);
            if (car == null)
            {
                return;
            }
            db.Remove(car);
            db.SaveChanges();

           
        }

        public void Edit(int id, string description, decimal price, int year, int horsepower, string engine, string gearbox, string category)
        {
            var car = db.Cars.Find(id);
            if (car == null)
            {
                return;
            }
            car.Description = description;
            car.Price = price;
            car.YearOfBuilding = year;
            car.HorsePower = horsepower;
            car.TypeOfEngine = engine;
            car.TypeOfGearbox = gearbox;
            car.Category = category;


            db.SaveChanges();
        }

        public CarEditModel EditById(int id)
        => db
            .Cars
            .Where(e => e.Id == id)
            .Select(a => new CarEditModel
            {
                
                Price = a.Price,
                Description = a.Description,
                Category = a.Category,
                HorsePower = a.HorsePower,
                TypeOfEngine = a.TypeOfEngine,
                TypeOfGearbox = a.TypeOfGearbox,
                YearOfBuilding = a.YearOfBuilding
            }).FirstOrDefault();

        public ICollection<Make> GetMakes()
        {
            var makes = db.Makes.Select(e => new Make
            {
                MakeId = e.MakeId,
                NameOfMake = e.NameOfMake
            }).ToList();
            return makes;
        }


        public ICollection<Model> GetModels(int MakeId)
        {
            var models = db.Models.Where(
                e => e.Make.MakeId == MakeId).Select(e => new Model
                {
                    ModelId = e.ModelId,
                    NameOfModel = e.NameOfModel

                }).OrderBy(e => e.NameOfModel).ToList();
            models.Insert(0, new Model { ModelId = 0, NameOfModel = "Select Model" });

            return models;
        }

        public Car GetCarById(int id)
        {
            var car = db.Cars.Select(e => new Car
            {
                
                Make = e.Make,
                MakeId = e.MakeId,
                Model = e.Model,
                ModelId = e.ModelId,
               Category = e.Category,
               Description = e.Description,
               HorsePower = e.HorsePower,
               Id = e.Id,
               Price = e.Price,
               TypeOfEngine = e.TypeOfEngine,
               TypeOfGearbox = e.TypeOfGearbox,
               YearOfBuilding = e.YearOfBuilding
            }).FirstOrDefault(e => e.Id == id);
            return car;
        }

        public ICollection<Car> ListingOfCars() {

            var cars = db.Cars.Select(e => new Car
            {
                Id = e.Id,
                Make = e.Make,
                Model = e.Model,
                Price = e.Price,
                YearOfBuilding = e.YearOfBuilding
            }).ToList();

            return cars;
        }

        
    }
}
