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
    public class DoctorController : DoctorWhoController<Doctor>
    {

        public DoctorController(EFRepository<Doctor> repository, IMapper mapper) : base(repository, mapper)
        {
        }
        private Doctor _cachedDoctor;

        [HttpGet]
        public ActionResult<IEnumerable<DoctorDto>> GetDoctors()
        {
            var doctorsEntities = Repository.GetAllEntities();

            var doctors = GetRepresentation<IEnumerable<Doctor>, IEnumerable<DoctorDto>>(doctorsEntities);

            return Ok(doctors);
        }

        [HttpGet]
        [Route("{doctorNumber}", Name = "GetDoctor")]
        public ActionResult<DoctorDto> GetDoctor(int doctorNumber)
        {
            var doctorEntity = GetDoctorEntity(doctorNumber);

            if (doctorEntity == null)
                return NotFound();

            var doctorDto = GetRepresentation<Doctor, DoctorDto>(doctorEntity);

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
                GetRepresentation<Doctor, DoctorDto>(GetDoctorEntity(doctorNumber))
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
        
        
        private bool DoctorExists(int doctorNumber)
        {
            return GetDoctorEntity(doctorNumber) != null;
        }
        
        private Doctor GetDoctorEntity(int doctorNumber)
        {
            if (_cachedDoctor == null || _cachedDoctor.DoctorNumber != doctorNumber)
            {
                _cachedDoctor = Repository.GetByProperty(doc => doc.DoctorNumber, doctorNumber);
            }

            return _cachedDoctor;
        }

        private void AddAndCommit<T>(T doctorDto, int? doctorNumber = null)
        {
            Doctor doctorEntity = Mapper.Map<Doctor>(doctorDto);

            if (doctorNumber != null)
                doctorEntity.DoctorNumber = doctorNumber.Value;
            
            Repository.Add(doctorEntity);
            Repository.Commit();

            _cachedDoctor = doctorEntity;
        }

        private void UpdateAndCommit<T>(T doctorDto, int doctorNumber)
        {
            Doctor doctorEntity = GetDoctorEntity(doctorNumber);
            Mapper.Map(doctorDto, doctorEntity);
            
            
            Repository.Update(doctorEntity);
            Repository.Commit();

            _cachedDoctor = doctorEntity;
        }
        
        private void DeleteAndCommit(Doctor doctorEntity)
        {
            Repository.Delete(doctorEntity);
            Repository.Commit();

            _cachedDoctor = null;
        }
        
    }
}