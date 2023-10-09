using Microsoft.AspNetCore.Mvc;
using WebAppi6.Models.Services;
using WebAppi6.Models;

namespace WebAppi6.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly IServiceProvider service;
        public UserController( IServiceProvider service)
        {
            this.service = service;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            return service.GetService<UserService>().GetAll();
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Admin>>> GetAdmins()
        {
            return (List<Admin>)service.GetService<UserService>().GetAll(Role.Admin);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Moderator>>> GetModerators()
        {
            return (List<Moderator>)service.GetService<UserService>().GetAll(Role.Moderator);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Company>>> GetCompanies()
        {
            return (List<Company>)service.GetService<UserService>().GetAll(Role.Company);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Individual>>> GetIndividuals()
        {
            return (List<Individual>)service.GetService<UserService>().GetAll(Role.Individual);
        }
        // GET api/users/5
        //[HttpGet("{id},{role}")]
        //public async Task<ActionResult<User>> Get(long id, Role role)
        //{
        //    return service.GetService<UserService>().Get(id, role);
        //}
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(long id)
        {
            return service.GetService<UserService>().Get(id);
        }
    }
}
