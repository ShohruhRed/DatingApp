using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly DataContext _dataContext;

        public UsersController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AppUser>> GetUser()
        {
            var users = _dataContext.Users.ToList();

            return users;
        }

        // api/users/2
        [HttpGet("{id}")]
        public ActionResult<AppUser> GetUser(int id)
        {
            return _dataContext.Users.Find(id);
            
        }


    }
}
