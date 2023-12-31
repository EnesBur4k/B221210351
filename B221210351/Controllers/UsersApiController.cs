using B221210351.EFContext;
using B221210351.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace B221210351.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersApiController : ControllerBase
    {
        private readonly HastaneDbContext context;

        public UsersApiController(HastaneDbContext context)
        {
            this.context = context;
        }

        [HttpGet("{id}")]
        public AppUser Get(int id)
        {
            AppUser data = context.Users.Find(id);
            return data;
        }

        [HttpGet]
        public List<AppUser> Get()
        {
            List<AppUser> data = context.Users.ToList();
            return data;
        }
    }
}
