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
        public ActionResult UpdateAuthor(string authorName,AuthorForUpdate input)
        {
            if (!EntityExists(authorName))
            {
                return NotFound();
            }

            UpdateAndCommit(input, authorName);

            return NoContent();
        }
        
    }
}