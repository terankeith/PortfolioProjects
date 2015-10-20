using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarDealership.Models;

namespace CarDealership.Repositories
{
    public class CodeFirstEFRepository : ICarRepository
    {
        public void AddCar(Car car)
        {
            using (CarContext CarDB = new CarContext())
            {
                Car newCar = new Car();
                {
                    newCar.Id = car.Id;
                    newCar.Make = car.Make;
                    newCar.Model = car.Model;
                    newCar.Year = car.Year;
                    newCar.ImageUrl = car.ImageUrl;
                    newCar.Title = car.Title;
                    newCar.Description = car.Description;
                    newCar.Price = (decimal)car.Price;
                };
                CarDB.Cars.Add(newCar);
                CarDB.SaveChanges();
            }
        }

        public void DeleteCar(int carId)
        {
            throw new NotImplementedException();
        }

        public void EditCar(Car car)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAllCars()
        {
            throw new NotImplementedException();
        }

        public Car GetCarById(int id)
        {
            throw new NotImplementedException();
        }

        public Car GetCarByModel(string name)
        {
            throw new NotImplementedException();
        }

        public Car GetCarByYMM(string year, string make, string model)
        {
            throw new NotImplementedException();
        }

        public User LoginUser(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}