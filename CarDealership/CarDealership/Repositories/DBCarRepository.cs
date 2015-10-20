using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CarDealership.Repositories
{
    public class DBCarRepository : ICarRepository
    {
        private const string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=CarDB;Integrated Security=True";

        public List<Car> GetAllCars()
        {
            List<Car> cars = new List<Car>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Car", conn);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Car newCar = new Car();
                    newCar.Id = reader.GetInt32(0);
                    newCar.Make = reader.GetString(1);
                    newCar.Model = reader.GetString(2);
                    newCar.Year = reader.GetString(3);
                    newCar.ImageUrl = reader.GetString(4);
                    newCar.Title = reader.GetString(5);
                    newCar.Description = reader.GetString(6);
                    newCar.Price = reader.GetDecimal(7);
                    cars.Add(newCar);
                }
            }

            return cars;
        }

        public Car GetCarById(int id)
        {
            return GetAllCars().FirstOrDefault(x => x.Id == id);
        }

        public User LoginUser(string username, string password)
        {
            User theUser = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT TOP 1 * FROM Users WHERE Username = '" + username + "' AND [Password] = '" + password + "'", conn);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                
                while (reader.Read())
                {
                    theUser = new User();
                    theUser.UserId = reader.GetInt32(0);
                    theUser.Username = reader.GetString(1);
                    theUser.Password = reader.GetString(2);
                    theUser.UserMessage = reader.GetString(3);
                }
            }
            return theUser;
        }

        public Car GetCarByModel(string name)
        {
            Car newCar = new Car();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Car WHERE Model = '" + name + "'", conn);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    newCar = new Car();
                    newCar.Id = reader.GetInt32(0);
                    newCar.Make = reader.GetString(1);
                    newCar.Model = reader.GetString(2);
                    newCar.Year = reader.GetString(3);
                    newCar.ImageUrl = reader.GetString(4);
                    newCar.Title = reader.GetString(5);
                    newCar.Description = reader.GetString(6);
                    newCar.Price = reader.GetDecimal(7);
                }
            }
            return newCar;
        }

        public Car GetCarByYMM(string Year, string Make, string Model)
        {
            throw new NotImplementedException();
        }

        public void AddCar(Car car)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                var commandText = "INSERT INTO Car (Make, Model, Year, ImageUrl, Title, Description, Price) VALUES (@Make, @Model, @Year, @ImageUrl, @Title, @Description, @Price)";
                SqlCommand command = new SqlCommand(commandText, conn);
                command.Parameters.AddWithValue("@Make", car.Make);
                command.Parameters.AddWithValue("@Model", car.Model);
                command.Parameters.AddWithValue("@Year", car.Year);
                command.Parameters.AddWithValue("@ImageUrl", car.ImageUrl);
                command.Parameters.AddWithValue("@Description", car.Description);
                command.Parameters.AddWithValue("@Title", car.Title);
                command.Parameters.AddWithValue("@Price", car.Price);

                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void EditCar(Car car)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                var commandText = "UPDATE Car SET Make = @Make, Model = @Model, Year = @Year, ImageUrl = @ImageUrl, Title = @Title, Description = @Description, Price = @Price WHERE Id = @Id";
                SqlCommand command = new SqlCommand(commandText, conn);
                command.Parameters.AddWithValue("@Id", car.Id);
                command.Parameters.AddWithValue("@Make", car.Make);
                command.Parameters.AddWithValue("@Model", car.Model);
                command.Parameters.AddWithValue("@Year", car.Year);
                command.Parameters.AddWithValue("@ImageUrl", car.ImageUrl);
                command.Parameters.AddWithValue("@Description", car.Description);
                command.Parameters.AddWithValue("@Title", car.Title);
                command.Parameters.AddWithValue("@Price", car.Price);

                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteCar(int carId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                var commandText = "DELETE FROM Car WHERE Id = @Id";
                SqlCommand command = new SqlCommand(commandText, conn);
                command.Parameters.AddWithValue("@Id", carId);

                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}