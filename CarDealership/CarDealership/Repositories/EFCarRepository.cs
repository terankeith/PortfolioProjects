using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarDealership.Models;

namespace CarDealership.Repositories
{
    public class EFCarRepository : ICarRepository
    {
        public void AddCar(Car car)
        {
            using (CarDBEntities CarDB = new CarDBEntities())
            {
                var newCar = new EFCar();
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
                CarDB.EFCars.Add(newCar);
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
            List<Car> cars = new List<Car>();

            using (CarDBEntities CarDB = new CarDBEntities())
            {
                foreach(var item in CarDB.EFCars)
                {
                    Car newCar = new Car();
                    newCar.Id = item.Id;
                    newCar.Make = item.Make;
                    newCar.Model = item.Model;
                    newCar.Year = item.Year;
                    newCar.ImageUrl = item.ImageUrl;
                    newCar.Title = item.Title;
                    newCar.Description = item.Description;
                    newCar.Price = item.Price;
                    cars.Add(newCar);
                }
            }
            return cars;
        }

        public Car GetCarById(int id)
        {
            return GetAllCars().FirstOrDefault(x => x.Id == id);
        }

        public Car GetCarByModel(string name)
        {
            throw new NotImplementedException();
        }

        public Car GetCarByYMM(string year, string make, string model)
        {                         
            return GetAllCars().FirstOrDefault(x => x.Year == year && x.Make == make && x.Model == model);            
        }

        public User LoginUser(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}