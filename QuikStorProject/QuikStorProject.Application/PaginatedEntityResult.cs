using System.Collections.Generic;
using Abp.Dependency;
using Abp.ObjectMapping;

namespace QuikStorProject
{
    public class PaginatedResult<T>
    {
        public int Pages { get; set; }
        public int Page { get; set; }
        public int Rows { get; set; }
        public int PerPage { get; set; }
        public List<T> Items { get; set; }


        public PaginatedResult(int pages, int page, int RowCount, int perPage, List<T> Items)
        {
            this.Pages = pages;
            this.Page = page;
            this.Rows = RowCount;
            this.PerPage = perPage;
            this.Items = Items;
        }

    }

    public class PaginatedEntityResult<E>
    {
        public List<E> Result { get; protected set; }
        public int Pages { get; protected set; }
        public int Page { get; protected set; }
        public int RowCount { get; protected set; }
        public int PerPage { get; protected set; }
        private IObjectMapper ObjectMapper { get; set; }

        public PaginatedEntityResult(int pages, int page, int RowCount, int perPage, List<E> result)
        {
            this.Pages = pages;
            this.Page = page;
            this.RowCount = RowCount;
            this.PerPage = perPage;
            this.Result = result;
            this.ObjectMapper = IocManager.Instance.Resolve<IObjectMapper>();
        }

        public PaginatedEntityResult()
        {
            this.ObjectMapper = IocManager.Instance.Resolve<IObjectMapper>();
        }

        public PaginatedResult<T> toTransferable<T>()
        {
            return new PaginatedResult<T>(this.Pages, page: this.Page,
                RowCount: this.RowCount,
                perPage: this.PerPage,
                this.ObjectMapper.Map<List<T>>(this.Result));
        }
    }
}