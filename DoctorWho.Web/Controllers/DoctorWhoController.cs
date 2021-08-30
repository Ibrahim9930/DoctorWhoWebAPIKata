using AutoMapper;
using DoctorWho.Db.Domain;
using DoctorWho.Db.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DoctorWho.Web.Controllers
{
    [ApiController]
    public class DoctorWhoController<T> : Controller where T : class
    {
        protected EFRepository<T> Repository { get; }
        protected IMapper Mapper { get; }

        public DoctorWhoController(EFRepository<T> repository, IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }
        
        public TOutput GetRepresentation<TInput, TOutput>(TInput doctorInputDto)
        {
            return Mapper.Map<TOutput>(doctorInputDto);
        }
    }
}