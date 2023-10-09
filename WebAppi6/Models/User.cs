namespace WebAppi6.Models
{
    public class User
    {
        public long ID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public virtual List<Request>? Requests { get; set; } 
        //public ICollection<Request> Requests { get; set;}=new List<Request>();
        public User() { }

        public User(long id, string login, string password, Role role)
        {
            ID = id;
            Login = login;
            Password = password;
            Role = role;
        }
        public User(string login, string password, Role role)
        {
            Login = login;
            Password = password;
            Role = role;
        }
    }
}
