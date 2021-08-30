using System;
using System.Linq.Expressions;

namespace DoctorWho.Db.Interfaces
{
    /// <summary>
    /// Used to get the locator comparison expression, which is used by EF Repository to execute the where
    /// statement on the data store side
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TLocator"></typeparam>
    public interface ILocatorPredicate<TEntity,TLocator>
    {
        public Expression<Func<TEntity, bool>> GetExpression(TLocator locator);
    }
}