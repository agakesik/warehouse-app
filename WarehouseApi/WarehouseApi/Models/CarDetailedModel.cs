namespace WarehouseApi.Models
{
    public class CarDetailedModel
    {
        public int Id { get; set; }
        public string Make { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int YearModel { get; set; }
        public decimal Price { get; set; }
        public bool Licensed { get; set; }
        public string WarehouseName { get; set; } = string.Empty;
        public double WarehouseLatitude { get; set; }
        public double WarehouseLongitude { get; set; }
    }
}
