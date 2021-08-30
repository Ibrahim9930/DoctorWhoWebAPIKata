using DoctorWho.Db.Interfaces;
using DoctorWho.Web.Models;

namespace DoctorWho.Web.Locators
{
    public class DoctorPostDtoLocator : ILocatorTranslator<DoctorForCreationWithPostDto,int?>
    {
        public int? GetLocator(DoctorForCreationWithPostDto @object)
        {
            return @object.DoctorNumber;
        }

        public void SetLocator(DoctorForCreationWithPostDto @object, int? locator)
        {
            @object.DoctorNumber = locator.GetValueOrDefault();
        }
    }
}