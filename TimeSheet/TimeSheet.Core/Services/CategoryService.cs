using System.Collections.Generic;
using TimeSheet.Core.Repositories;
using TimeSheet.Core.Model;

namespace TimeSheet.Core.Services
{
    public class CategoryService : ICategoryService
    {
        public readonly ICategoryRepository categoryRepository;
        public CategoryService(ICategoryRepository _categoryRepository) 
        {
           categoryRepository = _categoryRepository;
        }
        public IEnumerable<Category> GetAll()
        {
            return categoryRepository.GetAll();
        }
        public Category Get(int id)
        {
            return categoryRepository.Get(id);
        }
        public void Add(Category category)
        {
           categoryRepository.Add(category);
        }
        public void Remove(Category category)
        {
             categoryRepository.Remove(category);
        }
        public void Update(int id, Category category)
        {
             categoryRepository.Update(id,category);
        }
    }
}
