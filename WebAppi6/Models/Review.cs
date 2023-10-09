namespace WebAppi6.Models
{
    public class Review
    {
        public long ID { get; set; }
        public string Author { get; set; }
        public DateOnly Date { get; set; }
        public double Rating { get; set; }
        public int MaxRating { get; set; }
        public string Text { get; set; }

        public Review() { }
        public Review(long id, string author, DateOnly date, double rating, int maxRating, string text)
        {
            ID = id;
            Author = author;
            Date = date;
            Rating = rating;
            MaxRating = maxRating;
            Text = text;
        }
        public Review(string author, DateOnly date, double rating, int maxRating, string text)
        {
            Author = author;
            Date = date;
            Rating = rating;
            MaxRating = maxRating;
            Text = text;
        }
    }
}
