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
    [Route("api/episodes")]
    public class EpisodeController : DoctorWhoController<Episode, string>
    {
        private ILocatorTranslator<EpisodeForCreationWithPostDto, string> PostInputLocatorTranslator { get; }

        public EpisodeController(EFRepository<Episode, string> repository, IMapper mapper,
            ILocatorTranslator<Episode, string> locatorTranslator,
            ILocatorTranslator<EpisodeForCreationWithPostDto, string> postInputLocatorTranslator) : base(repository,
            mapper,
            locatorTranslator)
        {
            PostInputLocatorTranslator = postInputLocatorTranslator;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Episode>> GetAllResources()
        {
            var episodeEntities = Repository.GetAllEntities();

            var output = GetRepresentation<IEnumerable<Episode>, IEnumerable<EpisodeDto>>(episodeEntities);

            return Ok(output);
        }

        [HttpGet]
        [Route("api/{episodeLocator}", Name = "GetEpisode")]
        public  ActionResult<Episode> GetResource(string episodeLocator)
        {
            var episodeEntity = GetEntity(episodeLocator);

            if (episodeEntity == null)
                return NotFound();

            var output = GetRepresentation<Episode, EpisodeDto>(episodeEntity);

            return Ok(output);
        }

        [HttpPost]
        public ActionResult<EpisodeDto> CreateEpisode(EpisodeForCreationWithPostDto input)
        {
            if (EntityExists(PostInputLocatorTranslator.GetLocator(input)))
            {
                return Conflict();
            }

            AddAndCommit(input);

            return CreatedAtRoute("GetEpisode", new {episodeLocator = PostInputLocatorTranslator.GetLocator(input)},
                GetResource(PostInputLocatorTranslator.GetLocator(input)));
        }
    }
}