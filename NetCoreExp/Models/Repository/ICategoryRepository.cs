using System.Collections.Generic;

namespace NetCoreExp.Models.Repository
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }

        void AddCategory(Category entity);
    }
}
