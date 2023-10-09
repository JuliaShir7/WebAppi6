namespace WebAppi6.Models
{
    public class Preference
    {
        //IPreferencable p;
        public long ID { get; set; }
        public virtual Cuisine? Cuisine { get; set; } 
        public virtual Category? Category { get; set; }
        public virtual SubCategory? SubCategory { get; set; } 
        public virtual Attraction? Attraction { get; set; } 

        public bool IsLiked { get; set; }
        public bool IsConstant { get; set; }
    }
}
