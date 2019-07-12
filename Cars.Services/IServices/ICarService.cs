using Cars.Data.Models;
using Cars.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cars.Services.IServices
{
   public interface ICarService
    {
        ICollection<Car> ListingOfCars();
        ICollection<Make> GetMakes();
        ICollection<Model> GetModels(int MakeId);
        void CreateCar(Car model);
        Car GetCarById(int id);
        void DeleteCar(int id);
        CarEditModel EditById(int id);
        void Edit(int id, string description, decimal price, int year, int horsepower, string engine, string gearbox, string category);
    }
}
