using B221210351.EFContext;
using B221210351.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace B221210351.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsApiController : ControllerBase
    {
        private readonly HastaneDbContext context;

        public DoctorsApiController(HastaneDbContext context)
        {
            this.context = context;
        }

        [HttpGet("{id}")]
        public Doctor Get(int id)
        {
            Doctor doctor = context.Doctors.Find(id);
            return doctor;
        }

        [HttpGet]
        public List<Doctor> Get() 
        {
            List<Doctor> doctors = context.Doctors.ToList();
            return doctors;
        }

    }
}
