namespace WasteAway.Models
{
    public class Truck
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int ZipcodeId { get; set; }
        public Zipcode Zipcode { get; set; }
    }
}