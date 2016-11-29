namespace WasteAway.Models
{
    public class Pickup
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}