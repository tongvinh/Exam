﻿namespace Examination.Shared.SeedWork
{
    public class PagedList<T> : PagedListBase
    {
        public List<T> Items { get; set; }
        public PagedList()
        {
        }

        public PagedList(List<T> items, long count, int pageNumber, int pageSize)
        {
            MetaData = new MetaData()
            {
                TotalCount = count,
                PageSize = pageSize,
                CurrentPage = pageNumber,
                TotalPages = (int) Math.Ceiling(count / (double) pageSize)
            };
            Items = items;
        }
    }
}
