using AutoMapper;
using DoctorWho.Db.Domain;
using DoctorWho.Web.Models;

namespace DoctorWho.Web.Profiles
{
    public class EnemyProfile : Profile
    {
        public EnemyProfile()
        {
            CreateMap<EnemyForCreationDto, Enemy>();
        }
    }
}