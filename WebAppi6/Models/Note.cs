namespace WebAppi6.Models
{
    public class Note
    {
        public long ID { get; set; }
        public virtual Attraction Attraction { get; set; }
        //public Individual Individual { get; set; }
        public string Text { get; set; }
        public DateOnly Date { get; set; }
        //public void Update(Note note)
        //{
        //    Text = note.Text;
        //    //Attraction = note.Attraction;
        //}
    }
}
