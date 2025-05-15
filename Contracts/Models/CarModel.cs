namespace Contracts.Models
{
    public class CarModel : IVehicle
    {
        public int Id { get; set; }
        public float Price { get; set; }
        public string Name { get; set; }
        //some other stuff
    }
}