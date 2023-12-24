using B221210351.Areas.YonetimPaneli.Models.ViewModels;
using B221210351.EFContext;
using B221210351.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

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
        public IActionResult Login(Admin admin)
        {
            if (context.Admins.Any(a => a.UserName == admin.UserName))
            {
                Admin userControl = context.Admins.FirstOrDefault(p => p.UserName == admin.UserName);

                if (userControl.Password == admin.Password)
                    return RedirectToAction("Dashboard");
            }
            TempData["hataMesaji"] = "Lütfen Bilgileri Doğru Giriniz";
            return View();
        }

        public IActionResult Dashboard()
        {
            List<AppUser> patients = context.Patients.ToList();
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
            List<AppUser> patients = context.Patients.ToList();
            return View(patients);
        }
        public IActionResult Appointments()
        {
            List<Appointment> appointments = context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .Include(a => a.Policlinic).ToList();
            return View(appointments);
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
