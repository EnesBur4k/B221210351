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

        [HttpGet]
        public Doctor GetDoctorByIdWithAll(int id)
        {
            Doctor doctor = context.Doctors
                .Include(d => d.Policlinic)
                .Include(d => d.Appointments)
                .FirstOrDefault(d => d.DoctorId == id);
            return doctor;
        }
    }
}
