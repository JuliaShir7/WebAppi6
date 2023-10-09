namespace WebAppi6.Models
{
    public class Route
    {
        public long ID { get; set; }
        public double Rating { get; set; }
        public double Distance { get; set; }
        public double Time { get; set; }
        public Transport Transport { get; set; }
        public string? Description { get; set; }
        public virtual Category Category { get; set; } = new Category();
        //public bool IsCurrent { get; set; } //0-нет, 1-да
        public virtual ICollection<Attraction> Places { get; set; } = new List<Attraction>();

        public Route() { }
        public Route(long iD, double rating, double distance, double time, Transport transport, string? description, /*bool iscurrent,*/ Category category/*, Dictionary<Attraction, Attendance> places*/)
        {
            ID = iD;
            Rating = rating;
            Distance = distance;
            Time = time;
            Transport = transport;
            Description = description;
            //IsCurrent = iscurrent;
            Category = category;
        }
        public Route(double rating, double distance, double time, Transport transport, string? description, /*bool iscurrent,*/ Category category/*, Dictionary<Attraction, Attendance> places*/)
        {
            Rating = rating;
            Distance = distance;
            Time = time;
            Transport = transport;
            Description = description;
            //IsCurrent = iscurrent;
            Category = category;
        }
    }
    public class CurrentRoute : Route
    {
        public bool IsCurrent { get; set; }
        //public virtual Individual Individual { get; set; }
        public CurrentRoute() : base() { }

        public CurrentRoute(long iD, double rating, double distance, double time, Transport transport, string? description, Category category, bool iscurrent) : base(iD, rating, distance, time, transport, description, category)
        {
            ID = iD;
            Rating = rating;
            Distance = distance;
            Time = time;
            Transport = transport;
            Description = description;
            IsCurrent = iscurrent;
            Category = category;
            //Individual = individual;
        }
        public CurrentRoute(double rating, double distance, double time, Transport transport, string? description, Category category, bool iscurrent) : base(rating, distance, time, transport, description, category)
        {
            Rating = rating;
            Distance = distance;
            Time = time;
            Transport = transport;
            Description = description;
            IsCurrent = iscurrent;
            Category = category;
            //Individual = individual;
        }
    }
}
