using AutoMapper;
using DoctorWho.Db.Domain;
using DoctorWho.Web.Models;

namespace DoctorWho.Web.Profiles
{
    public class CompanionProfile : Profile
    {
        public CompanionProfile()
        {
            CreateMap<CompanionForCreationDto, Companion>();
        }
    }
}