namespace SimpleRestAPI.Models
{
    public class Ticket
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string OwnerName { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public double Price { get; set; }

        public int PlaceNumber { get; set; }
    }
}
