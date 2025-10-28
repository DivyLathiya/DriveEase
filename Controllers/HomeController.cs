using Microsoft.AspNetCore.Mvc;
using CarRentalMvc.Models;
using CarRentalMvc.Data;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization; // To require login

namespace CarRentalMvc.Controllers
{
    [Authorize] // Require login for all pages in this controller
    public class HomeController : Controller
    {
        private readonly MockDataService _dataService;

        public HomeController(MockDataService dataService)
        {
            _dataService = dataService;
        }

        // GET: /Home/Index (or just /)
        // This is the USER'S dashboard (Car Listings)
        public IActionResult Index()
        {
            // Only show cars if the user is a "User"
            if (User.IsInRole("Admin"))
            {
                // Admins get sent to their own dashboard
                return RedirectToAction("Index", "Admin");
            }

            var cars = _dataService.GetCars();
            return View(cars); // Pass the list of cars to the View
        }

        // GET: /Home/Book/5
        [HttpGet]
        public IActionResult Book(int id)
        {
            var car = _dataService.GetCar(id);
            if (car == null) return NotFound();

            // Create a new booking model to pre-populate the form
            var model = new Booking
            {
                CarId = car.Id,
                CarName = car.Name,
                PickupDate = DateTime.Now.AddDays(1),
                DropoffDate = DateTime.Now.AddDays(3),
                UserEmail = User.Identity.Name // Get email from logged-in user
            };

            ViewBag.Car = car; // Send car details to the view
            return View(model);
        }

        // POST: /Home/Book
        [HttpPost]
        public IActionResult Book(Booking model)
        {
            if (ModelState.IsValid)
            {
                var car = _dataService.GetCar(model.CarId);
                if (car == null) return NotFound();
                
                // Calculate total price
                var days = (model.DropoffDate - model.PickupDate).TotalDays;
                model.Total = (decimal)days * car.Price;

                // Set user email from their login
                model.UserEmail = User.Identity.Name;

                _dataService.AddBooking(model);
                
                // Send user to a confirmation page
                return RedirectToAction("BookingConfirmation", new { id = model.Id });
            }

            // If form is invalid, show it again
            ViewBag.Car = _dataService.GetCar(model.CarId);
            return View(model);
        }
        
        // GET: /Home/BookingConfirmation/2
        [HttpGet]
        public IActionResult BookingConfirmation(int id)
        {
            var booking = _dataService.GetBooking(id);
            if(booking == null) return NotFound();
            return View(booking);
        }
    }
}
