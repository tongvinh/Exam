﻿using Examination.Domain.SeedWork;

namespace Examination.Domain.AggregateModels.CategoryAggregate
{
    public interface ICategoryRepository: IRepositoryBase<Category>
    {
        Task<Tuple<List<Category>, long>> GetCategoriesPagingAsync(string searchKeyword, int pageIndex, int pageSize);
        Task<Category> GetCategoriesByIdAsync(string id);
        Task<Category> GetCategoriesByNameAsync(string name);
    }
}
