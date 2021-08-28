using System.Collections.Generic;
using AutoMapper;
using DoctorWho.Db.Domain;
using DoctorWho.Db.Repositories;
using DoctorWho.Web.Locators;
using DoctorWho.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace DoctorWho.Web.Controllers
{
    [ApiController]
    [Route("api/doctors")]
    public class DoctorController : DoctorWhoController<Doctor, int?>
    {
        private ILocatorTranslator<DoctorForCreationWithPostDto, int?> PostInputLocatorTranslator { get; }

        public DoctorController(EFRepository<Doctor, int?> repository, IMapper mapper,
            ILocatorTranslator<Doctor, int?> locatorTranslator,
            ILocatorTranslator<DoctorForCreationWithPostDto, int?> postInputLocatorTranslator) : base(repository,
            mapper, locatorTranslator)
        {
            PostInputLocatorTranslator = postInputLocatorTranslator;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Doctor>> GetAllResources()
        {
            var doctorEntities = Repository.GetAllEntities();

            var output = GetRepresentation<IEnumerable<Doctor>, IEnumerable<DoctorDto>>(doctorEntities);

            return Ok(output);
        }

        [HttpGet]
        [Route("{doctorNumber}", Name = "GetDoctor")]
        public ActionResult<Doctor> GetResource(int? doctorNumber)
        {
            var doctorEntity = GetEntity(doctorNumber);

            if (doctorEntity == null)
                return NotFound();

            var output = GetRepresentation<Doctor, DoctorDto>(doctorEntity);

            return Ok(output);
        }

        [HttpPost]
        public ActionResult<DoctorDto> CreateDoctor(DoctorForCreationWithPostDto input)
        {
            if (EntityExists(PostInputLocatorTranslator.GetLocator(input)))
            {
                return Conflict();
            }

            AddAndCommit(input);

            return CreatedAtRoute("GetDoctor", new {doctorNumber = PostInputLocatorTranslator.GetLocator(input)},
                GetResource(PostInputLocatorTranslator.GetLocator(input)));
        }

        [HttpPut]
        [Route("{doctorNumber}")]
        public ActionResult<DoctorDto> UpsertDoctor([FromRoute] int? doctorNumber,
            [FromBody] DoctorForUpsertWithPut input)
        {
            if (EntityExists(doctorNumber))
            {
                UpdateAndCommit(input, doctorNumber);

                return NoContent();
            }

            AddAndCommit(input, doctorNumber);

            return CreatedAtRoute("GetDoctor", new {doctorNumber},
                GetResource(doctorNumber));
        }

        [HttpDelete]
        [Route("{doctorNumber}")]
        public ActionResult DeleteResource(int? doctorNumber)
        {
            if (!EntityExists(doctorNumber))
                return NotFound();

            var doctorEntity = GetEntity(doctorNumber);

            DeleteAndCommit(doctorEntity);

            return NoContent();
        }
    }
}