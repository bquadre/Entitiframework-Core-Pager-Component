using PagerComponent.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PagerComponent.Models
{
    public static class PagerExtension
    {
        public static PagerResult<T> GetPaged<T>(this IQueryable<T> query,
                                                int page, int pageSize) where T : class
        {
            var result = new PagerResult<T>();
            result.CurrentPage = page;
            result.PageSize = pageSize;
            result.RowCount = query.Count();

            var pageCount = (double)result.RowCount / pageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);

            var skip = (page - 1) * pageSize;
            result.Results = query.Skip(skip).Take(pageSize).ToList();

            return result;
        }
    }
}
