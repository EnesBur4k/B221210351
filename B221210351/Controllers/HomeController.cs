using B221210351.EFContext;
using B221210351.Models;
using B221210351.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;

namespace B221210351.Controllers
{
    [Authorize(Roles = "User")]
    public class HomeController : Controller
    {
        private readonly HastaneDbContext context;
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public HomeController(HastaneDbContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.context = context;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            List<Doctor> doctorList = context.Doctors
                .Include(d => d.Appointments)
                .Include(d => d.Policlinic)
                .ToList();
            List<Appointment> appointmentList = new List<Appointment>();
            DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0);
            int dtCheck = DateTime.Now.DayOfYear;

            var firstAppointmentDate = context.Appointments.Select(a => a.AppointmentDate).FirstOrDefault();
            if (!firstAppointmentDate.DayOfYear.Equals(dtCheck))
            {
                List<Appointment> deletedAppointments = context.Appointments
                    .Where(a => a.AppointmentDate.DayOfYear < dtCheck).ToList();
                context.Appointments.RemoveRange(deletedAppointments);

            }
            Appointment tempAppointment;
            foreach (var doctor in doctorList)
            {
                for (int j = 0; j < 7; j++)
                {
                    for (int i = 0; i < 36; i++)
                    {
                        tempAppointment = new Appointment
                        {
                            Doctor = context.Doctors.Find(doctor.DoctorId),
                            Policlinic = context.Policlinics.Find(doctor.Policlinic.PoliclinicId),
                            AppointmentDate = dt.AddDays(j).AddMinutes(i * 15)
                        };

                        bool isDateEnable = !context.Appointments.Where(a => (a.AppointmentDate == tempAppointment.AppointmentDate) && (a.Doctor == tempAppointment.Doctor)).Any();
                        int weekOfDay = (int)tempAppointment.AppointmentDate.DayOfWeek;

                        if (isDateEnable && ((weekOfDay != 5) && (weekOfDay != 6)))
                        {
                            context.Appointments.Add(tempAppointment);
                        }
                    }
                }
            }
            context.SaveChanges();
            return View();
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginUserVM model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(user, model.Password, model.Persistent, model.Lock);

                    if (result.Succeeded)
                    {
                        TempData["UserId"] = user.Id;
                        return RedirectToAction("Index", "Appointment");
                    }
                }
                else
                {
                    ModelState.AddModelError("NotUser", "Böyle bir kullanıcı bulunmamaktadır.");
                    ModelState.AddModelError("NotUser2", "E-posta veya şifre yanlış.");
                }
            }
            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(CreateUserVM appUserViewModel)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser
                {
                    PatientName = appUserViewModel.PatientName,
                    PatientSurname = appUserViewModel.PatientSurname,
                    UserName = appUserViewModel.UserName,
                    Email = appUserViewModel.Email,
                    PatientBirthDay = DateTime.Now,
                    Address = await context.Addresses.FindAsync(1)
                };
                IdentityResult result = await userManager.CreateAsync(appUser, appUserViewModel.Password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(appUser, "User");
                    return RedirectToAction("Index");
                }
                else
                    result.Errors.ToList().ForEach(e => ModelState.AddModelError(e.Code, e.Description));
            }
            return View();
        }
    }
}
