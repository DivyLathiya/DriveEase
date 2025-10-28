using System;
using System.ComponentModel.DataAnnotations;

namespace CarRentalMvc.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string CarName { get; set; }

        [Required]
        public string UserEmail { get; set; } // This will be set from the logged-in user

        [Required]
        [Display(Name = "Full Name")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Pickup Date")]
        public DateTime PickupDate { get; set; }

        [Required]
        [Display(Name = "Dropoff Date")]
        public DateTime DropoffDate { get; set; }

        public decimal Total { get; set; }
        public string Status { get; set; } // "Pending", "Confirmed", "Cancelled"
    }
}
