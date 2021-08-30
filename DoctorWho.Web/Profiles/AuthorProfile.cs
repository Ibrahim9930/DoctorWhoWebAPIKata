using AutoMapper;
using DoctorWho.Db.Domain;
using DoctorWho.Web.Models;

namespace DoctorWho.Web.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<AuthorForUpdate, Author>();
        }
    }
}