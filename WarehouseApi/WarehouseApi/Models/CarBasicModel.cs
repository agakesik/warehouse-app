namespace WarehouseApi.Models
{
    public class CarBasicModel
    {
        public int Id { get; set; }
        public string Make { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int YearModel { get; set; }
        public decimal Price { get; set; }
        public bool Licensed { get; set; }
    }
}
