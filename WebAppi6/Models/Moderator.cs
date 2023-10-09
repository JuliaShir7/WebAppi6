namespace WebAppi6.Models
{
	public class Moderator : User
	{
		//public virtual List<Request> Requests { get; set; }= new List<Request>();
		public Moderator() : base()
		{
			this.ID = base.ID;
			this.Login = base.Login;
			this.Password = base.Password;
			this.Role = base.Role;
			Requests = base.Requests;
		}
		public Moderator(User user)
		{
			this.ID = user.ID;
			this.Login = user.Login;
			this.Password = user.Password;
			this.Role = user.Role;
			Requests = user.Requests;
		}
        public Moderator(long iD, string login, string password, Role role) : base(iD, login, password, role)
		{
			ID = iD;
			Login = login;
			Password = password;
			Role = role;
			//Requests = new List<Request>();
		}

        public Moderator(string login, string password, Role role) : base(login, password, role)
        {
            Login = login;
            Password = password;
            Role = role;
        }
    }
}
