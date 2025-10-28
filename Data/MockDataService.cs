using CarRentalMvc.Models;
using System.Collections.Generic;
using System.Linq;

namespace CarRentalMvc.Data
{
    // A thread-safe singleton service to hold our mock data
    public class MockDataService
    {
        private readonly List<Car> _cars = new List<Car>
        {
            new Car { Id = 1, Name = "Toyota Camry", Type = "Sedan", Price = 55, Img = "https://placehold.co/600x400/3b82f6/white?text=Toyota+Camry" },
            new Car { Id = 2, Name = "Honda CR-V", Type = "SUV", Price = 70, Img = "https://placehold.co/600x400/10b981/white?text=Honda+CR-V" },
            new Car { Id = 3, Name = "Ford F-150", Type = "Truck", Price = 85, Img = "https://placehold.co/600x400/ef4444/white?text=Ford+F-150" },
            new Car { Id = 4, Name = "Dodge Grand Caravan", Type = "Van", Price = 75, Img = "https://placehold.co/600x400/f97316/white?text=Dodge+Van" },
            // --- NEW CARS ADDED ---
            new Car { Id = 5, Name = "Chevrolet Camaro", Type = "Coupe", Price = 120, Img = "https://placehold.co/600x400/ec4899/white?text=Chevy+Camaro" },
            new Car { Id = 6, Name = "Nissan Rogue", Type = "SUV", Price = 65, Img = "https://placehold.co/600x400/6366f1/white?text=Nissan+Rogue" },
            new Car { Id = 7, Name = "Tesla Model 3", Type = "Electric", Price = 110, Img = "https://placehold.co/600x400/14b8a6/white?text=Tesla+Model+3" },
            new Car { Id = 8, Name = "Jeep Wrangler", Type = "Off-road", Price = 90, Img = "https://placehold.co/600x400/f59e0b/white?text=Jeep+Wrangler" },
            new Car { Id = 9, Name = "Kia Telluride", Type = "SUV", Price = 72, Img = "https://placehold.co/600x400/8b5cf6/white?text=Kia+Telluride" }
            // --- END OF NEW CARS ---
        };

        private readonly List<Booking> _bookings = new List<Booking>
        {
            new Booking { Id = 1, CarId = 2, CarName = "Honda CR-V", UserName = "Alice Smith", UserEmail = "user@example.com", PickupDate = DateTime.Now.AddDays(10), DropoffDate = DateTime.Now.AddDays(12), Total = 140, Status = "Confirmed" },
            new Booking { Id = 2, CarId = 1, CarName = "Toyota Camry", UserName = "Bob Johnson", UserEmail = "bob@example.com", PickupDate = DateTime.Now.AddDays(11), DropoffDate = DateTime.Now.AddDays(15), Total = 220, Status = "Pending" }
        };

        // --- UPDATED NEXT ID ---
        private static int _nextCarId = 10;
        private static int _nextBookingId = 3;

        // Thread-safe lock objects
        private readonly object _carLock = new object();
        private readonly object _bookingLock = new object();

        // --- Car Methods ---
        public List<Car> GetCars() => _cars;
        public Car GetCar(int id) => _cars.FirstOrDefault(c => c.Id == id);
        public void SaveCar(Car car)
        {
            lock (_carLock)
            {
                if (car.Id == 0) // New car
                {
                    car.Id = _nextCarId++;
                    _cars.Add(car);
                }
                else // Existing car
                {
                    var existing = _cars.FirstOrDefault(c => c.Id == car.Id);
                    if (existing != null)
                    {
                        existing.Name = car.Name;
                        existing.Type = car.Type;
                        existing.Price = car.Price;
                        existing.Img = car.Img;
                    }
                }
            }
        }
        public void DeleteCar(int id)
        {
            lock (_carLock)
            {
                var car = _cars.FirstOrDefault(c => c.Id == id);
                if (car != null) _cars.Remove(car);
            }
        }

        // --- Booking Methods ---
        public List<Booking> GetBookings() => _bookings;
        public Booking GetBooking(int id) => _bookings.FirstOrDefault(b => b.Id == id);
        public void AddBooking(Booking booking)
        {
            lock (_bookingLock)
            {
                booking.Id = _nextBookingId++;
                booking.Status = "Pending"; // All new bookings are pending
                _bookings.Add(booking);
            }
        }
        public void UpdateBookingStatus(int id, string status)
        {
            lock (_bookingLock)
            {
                var booking = _bookings.FirstOrDefault(b => b.Id == id);
                if (booking != null)
                {
                    booking.Status = status;
                }
            }
        }
    }
}

