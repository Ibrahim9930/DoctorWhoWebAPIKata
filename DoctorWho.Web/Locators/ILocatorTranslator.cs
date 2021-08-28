namespace DoctorWho.Web.Locators
{
    /// <summary>
    /// Used to "translate" between the domain types properties' and the locator
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TLocator"></typeparam>
    public interface ILocatorTranslator<TEntity,TLocator>
    {
        public TLocator GetLocator(TEntity @object);

        public void SetLocator(TEntity @object, TLocator locatorValue);
    }
}