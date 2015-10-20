using CarDealership.Models;
using CarDealership.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.Controllers
{
    public class CarController : Controller
    {
        ICarRepository _repo = new MockCarRepository();

        // GET: Car
        public ActionResult Index()
        {
            var cars = _repo.GetAllCars();
            return View(cars);
        }

        public ActionResult Details(int id)
        {
            var car = _repo.GetCarById(id);
            return View(car);
        }

        public ActionResult CarDetails(string Year, string Make, string Model)
        {
            Car carReturned = _repo.GetCarByYMM(Year, Make, Model);

            if (carReturned == null)
            {
                return RedirectToAction("Index");
            }
            return View("Details", carReturned);
           
        }

        public ActionResult Add()
        {
            return View(new Car());
        }

        [HttpPost]
        public ActionResult Add(Car newCar)
        {
            if (ModelState.IsValid)
            {
                _repo.AddCar(newCar);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Add");
            }
            
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginUser(string username, string password)
        {
            var user = _repo.LoginUser(username, password);
            ViewBag.User = user;
            if (user == null)
            {
                return View("Login");
            }
            else { 
                var cars = _repo.GetAllCars();
                return View("Index", cars);
            }
        }
    }
}