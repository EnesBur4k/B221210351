using B221210351.EFContext;
using B221210351.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace B221210351.Controllers
{
    public class Appointment : Controller
    {
        HastaneContext context = new HastaneContext();
        public IActionResult Index()
        {
            var poliklist = context.Policlinics.ToList();
            //new AppointmentViewModel() { 
            //    Policlinics = context.Policlinics.ToList(),

            //};
            AppointmentViewModel model;
            return View();
        }
    }
}
