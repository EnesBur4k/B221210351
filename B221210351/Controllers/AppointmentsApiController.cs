using B221210351.EFContext;
using B221210351.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace B221210351.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsApiController : ControllerBase
    {
        private readonly HastaneDbContext context;

        public AppointmentsApiController(HastaneDbContext context)
        {
            this.context = context;
        }

        [HttpGet("{id}")]
        public Appointment Get(int? id)
        {
            Appointment data = context.Appointments.Find(id);
            return data;
        }

        [HttpGet]
        public List<Appointment> Get()
        {
            List<Appointment> data = context.Appointments.ToList();
            return data;
        }
    }
}
