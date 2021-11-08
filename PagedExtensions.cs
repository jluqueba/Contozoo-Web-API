using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Contozoo
{
	public static class PagedExtensions
	{
        const int MaxPageSize = 10;
        public static async Task<PagedResponse<TModel>> PaginateAsync<TModel>(
            this IQueryable<TModel> query,
            int page,
            int limit)
            where TModel : class
        {

            var paged = new PagedResponse<TModel>();

            page = (page < 0) ? 1 : page;
            limit = (limit < 1) ? 1 : (limit > MaxPageSize) ? MaxPageSize : limit;

            paged.CurrentPage = page;
            paged.PageSize = limit;

            var totalItemsCountTask = query.CountAsync();

            var startRow = (page - 1) * limit;
            paged.Items = await query
                       .Skip(startRow)
                       .Take(limit)
                       .ToListAsync();

            paged.TotalItems = await totalItemsCountTask;
            paged.TotalPages = (int)Math.Ceiling(paged.TotalItems / (double)limit);

            return paged;
        }
    }
}
