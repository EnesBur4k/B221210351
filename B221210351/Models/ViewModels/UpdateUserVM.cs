namespace B221210351.Models.ViewModels
{
    public class UpdateUserVM
    {
        public string PatientName { get; set; }
        public string PatientSurname { get; set; }
        public string Email { get; set; }
        public bool PatientGender { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime PatientBirthDay { get; set; }
    }
}
