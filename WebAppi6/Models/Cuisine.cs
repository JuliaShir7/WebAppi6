namespace WebAppi6.Models
{
    public class Cuisine: IPreferencable
    {
        public long ID { get; set; }
        public string Name { get; set; } = null!;
    }
}
