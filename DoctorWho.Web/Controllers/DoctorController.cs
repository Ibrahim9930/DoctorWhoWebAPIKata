using System.Collections.Generic;
using AutoMapper;
using DoctorWho.Db.Domain;
using DoctorWho.Db.Repositories;
using DoctorWho.Web.Models;
using DoctorWho.Web.Profiles;
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

        private Doctor _cachedDoctor;
        public DoctorController(EFRepository<Doctor> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<DoctorDto>> GetDoctors()
        {
            var doctorsEntities = _repository.GetAllEntities();

            var doctors = GetDoctorRepresentation<IEnumerable<Doctor>, IEnumerable<DoctorDto>>(doctorsEntities);

            return Ok(doctors);
        }

        [HttpGet]
        [Route("{doctorNumber}", Name = "GetDoctor")]
        public ActionResult<DoctorDto> GetDoctor(int doctorNumber)
        {
            var doctorEntity = GetDoctorEntity(doctorNumber);

            if (doctorEntity == null)
                return NotFound();

            var doctorDto = GetDoctorRepresentation<Doctor, DoctorDto>(doctorEntity);

            return Ok(doctorDto);
        }

        [HttpPost]
        public ActionResult<DoctorDto> CreateDoctor(DoctorForCreationWithPostDto doctorCreationWithPostDto)
        {
            if (DoctorExists(doctorCreationWithPostDto.DoctorNumber))
            {
                return Conflict();
            }

            AddAndCommit(doctorCreationWithPostDto);

            return CreatedAtRoute("GetDoctor",
                new {doctorNumber = doctorCreationWithPostDto.DoctorNumber},
                GetDoctorEntity(doctorCreationWithPostDto.DoctorNumber)
            );
        }

        [HttpPut]
        [Route("{doctorNumber}")]
        public ActionResult<DoctorDto> UpsertDoctor([FromRoute] int doctorNumber,
            [FromBody] DoctorForUpsertWithPut doctorUpsertWithPutDto)
        {
            if (DoctorExists(doctorNumber))
            {
                UpdateAndCommit(doctorUpsertWithPutDto, doctorNumber);

                return NoContent();
            }

            AddAndCommit(doctorUpsertWithPutDto,doctorNumber);

            return CreatedAtRoute("GetDoctor",
                new {doctorNumber},
                GetDoctorRepresentation<Doctor, DoctorDto>(GetDoctorEntity(doctorNumber))
            );
        }
        
        [HttpDelete]
        [Route("{doctorNumber}")]
        public ActionResult DeleteDoctor(int doctorNumber)
        {
            if (!DoctorExists(doctorNumber))
                return NotFound();

            var doctor = GetDoctorEntity(doctorNumber);

            DeleteAndCommit(doctor);

            return NoContent();
        }
        
        private TOutput GetDoctorRepresentation<TInput, TOutput>(TInput doctorInputDto)
        {
            return _mapper.Map<TOutput>(doctorInputDto);
        }

        private bool DoctorExists(int doctorNumber)
        {
            return GetDoctorEntity(doctorNumber) != null;
        }
        
        private Doctor GetDoctorEntity(int doctorNumber)
        {
            if (_cachedDoctor == null || _cachedDoctor.DoctorNumber != doctorNumber)
            {
                _cachedDoctor = _repository.GetByProperty(doc => doc.DoctorNumber, doctorNumber);
            }

            return _cachedDoctor;
        }

        private void AddAndCommit<T>(T doctorDto, int? doctorNumber = null)
        {
            Doctor doctorEntity = _mapper.Map<Doctor>(doctorDto);

            if (doctorNumber != null)
                doctorEntity.DoctorNumber = doctorNumber.Value;
            
            _repository.Add(doctorEntity);
            _repository.Commit();

            _cachedDoctor = doctorEntity;
        }

        private void UpdateAndCommit<T>(T doctorDto, int doctorNumber)
        {
            Doctor doctorEntity = GetDoctorEntity(doctorNumber);
            _mapper.Map(doctorDto, doctorEntity);
            
            
            _repository.Update(doctorEntity);
            _repository.Commit();

            _cachedDoctor = doctorEntity;
        }
        
        private void DeleteAndCommit(Doctor doctorEntity)
        {
            _repository.Delete(doctorEntity);
            _repository.Commit();

            _cachedDoctor = null;
        }

    }
}