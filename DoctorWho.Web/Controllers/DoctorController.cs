using System.Collections.Generic;
using AutoMapper;
using DoctorWho.Db.Domain;
using DoctorWho.Db.Repositories;
using DoctorWho.Web.Models;
using DoctorWho.Web.Validators;
using Microsoft.AspNetCore.Mvc;

namespace DoctorWho.Web.Controllers
{
    [ApiController]
    [Route("api/doctors")]
    public class DoctorController : Controller
    {
        private readonly EFRepository<Doctor> _repository;
        private readonly IMapper _mapper;
        private DoctorCreationValidator _doctorCreationValidator;

        public DoctorController(EFRepository<Doctor> repository, IMapper mapper,
            DoctorCreationValidator doctorCreationValidator)
        {
            _repository = repository;
            _mapper = mapper;
            _doctorCreationValidator = doctorCreationValidator;
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

        [HttpPost]
        public ActionResult<DoctorDto> CreateDoctor(DoctorForCreationWithPostDto doctorCreationWithPostDto)
        {
            var doctorExists =
                _repository.GetByProperty(doc => doc.DoctorNumber, doctorCreationWithPostDto.DoctorNumber);

            if (doctorExists != null)
            {
                return Conflict();
            }

            Doctor doctorEntity = _mapper.Map<Doctor>(doctorCreationWithPostDto);

            _repository.Add(doctorEntity);
            _repository.Commit();

            DoctorDto doctorRepresentationDto = _mapper.Map<DoctorDto>(doctorEntity);

            return CreatedAtRoute("GetDoctor",
                new {doctorNumber = doctorEntity.DoctorNumber},
                doctorRepresentationDto);
        }
    }
}