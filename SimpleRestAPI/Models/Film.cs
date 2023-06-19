namespace SimpleRestAPI.Models
{
    public class Film
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public List<Category> Categories { get; set; } = new List<Category>();

        public List<Genre> Genres { get; set; } = new List<Genre>();
        public List<Ticket> Tickets { get; set; } = new List<Ticket>();

        public DateTime StartTime { get; set; }

    }
}
