using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contozoo
{
    public class PagedResponse<TModel> : ILinkedResource
    {
        const int MaxPageSize = 10;
        private int _pageSize;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        public int CurrentPage { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public IList<TModel> Items { get; set; }
        public IDictionary<LinkedResourceType, LinkedResource> Links { get; set; }

        public PagedResponse()
        {
            Items = new List<TModel>();
        }
    }
}
