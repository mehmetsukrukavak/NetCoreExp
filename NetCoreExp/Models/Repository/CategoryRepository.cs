using System.Collections.Generic;

namespace NetCoreExp.Models.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private List<Category> categories = new List<Category>()
        {
            new Category(){ CategoryId=1, CategoryName="Bilgisayar"},
            new Category(){ CategoryId=2, CategoryName="Telefon"},
            new Category(){ CategoryId=3, CategoryName="Tablet"}
        };

        public IEnumerable<Category> Categories => categories;

        public void AddCategory(Category entity)
        {
            categories.Add(entity);
        }

    }
}
