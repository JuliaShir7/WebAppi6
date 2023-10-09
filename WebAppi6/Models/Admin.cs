namespace WebAppi6.Models
{
	public class Admin : User
	{
		public Admin() : base()
		{
			ID = base.ID;
			Login = base.Login;
			Password = base.Password;
			Role = base.Role;
		}
        public Admin(User user) : base(user.Login, user.Password, user.Role)
        {
            Login = user.Login;
            Password = user.Password;
            Role = user.Role;
        }
        public Admin(long id, string login, string password, Role role):base(id, login, password, role)
        {
            ID = id;
            Login = login;
            Password = password;
            Role = role;
        }
        public Admin(string login, string password, Role role) : base(login, password, role)
        {
            Login = login;
            Password = password;
            Role = role;
        }
        //public override void Update(User user)
        //{
        //	//здесь нужно будет попросить подтверждение от пользователя
        //	Login = user.Login;
        //	Password = user.Password;
        //	Role = user.Role;
        //}
    }
}