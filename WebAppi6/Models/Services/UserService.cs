using Microsoft.AspNetCore.Builder.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace WebAppi6.Models.Services
{
    public class UserService
    {
        ApplicationContext context;
        readonly IServiceProvider service;
        public UserService(IServiceProvider service, ApplicationContext context)
        {
            this.service = service;
            this.context = context;
        }
        public List<User> GetAll() => service.GetService<ApplicationContext>().Users.ToList();
        

        List<Admin> GetAdmins()
        {
            List<Admin> admins=new List<Admin>();
            var users = service.GetService<ApplicationContext>().Users.Where(u => u.Role == Role.Admin).ToList();
            foreach ( var user in users )
            {
                admins.Add(new Admin(user));
            }
            //admins=(List<Admin>)users.Where(u=>u.Role==Role.Admin).ToList();
            return admins;
        }
        List<Moderator> GetModerators()
        {
            List<Moderator> moderators = new List<Moderator>();
            
            var users = service.GetService<ApplicationContext>().Users.Where(u => u.Role == Role.Moderator).ToList();
           
            var req = service.GetService<ApplicationContext>().Requests.ToList();

            //var employees = from u in users
            //                join r in req on u.ID equals r.Moderator.ID
            //                select new Moderator{ ID=u.ID, Login=u.Login, Name = p.Name, Company = c.Title, Language = c.Language };

            //var selectedPeople = req.SelectMany(r => r.Moderator,
            //                (u, l) => new { User = u, Request = l })
            //              .Where(u => u.ID == r && u.Person.Age < 28)
            //              .Select(u => u.Person);
            //var employeeOptions = service.GetService<ApplicationContext>().Requests.SelectMany(r => users.Where(u => u.ID == r.Moderator.ID)).ToList();
            foreach (var user in users)
            {
                Moderator m = new Moderator(user);
                //m.Requests = service.GetService<ApplicationContext>().Requests.Where(r => r.Moderator.ID == user.ID).ToList();
                moderators.Add(m);
            }
            //admins=(List<Admin>)users.Where(u=>u.Role==Role.Admin).ToList();
            return moderators;
        }
        public IList GetAll(Role role)
        {
            switch (role)
            {
                case Role.Admin: { return GetAdmins(); }
                case Role.Moderator: { return GetModerators(); }
                case Role.Company: { return service.GetService<ApplicationContext>().Companies.ToList(); }
                case Role.Individual: {
                        Console.WriteLine(service.GetService<ApplicationContext>().Individuals.ToList()[3].Login);
                        return service.GetService<ApplicationContext>().Individuals.ToList(); }
            }
            return GetAll();
        }
        public User Get(long id, Role role)
        {
            switch (role)
            {
                
                case Role.Company: { 
                        return service.GetService<ApplicationContext>().Companies.ToList().Find(u => u.ID == id); 
                    }
                case Role.Individual:{ return service.GetService<ApplicationContext>().Individuals.ToList().Find(u => u.ID == id); }
            }

            return service.GetService<ApplicationContext>().Users.ToList().Find(u => u.ID == id);
                        
        }
        public User Get(long id)
        {
            //switch (role)
            //{

            //    case Role.Company: { return service.GetService<ApplicationContext>().Companies.ToList().Find(u => u.ID == id); }
            //    case Role.Individual: { return service.GetService<ApplicationContext>().Individuals.ToList().Find(u => u.ID == id); }
            //}
            var u = service.GetService<ApplicationContext>().Users.ToList().Find(u => u.ID == id);
            if (u.Role == Role.Individual)
                return service.GetService<ApplicationContext>().Individuals.ToList().Find(i => i.ID==id);
            if (u.Role == Role.Company)
                return service.GetService<ApplicationContext>().Companies.ToList().Find(c => c.ID == id);

            return u;

        }
        //[HttpGet("{id}")]
        //public async Task<ActionResult<User>> GetAdmin(long id)
        //{
        //    return service.GetService<ApplicationContext>().Users.ToList().Find(u => u.ID == id);
        //}
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Individual>> GetIndividual(long id)
        //{
        //    try
        //    {
        //        Individual ind = service.GetService<ApplicationContext>().Individuals.ToList().Find(u => u.ID == id);
        //        return ind;
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Company>> GetCompany(long id)
        //{
        //    try
        //    {
        //        Company comp = service.GetService<ApplicationContext>().Companies.ToList().Find(u => u.ID == id);
        //        return comp;
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}
        //Moderator GetModerator(long id)
        //{
        //    try
        //    {
        //        Moderator m = (Moderator)service.GetService<ApplicationContext>().Users.ToList().Find(u => u.ID == id);
        //        return m;
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}
        //public void Add(User user)
        //{
        //    try
        //    {
        //        ////проверка на наличие в таблице users
        //        if (CheckDublicates(user))
        //        {
        //            service.GetService<DataBaseService>().AddUser(user, out long id);
        //            user.ID = id;
        //            Users.Add(user);
        //        }
        //        else throw new DublicateUserException(user);
        //    }
        //    catch
        //    {
        //        Console.WriteLine("Error, Sorry(");
        //    }
        //}
    }
}
