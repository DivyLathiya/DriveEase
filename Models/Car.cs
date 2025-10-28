namespace CarRentalMvc.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; } // Use decimal for currency
        public string Img { get; set; }
    }
}
