using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LinqCar
{
    public class Car
    {
        [JsonPropertyName("id")]
        public int ID { get; set; }

        [JsonPropertyName("car_make")]
        public string Make { get; set; }

        [JsonPropertyName("car_model")]
        public string Model { get; set; }

        [JsonPropertyName("car_year")]
        public int Year { get; set; }

        [JsonPropertyName("number_of_doors")]
        public int NumberOfDoors { get; set; }

        [JsonPropertyName("hp")]
        public int HP { get; set; }

        public static async Task<IEnumerable<Car>> GetAllCarsAsync()
        {
            // The clean way of doing things like this
            string fileContents = await File.ReadAllTextAsync("car_data.json");
            IEnumerable<Car> allCars = JsonSerializer.Deserialize<IEnumerable<Car>>(fileContents);
            return allCars;
        }

        public static IEnumerable<Car> GetAllCarsSync()
        {
            // The dirty way of doing things like this
            var fileContents = File.ReadAllText("car_data.json");
            var cars = JsonSerializer.Deserialize<IEnumerable<Car>>(fileContents);
            return cars;
        }

        public static void PrintSomeCars()
        {
            var cars = Car.GetAllCarsAsync().Result;

            string s1 = "standdard string";
            string s2 = "C:\\Windows\\system32\\Goran Todorovic";
            string s3 = @"C:\Windows\system32";
            var number = 5423123;

            // *** Print all cars with at least 4 doors
            // var carsWithAtLeastFourDoors = cars.Where(car => car.NumberOfDoors >= 4);
            // foreach (var car in carsWithAtLeastFourDoors)
            // {
            //     Console.WriteLine($"The car {car.Model} has {car.NumberOfDoors} doors");
            // }

            // *** Print all Mazda with at least 4 doors
            // var mazdasWithAtLeastFourDoors = cars.Where(car => car.Make == "Mazda" && car.NumberOfDoors >= 4);
            // foreach (var car in mazdasWithAtLeastFourDoors)
            // {
            //     Console.WriteLine($"The {car.Make} {car.Model} has {car.NumberOfDoors} doors");
            // }

            // *** Print Make + Model for all Makes that starts with "M"
            // cars.Where(car => car.Make.StartsWith("M"))
            //     .Select(car => $"{car.Make} {car.Model}")
            //     .ToList()
            //     .ForEach(car => Console.WriteLine(car));

            // *** Display a list of the 10 most powerful cars (in terms of hp)
            cars.OrderByDescending(car => car.HP)
                .Take(10)
                .Select(car => $"{car.Make} {car.Model} has {car.HP} hp")
                .ToList()
                .ForEach(car => Console.WriteLine(car));

            // *** Display the number of models that appeared after 1995
            // cars.Where(car => car.Year > 1995)
            //     .GroupBy(car => car.Make)
            //     .Select(car => new
            //     {
            //         Make = car.Key,
            //         NumberOfModels = car.Count()
            //     })
            //     .ToList()
            //     .ForEach(car => Console.WriteLine($"{car.Make} has {car.NumberOfModels} models that appeared after 1995"));

            // *** Display the number of models per make appeared after 2008
            // *** Makes should display '0' if there are no models after 2008
            // cars.GroupBy(car => car.Make)
            //     .Select(car => new
            //     {
            //         Make = car.Key,
            //         NumberOfModels = car.Count(c => c.Year > 2008)
            //     })
            //     .ToList()
            //     .ForEach(car => Console.WriteLine($"{car.Make}: {car.NumberOfModels}"));

            // *** Display a list of makes that have at least 2 models with >= 400 hp
            // cars.Where(car => car.HP >= 400)
            //     .GroupBy(car => car.Make)
            //     .Select(car => new
            //     {
            //         Make = car.Key,
            //         NumberOfPowerfulCars = car.Count()
            //     })
            //     .Where(car => car.NumberOfPowerfulCars >= 2)
            //     .ToList()
            //     .ForEach(car => Console.WriteLine($"{car.Make}: {car.NumberOfPowerfulCars}"));

            // *** Display the average hp per make
            // cars.GroupBy(car => car.Make)
            //     .Select(car => new 
            //     {
            //         Make = car.Key,
            //         AverageHP = car.Average(c => c.HP)
            //     })
            //     .ToList()
            //     .ForEach(car => Console.WriteLine($"{car.Make}: {car.AverageHP:0}"));

            // *** How many makes build cars with hp between 0..100, 101..200, 201..300, 301..400, 401..500
            // cars.GroupBy(car => car.HP switch
            // {
            //     <= 100 => "  0..100",
            //     <= 200 => "101..200",
            //     <= 300 => "201..300",
            //     <= 400 => "301..400",
            //     <= 500 => "401..500",
            //     _ => "501..600"
            // })
            // .Select(car => new
            // {
            //     HPCategory = car.Key,
            //     NumberOfMake = car.Select(c => c.Make).Distinct().Count()
            // })
            // .OrderBy(car => car.HPCategory)
            // .ToList()
            // .ForEach(car => Console.WriteLine($"{car.HPCategory}: {car.NumberOfMake}"));

        }

    }
}