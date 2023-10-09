namespace WebAppi6.Models
{
    public class Category: IPreferencable
    {
        public long ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public virtual ICollection<SubCategory> SubCategories { get; set; } = new List<SubCategory>();
    }
}
