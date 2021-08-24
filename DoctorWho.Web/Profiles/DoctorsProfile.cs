using System;
using AutoMapper;
using DoctorWho.Db.Domain;
using DoctorWho.Web.Models;

namespace DoctorWho.Web.Profiles
{
    public class DoctorsProfile : Profile
    {
        public DoctorsProfile()
        {
            CreateMap<Doctor, DoctorDto>();
            CreateMap<DoctorForCreationWithPostDto, Doctor>();
            CreateMap<DoctorForUpsertWithPut, Doctor>();
        }

    }
}