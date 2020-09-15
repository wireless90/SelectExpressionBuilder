using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;

namespace SelectExpressionBuilder.Core
{
    public static class SelectExtensions
    {
        public static IQueryable ProjectToDynamic<T>(this IQueryable<T> queryable, IEnumerable<string> propertyIds)
            where T : class
        {
            Node root = new Node();

            foreach (string propertyId in propertyIds)
            {
                root.Add(propertyId);
            }

            IncludeQueryBuilder includeQueryBuilder = new IncludeQueryBuilder();
            List<string> includes = includeQueryBuilder.Build(root).ToList();
            includes.ForEach(include =>
            {
                queryable = queryable.Include(include);
            });

            SelectQueryBuilder selectQueryBuilder = new SelectQueryBuilder();

            string selectQuery = selectQueryBuilder.Build(root);

            return queryable.Select(selectQuery);
        }
    }
}
