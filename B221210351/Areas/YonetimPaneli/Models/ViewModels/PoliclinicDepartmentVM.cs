using B221210351.Models;

namespace B221210351.Areas.YonetimPaneli.Models.ViewModels
{
    public class PoliclinicDepartmentVM
    {
        public Policlinic Policlinic { get; set; }
        public Department Department { get; set; }
        public List<Policlinic> Policlinics { get; set; }
        public List<Department> Departments { get; set; }
    }
}
