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

        [Required(ErrorMessage = "Lütfen TC Kimlik numaranızı giriniz...")]
        [StringLength(11, MinimumLength = 11,
            ErrorMessage = "TC Kimlik numarası 11 karakterli olmalı.")]
        [Display(Name = "TC Kimlik No")]
        public string PatientPersonalId { get; set; }

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
