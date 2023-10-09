namespace WebAppi6.Models
{
    public class Attendance
    {
        public long ID { get; set; }
        //public virtual Individual Individual { get; set; }
        public virtual Attraction Attraction { get; set; }
        public bool IsVisited { get; set; }
    }
}
