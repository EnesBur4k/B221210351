using B221210351.Areas.YonetimPaneli.Models.ViewModels;
using B221210351.EFContext;
using B221210351.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace B221210351.Areas.YonetimPaneli.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("yonetimPaneli")]
    public class PoliclinicController : Controller
    {
        private readonly HastaneDbContext context;

        public PoliclinicController(HastaneDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            PoliclinicDepartmentVM policlinicDepartmentVm = new()
            {
                Policlinics = context.Policlinics.Include(p => p.Department).ToList(),
                Departments = context.Departments.ToList()
            };
            return View(policlinicDepartmentVm);
        }

        public async Task<IActionResult> addPoliclinicAsync(Policlinic policlinic)
        {
            var department = context.Departments.Find(policlinic.DepartmentId);
            policlinic.Department = department;
            await context.Policlinics.AddAsync(policlinic);
            context.SaveChanges();
            TempData["AddMessage"] = "Anabilim Dalı başarıyla eklendi";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> addDepartmentAsync(Department department)
        {
            await context.Departments.AddAsync(department);
            context.SaveChanges();
            TempData["AddMessage"] = "Anabilim Dalı başarıyla eklendi";
            return RedirectToAction("Index");
        }
    }
}
