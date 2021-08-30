using DoctorWho.Web.Models;
using FluentValidation;

namespace DoctorWho.Web.Validators
{
    public class DoctorCreationValidator : AbstractValidator<DoctorForCreationWithPostDto>
    {
        public DoctorCreationValidator()
        {
            RuleFor(doc => doc.DoctorName).NotNull().NotEmpty();
            RuleFor(doc => doc.DoctorNumber).NotNull().NotEmpty();

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