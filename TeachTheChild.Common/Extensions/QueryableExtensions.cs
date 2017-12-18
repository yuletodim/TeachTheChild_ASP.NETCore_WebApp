namespace TeachTheChild.Common.Extensions
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public static class QueryableExtensions
    {
        public static IQueryable<T> OrderByField<T>(this IQueryable<T> query, string sortField, string order)
        {
            var param = Expression.Parameter(typeof(T), "p");
            var prop = Expression.Property(param, sortField);
            var exp = Expression.Lambda(prop, param);
            string method = order == GlobalConstants.AscOrder ? GlobalConstants.OrderBy : GlobalConstants.OrderByDescending;
            Type[] types = new Type[] { query.ElementType, exp.Body.Type };
            var mce = Expression.Call(typeof(Queryable), method, types, query.Expression, exp);

            return query.Provider.CreateQuery<T>(mce);
        }
    }
}
