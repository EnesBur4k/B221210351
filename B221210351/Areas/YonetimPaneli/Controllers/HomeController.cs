using B221210351.Areas.YonetimPaneli.Models.ViewModels;
using B221210351.EFContext;
using B221210351.Models;
using B221210351.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace B221210351.Areas.YonetimPaneli.Controllers
{
    [Authorize(Roles ="Admin")]
    [Area("yonetimPaneli")]
    public class HomeController : Controller
    {
        private readonly HastaneDbContext context;
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly RoleManager<AppRole> roleManager;

        public HomeController(HastaneDbContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager)
        {
            this.context = context;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
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
                        return RedirectToAction("Dashboard");
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

        public IActionResult Dashboard()
        {
            List<AppUser> patients = context.Users.ToList();
            List<Doctor> doctors = context.Doctors.ToList();
            List<Policlinic> policlinics = context.Policlinics.ToList();
            List<Department> departments = context.Departments.ToList();

            AppDatasForAdminVM appData = new()
            {
                Patients = patients,
                Doctors = doctors,
                Departments = departments,
                Policlinics = policlinics
            };
            return View(appData);
        }
        public IActionResult Doctors()
        {
            DoctorPageVM doctorPageVM = new()
            {
                Doctors = context.Doctors.Include(d => d.Policlinic.Department).ToList(),
                Policlinics = context.Policlinics.ToList()
            };
            return View(doctorPageVM);
        }

        public IActionResult Policlinics()
        {
            PoliclinicDepartmentVM policlinicDepartmentVm = new()
            {
                Policlinics = context.Policlinics.Include(p => p.Department).ToList(),
                Departments = context.Departments.ToList()
            };
            return View(policlinicDepartmentVm);
        }
        public IActionResult Patients()
        {
            List<AppUser> patients = context.Users.ToList();
            return View(patients);
        }
        public IActionResult Appointments()
        {
            List<Appointment> appointments = context.Appointments
                .Include(a => a.AppUser)
                .Include(a => a.Doctor)
                .Include(a => a.Policlinic).ToList();
            return View(appointments);
        }

        public IActionResult Roles()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> addRole(CreateRoleVM model)
        {
            IdentityResult result = await roleManager.CreateAsync(new AppRole { Name = model.Name });
            if (result.Succeeded)
            {
                //Başarılı...
            }
            return RedirectToAction("Dashboard");
        }

        [HttpPost]
        public async Task<IActionResult> addDoctorAsync(Doctor doctor)
        {
            var policlinic = context.Policlinics.Find(doctor.PoliclinicId);
            doctor.Policlinic = policlinic;
            await context.Doctors.AddAsync(doctor);
            context.SaveChanges();
            TempData["AddMessage"] = "Doktor başarıyla eklendi";
            return RedirectToAction("Doctors");
        }

        public async Task<IActionResult> addPoliclinicAsync(Policlinic policlinic)
        {
            var department = context.Departments.Find(policlinic.DepartmentId);
            policlinic.Department = department;
            await context.Policlinics.AddAsync(policlinic);
            context.SaveChanges();
            TempData["AddMessage"] = "Anabilim Dalı başarıyla eklendi";
            return RedirectToAction("Policlinics");
        }

        public async Task<IActionResult> addDepartmentAsync(Department department)
        {
            await context.Departments.AddAsync(department);
            context.SaveChanges();
            TempData["AddMessage"] = "Anabilim Dalı başarıyla eklendi";
            return RedirectToAction("Policlinics");
        }
    }
}
