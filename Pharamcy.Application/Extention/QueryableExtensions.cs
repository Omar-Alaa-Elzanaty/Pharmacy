using Microsoft.EntityFrameworkCore;
using Pharamcy.Shared;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace Pharamcy.Application.Extensions
{
    public static class QueryableExtensions
    {
        public static async Task<PaginatedResponse<T>> ToPaginatedListAsync<T>(this IQueryable<T> source, int pageNumber, int pageSize, CancellationToken cancellationToken) where T : class
        {
            pageNumber = pageNumber == 0 ? 1 : pageNumber;
            pageSize = pageSize == 0 ? 10 : pageSize;
            int count = await source.CountAsync();
            pageNumber = pageNumber <= 0 ? 1 : pageNumber;
            List<T> items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);
            return PaginatedResponse<T>.Create(items, count, pageNumber, pageSize);
        }
    }
}