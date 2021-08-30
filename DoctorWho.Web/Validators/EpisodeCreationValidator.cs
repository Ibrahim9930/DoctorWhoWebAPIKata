using DoctorWho.Web.Models;
using FluentValidation;

namespace DoctorWho.Web.Validators
{
    public class EpisodeCreationValidator : AbstractValidator<EpisodeForCreationWithPostDto>
    {
        public EpisodeCreationValidator()
        {
            RuleFor(dto => dto.AuthorId).NotNull();
            RuleFor(dto => dto.DoctorId).NotNull();
            
            RuleFor(dto => dto.SeriesNumber).NotNull();
            RuleFor(dto => dto.EpisodeNumber).NotNull();
            
            RuleFor(dto => dto.EpisodeNumber).GreaterThan(0);
            
            RuleFor(dto => dto.Title).Length(10,int.MaxValue);
            
        }
    }
}