using System.Collections.Generic;
using AutoMapper;
using DoctorWho.Db.Domain;
using DoctorWho.Db.Repositories;
using DoctorWho.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace DoctorWho.Web.Controllers
{
    [ApiController]
    [Route("api/doctors")]
    public class DoctorController : Controller
    {
        private readonly EFRepository<Doctor> _repository;
        private readonly IMapper _mapper;
        public DoctorController(EFRepository<Doctor> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<DoctorDto>> GetDoctors()
        {
            var doctorsEntities = _repository.GetAllEntities();

            var doctors = _mapper.Map<IEnumerable<DoctorDto>>(doctorsEntities);

            return Ok(doctors);
        }

        [HttpGet]
        [Route("{doctorNumber}", Name = "GetDoctor")]
        public ActionResult<DoctorDto> GetDoctor(int doctorNumber)
        {
            var doctorEntity = _repository.GetByProperty(doc => doc.DoctorNumber, doctorNumber);

            if (doctorEntity == null)
                return NotFound();

            var doctor = _mapper.Map<DoctorDto>(doctorEntity);

            return Ok(doctor);
        }
    }
}