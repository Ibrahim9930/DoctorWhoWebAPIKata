using AutoMapper;
using DoctorWho.Db.Domain;
using DoctorWho.Web.Models;

namespace DoctorWho.Web.Profiles
{
    public class EpisodesProfile : Profile
    {
        public EpisodesProfile()
        {
            CreateMap<Episode, EpisodeDto>();
            CreateMap<EpisodeForCreationWithPostDto, Episode>();

        }
    }
}