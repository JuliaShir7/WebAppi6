namespace WebAppi6.Models
{
    public class Request
    {
        //User moderator;
        public long ID { get; set; }
        public string Property { get; set; }
        public string Value { get; set; }
        public PhaseOfConcideration PhaseOfConcideration { get; set; }
        public virtual Attraction Attraction { get; set; } 
        public virtual Individual Individual { get; set; }
        //public virtual User Moderator { get; set; }

        //public virtual User Moderator 
        //{
        //    get 
        //    { 
        //        if (moderator.Role == Role.Moderator) 
        //            return moderator; 
        //        else throw new Exception("This user do not have the authority to check requests!\nДанный пользователь не имеет полномочий для проверки запросов!");
        //    }
        //    set
        //    {
        //        if (moderator.Role == Role.Moderator)
        //            moderator = value;
        //        else throw new Exception("This user do not have the authority to check requests!\nДанный пользователь не имеет полномочий для проверки запросов!");
        //    } 
        //}
        public Request() { }
        public Request(string property, string value, PhaseOfConcideration phaseOfConcideration)
        {
            Property = property;
            Value = value;
            PhaseOfConcideration = phaseOfConcideration;
        }
        public Request(long iD, string property, string value, PhaseOfConcideration phaseOfConcideration)
        {
            ID = iD;
            Property = property;
            Value = value;
            PhaseOfConcideration = phaseOfConcideration;
        }

        //public void Update(Request request)
        //{
        //    Property = request.Property;
        //    Value= request.Value;
        //    PhaseOfConcideration = request.PhaseOfConcideration;
        //}
    }
}
