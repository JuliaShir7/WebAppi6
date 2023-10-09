namespace WebAppi6.Models
{
	public class Individual : User
	{
		public string Name { get; set; }
		public DateOnly? Birthday { get; set; }
		public string? Email { get; set; }
		public string? Phone { get; set; }
		public Gender? Gender { get; set; }

		//public virtual IDictionary<IPreferencable, PreferenceType> Preferences { get; set; } = new Dictionary<IPreferencable, PreferenceType>();
		//public virtual Dictionary<IPreferencable, PreferenceType> CurrentChoosed { get; set; } = new Dictionary<IPreferencable, PreferenceType>();
		public virtual ICollection<Note> Notes { get; set; } = new List<Note>();
        public virtual ICollection<FoodRestriction> FoodRestrictions { get; set; } = new List<FoodRestriction>();

		//public virtual ICollection<SubCategory> PrefSubCategories { get; set; } = new List<SubCategory>();
		//public virtual ICollection<Cuisine> PrefCuisines { get; set; } = new List<Cuisine>();

		public virtual ICollection<Preference> Preferences { get; set; }=new List<Preference>();
		public virtual List<Route> Routes { get; set; } = new List<Route>();
		public virtual List<Attendance> Attendances { get; set; } = new List<Attendance>();

		public virtual CurrentRoute CurrentRoute { get; set; } = new CurrentRoute();

        public Individual() : base()
		{
			ID = base.ID;
			Login = base.Login;
			Password = base.Password;
			Role = base.Role;

		}
		public Individual(long id, string login, string password, Role role) : base(id, login, password, role)
		{
			ID = id;
			Login = login;
			Password = password;
			Role = role;
			Notes = new List<Note>();
			FoodRestrictions = new List<FoodRestriction>();

        }
		public Individual(long id, string login, string password, Role role, string name, DateOnly birthday, string email, string phone, Gender gender, List<Note> notes, List<FoodRestriction> foodRestrictions, List<Route> routes/*, Route currentRoute*/) : base(id, login, password, role)
		{
			ID = id;
			Login = login;
			Password = password;
			Role = role;
			Name = name;
			Birthday = birthday;
			Email = email;
			Phone = phone;
			Gender = gender;
			Notes = notes;
			FoodRestrictions = foodRestrictions;
			Routes = routes;
			//CurrentRoute = currentRoute;
        }

		///////////методы////////////
		//      public void Update(Individual individual)
		//{
		//	//здесь нужно будет попросить подтверждение от пользователя
		//	Login = individual.Login;
		//	Password = individual.Password;
		//	Name = individual.Name;
		//	Birthday = individual.Birthday;
		//	Email = individual.Email;
		//}
		//public void AddFoodRestriction(FoodRestriction restriction)
		//{
		//	FoodRestrictions.Add(restriction);
		//}
		//public void DeleteFoodRestriction(FoodRestriction restriction)
		//{
		//	FoodRestrictions.Remove(restriction);
		//}
		//public void AddPreference(IPreferencable preference, PreferenceType preferenceType)
		//{
		//	Preferences.Add(preference, preferenceType);
		//}
		//public void DeletePreference(IPreferencable preference)
		//{
		//	Preferences.Remove(preference);
		//}
		//public void AddCurrentPreference(IPreferencable preference, PreferenceType preferenceType)
		//{
		//	CurrentChoosed.Add(preference, preferenceType);
		//}
		//public void DeleteCurrentPreference(IPreferencable preference)
		//{
		//	CurrentChoosed.Remove(preference);
		//}
		//public void UpdateCurrentRoute(Route route)
		//{
		//	CurrentRoute = route;
		//}
	}
}
