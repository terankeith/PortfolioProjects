using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Repositories
{
    public interface ICarRepository //This is the Car repository interface all these methods must defined if a class implements this interface
    {
        List<Car> GetAllCars();
        Car GetCarById(int id);
        void AddCar(Car car);
        void EditCar(Car car);
        void DeleteCar(int carId);
        Car GetCarByModel(string name);
        Car GetCarByYMM(string year, string make, string model);
        User LoginUser(string username, string password);
    }
}
