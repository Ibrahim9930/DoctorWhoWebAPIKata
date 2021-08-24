using DoctorWho.Web.Models;
using FluentValidation;

namespace DoctorWho.Web.Validators
{
    public class DoctorForManipulationValidator<T> : AbstractValidator<T> where T : DoctorForManipulationDto
    {
        public DoctorForManipulationValidator()
        {
            RuleFor(doc => doc.DoctorName).NotNull().NotEmpty();

            When(doc => doc.FirstEpisodeDate == null, () =>
                {
                    RuleFor(doc => doc.LastEpisodeDate)
                        .Null();
                })
                .Otherwise(() =>
                {
                    RuleFor(doc => doc.LastEpisodeDate)
                        .GreaterThan(doc => doc.FirstEpisodeDate);
                });
        }
    }
}