using DoctorWho.Web.Models;
using FluentValidation;

namespace DoctorWho.Web.Validators
{
    public class DoctorCreationValidator : DoctorForManipulationValidator<DoctorForCreationWithPostDto>
    {
        public DoctorCreationValidator()
        {
            RuleFor(doc => doc.DoctorNumber).NotNull().NotEmpty();
        }
    }
}