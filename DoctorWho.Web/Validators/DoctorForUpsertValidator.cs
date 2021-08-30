using DoctorWho.Web.Models;
using FluentValidation;

namespace DoctorWho.Web.Validators
{
    public class DoctorForUpsertValidator : AbstractValidator<DoctorForUpsertWithPut>
    {
        public DoctorForUpsertValidator()
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