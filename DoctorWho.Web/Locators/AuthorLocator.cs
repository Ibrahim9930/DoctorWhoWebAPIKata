using System;
using System.Linq.Expressions;
using DoctorWho.Db.Domain;
using DoctorWho.Db.Interfaces;

namespace DoctorWho.Web.Locators
{
    public class AuthorLocator : ILocatorTranslator<Author,string>,ILocatorPredicate<Author,string>
    {
        public string GetLocator(Author @object)
        {
            return Uri.EscapeDataString(@object.AuthorName);
        }

        public void SetLocator(Author @object, string locatorValue)
        {
            string authorName = Uri.UnescapeDataString(locatorValue);
            @object.AuthorName = authorName;
        }

        public Expression<Func<Author, bool>> GetExpression(string locator)
        {
            string authorName = Uri.UnescapeDataString(locator);
            return auth => auth.AuthorName == authorName;
        }
    }
}