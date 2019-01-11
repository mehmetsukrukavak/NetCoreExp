using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreExp.Models.Repository
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get;  }

        void AddCategory(Category entity);
    }
}
