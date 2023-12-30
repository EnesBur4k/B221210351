using B221210351.EFContext;
using B221210351.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace B221210351.Areas.YonetimPaneli.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("yonetimPaneli")]
    public class DepartmentController : Controller
    {
        private readonly HastaneDbContext context;

        public DepartmentController(HastaneDbContext context)
        {
            this.context = context;
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
