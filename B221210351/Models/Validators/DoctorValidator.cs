using FluentValidation;

namespace B221210351.Models.Validators
{
    public class DoctorValidator : AbstractValidator<Doctor>
    {
        public DoctorValidator()
        {
            RuleFor(x => x.DoctorName).NotEmpty();
            RuleFor(x => x.DoctorSurname).NotEmpty();
            RuleFor(x => x.Gender).NotEmpty();

        }
    }
}
