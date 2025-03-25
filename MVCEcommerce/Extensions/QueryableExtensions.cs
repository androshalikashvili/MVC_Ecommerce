using Microsoft.EntityFrameworkCore;

namespace MVCEcommerce.Extensions;

public static class QueryableExtensions
{
    public static IQueryable<T> IncludeProperties<T>(this IQueryable<T> query, string? includeProperties) where T : class
    {
        if (!string.IsNullOrEmpty(includeProperties))
        {
            foreach (var includeProperty in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
        }
        return query;
    }
}
