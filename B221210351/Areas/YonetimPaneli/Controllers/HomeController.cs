using B221210351.Areas.YonetimPaneli.Models.ViewModels;
using B221210351.EFContext;
using B221210351.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace B221210351.Areas.YonetimPaneli.Controllers
{
    [Area("yonetimPaneli")]
    public class HomeController : Controller
    {
        HastaneContext context = new HastaneContext();
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            if (context.Users.Any(u => u.UserName == user.UserName))
            {
                User userControl = context.Users.FirstOrDefault(u => u.UserName == user.UserName);

                if (userControl.Password == user.Password && userControl.isAdmin)
                    return RedirectToAction("Dashboard");
            }
            TempData["hataMesaji"] = "Lütfen Bilgileri Doğru Giriniz";
            return View();
        }

        public IActionResult Dashboard()
        {
            List<User> users = context.Users.ToList();
            List<Doctor> doctors = context.Doctors.ToList();
            List<Policlinic> policlinics = context.Policlinics.ToList();
            List<Department> departments = context.Departments.ToList();

            AppDatasForAdminVM appData = new()
            {
                Users = users,
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
            return View();
        }

        public IActionResult Departments()
        {
            return View();
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

        public IActionResult addPoliclinic()
        {
            return View();
        }

        public IActionResult addDepartment()
        {
            return View();
        }
    }
}
