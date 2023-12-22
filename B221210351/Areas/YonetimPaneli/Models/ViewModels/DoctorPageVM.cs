using B221210351.Models;

namespace B221210351.Areas.YonetimPaneli.Models.ViewModels
{
    public class DoctorPageVM
    {
        public Doctor Doctor { get; set; }
        public List<Doctor> Doctors { get; set; }
        public List<Policlinic> Policlinics { get; set; }
    }
}
