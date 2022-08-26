using System.Collections.Generic;
using System.Web.Http;
using TimeSheet.Core.Services;

namespace TimeSheet.Api.Controllers
{
    public class CategoryController : ApiController
    {
        public readonly ICategoryService categoryService;
        public CategoryController(ICategoryService _categoryService)
        {
            categoryService = _categoryService;
        }
        // GET: api/Category
        public IEnumerable<Core.Model.Category> Get()
        {
            return categoryService.GetAll();
        }

        // GET: api/Category/5
        public Core.Model.Category Get(int id)
        {
            return categoryService.Get(id);
        }

        // POST: api/Category
        public Core.Model.Category Post([FromBody] Core.Model.Category value)
        {
            categoryService.Add(value);
            return categoryService.Get(value.Id);
        }

        // PUT: api/Category/5
        public Core.Model.Category Put(int id, [FromBody] Core.Model.Category value)
        {
            categoryService.Update(id,value);
            return categoryService.Get(value.Id);
        }

        // DELETE: api/Category/5
        public Core.Model.Category Delete(int id)
        {
            Core.Model.Category category = Get(id);
            categoryService.Remove(category);
            return category;
        }
    }
}
