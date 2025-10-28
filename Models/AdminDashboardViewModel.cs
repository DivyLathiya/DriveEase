using System.Collections.Generic;

namespace CarRentalMvc.Models
{
    // This model is used to pass *two* lists to the Admin dashboard view
    public class AdminDashboardViewModel
    {
        public List<Car> Fleet { get; set; }
        public List<Booking> Bookings { get; set; }
    }
}
