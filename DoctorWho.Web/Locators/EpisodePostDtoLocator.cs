using DoctorWho.Db.Interfaces;
using DoctorWho.Web.Models;
using DoctorWho.Web.Utils;

namespace DoctorWho.Web.Locators
{
    public class EpisodePostDtoLocator : ILocatorTranslator<EpisodeForCreationWithPostDto, string>
    {
        public string GetLocator(EpisodeForCreationWithPostDto @object)
        {
            return EpisodeLocatorUtils.GetEpisodeLocator(@object);
        }

        public void SetLocator(EpisodeForCreationWithPostDto @object, string locator)
        {
            EpisodeLocatorUtils.SetEpisodeLocator(@object, locator);
        }
    }
}