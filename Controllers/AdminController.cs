using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization; // <-- This is CRITICAL
using CarRentalMvc.Data;
using CarRentalMvc.Models;

namespace CarRentalMvc.Controllers
{
    // This attribute locks the *entire* controller.
    // Only users with the "Admin" role can access any of these actions.
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly MockDataService _dataService;

        public AdminController(MockDataService dataService)
        {
            _dataService = dataService;
        }

        // GET: /Admin/Index (or /Admin)
        // This is the ADMIN'S dashboard
        public IActionResult Index()
        {
            var model = new AdminDashboardViewModel
            {
                Fleet = _dataService.GetCars(),
                Bookings = _dataService.GetBookings()
            };
            return View(model);
        }

        // POST: /Admin/SaveCar
        [HttpPost]
        public IActionResult SaveCar(Car car)
        {
            // This action handles both ADDING and EDITING a car
            if (ModelState.IsValid)
            {
                _dataService.SaveCar(car);
                TempData["SuccessMessage"] = "Car saved successfully!";
            }
            return RedirectToAction("Index");
        }

        // POST: /Admin/DeleteCar/5
        [HttpPost]
        public IActionResult DeleteCar(int id)
        {
            _dataService.DeleteCar(id);
            TempData["SuccessMessage"] = "Car deleted successfully.";
            return RedirectToAction("Index");
        }

        // POST: /Admin/ConfirmBooking/2
        [HttpPost]
        public IActionResult ConfirmBooking(int id)
        {
            _dataService.UpdateBookingStatus(id, "Confirmed");
            TempData["SuccessMessage"] = "Booking confirmed.";
            return RedirectToAction("Index");
        }
        
        // POST: /Admin/CancelBooking/2
        [HttpPost]
        public IActionResult CancelBooking(int id)
        {
            _dataService.UpdateBookingStatus(id, "Cancelled");
            TempData["SuccessMessage"] = "Booking cancelled.";
            return RedirectToAction("Index");
        }
    }
}
