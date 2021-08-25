using System.Collections.Generic;
using AutoMapper;
using DoctorWho.Db.Domain;
using DoctorWho.Db.Repositories;
using DoctorWho.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace DoctorWho.Web.Controllers
{
    [ApiController]
    [Route("api/episodes")]
    public class EpisodeController : DoctorWhoController<Episode>
    {

        public EpisodeController(EFRepository<Episode> repository, IMapper mapper) : base(repository, mapper)
        {
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<EpisodeDto>> GetEpisodes()
        {
            var episodeEntities = Repository.GetAllEntities();

            var episodes = GetRepresentation<IEnumerable<Episode>, IEnumerable<EpisodeDto>>(episodeEntities);

            return Ok(episodes);
        }


    }
}