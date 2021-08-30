using AutoMapper;
using DoctorWho.Db.Domain;
using DoctorWho.Db.Repositories;
using DoctorWho.Web.Locators;
using DoctorWho.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace DoctorWho.Web.Controllers
{
    [Route("api/authors")]
    public class AuthorController : DoctorWhoController<Author, string>
    {
        public AuthorController(EFRepository<Author, string> repository, IMapper mapper,
            ILocatorTranslator<Author, string> locatorTranslator) : base(repository, mapper, locatorTranslator)
        {
        }

        [HttpPut]
        [Route("{authorName}")]
        public ActionResult<AuthorDto> UpdateAuthor(string authorName,AuthorForUpdate input)
        {
            if (!EntityExists(authorName))
            {
                return NotFound();
            }

            var authorEntity = GetEntity(authorName);
            
            UpdateAndCommit(input, authorName);

            var authorDto = GetRepresentation<Author, AuthorDto>(authorEntity);
            
            return Ok(authorDto);
        }
        
    }
}