namespace WebAppi6.Models
{
	public class Company : User
	{
		public string Name { get; set; }
		public string? Email { get; set; }
		public string? Phone { get; set; }
		public string? Address { get; set; }
		public virtual ICollection<Individual> Clients { get; set; } = new List<Individual>();
        public virtual ICollection<Attraction> Partners { get; set; } = new List<Attraction>();
        public Company() : base()
		{
			ID = base.ID;
			Login = base.Login;
			Password = base.Password;
			Role = base.Role;
		}
        public Company(long id, string login, string password, Role role):base(id, login, password, role)
        {
            ID = id;
            Login = login;
            Password = password;
            Role = role;
        }
        public Company(string login, string password, Role role) : base(login, password, role)
        {
            Login = base.Login;
            Password = base.Password;
            Role = base.Role;
        }

        public Company(string login, string password, Role role, string name, string email, string phone, string address) : base(login, password, role)
        {
            Login = base.Login;
            Password = base.Password;
            Role = base.Role;
            Name = name;
			Email = email;
			Phone = phone;
			Address = address;
		}

		///////////методы////////////
		//public void Update(Company company)
		//{
		//	//здесь нужно будет попросить подтверждение от пользователя
		//	Login = company.Login;
		//	Password = company.Password;
		//	Name = company.Name;
		//	Email = company.Email;
		//}
		//public void AddClients(List<Individual> clientsToAdd)
		//{
		//	Clients.AddRange(clientsToAdd);
		//	Clients = Clients.Distinct().ToList();
		//}
		//public void AddPartners(List<Attraction> partnersToAdd)
		//{
		//	Partners.AddRange(partnersToAdd);
		//	Partners = Partners.Distinct().ToList();
		//}
		//public void DeleteClient(Individual client)
		//{
		//	Clients.Remove(client);
		//}
		//public void DeletePartner(Attraction partner)
		//{
		//	Partners.Remove(partner);
		//}
	}
}
