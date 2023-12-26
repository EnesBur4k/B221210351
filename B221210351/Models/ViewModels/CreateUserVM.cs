using System.ComponentModel.DataAnnotations;

namespace B221210351.Models.ViewModels
{
    public class CreateUserVM
    {
        [Required(ErrorMessage = "Lütfen adınızı giriniz...")]
        [Display(Name = "Hasta Adı")]
        public string PatientName { get; set; }

        [Required(ErrorMessage = "Lütfen soyadınızı giriniz...")]
        [Display(Name = "Hasta Soyadı")]
        public string PatientSurname { get; set; }

        [Required(ErrorMessage = "Lütfen kullanıcı adınızı giriniz...")]
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }
        [Display(Name = "Hasta Adresi")]
        public Address? PatientAddress { get; set; }

        [Required(ErrorMessage = "Lütfen email adresinizi giriniz...")]
        [EmailAddress(ErrorMessage = "Lütfen email formatında bir değer belirtiniz...")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lütfen şifreyi giriniz...")]
        [DataType(DataType.Password, ErrorMessage = "Lütfen şifreyi tüm kuralları göz önüne alarak giriniz...")]
        [Display(Name = "Şifre")]
        public string Password { get; set; }
    }
}
