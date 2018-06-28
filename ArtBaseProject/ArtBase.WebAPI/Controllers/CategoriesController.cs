using ArtBase.Contracts.DTOs;
using ArtBase.Interfaces;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace ArtBase.WebAPI.Controllers
{
    [Authorize]
    public class CategoriesController : ApiController
    {
        private readonly ICategoryManager _categoryManager;

        public CategoriesController(ICategoryManager categoryManager) => _categoryManager = categoryManager;

        [Route("api/GetAllCategories")]
        [HttpGet]
        public IEnumerable<CategoryDTO> GetCategories()
        {
            return _categoryManager.GetAll();
        }

        [ResponseType(typeof(CategoryDTO))]
        [Route("api/GetCategory/{Id}")]
        [HttpGet]
        public IHttpActionResult GetCategory(int Id)
        {
            CategoryDTO category = _categoryManager.GetById(Id);

            if (category != null)
            {
                return Ok(category);
            }
            return NotFound();
        }

        [ResponseType(typeof(CategoryDTO))]
        [Route("api/AddCategory", Name = "CategoryAdded")]
        [HttpPost]
        public IHttpActionResult AddCategory(CategoryDTO category)
        {
            if (category != null)
            {
                CategoryDTO categoryDTO = _categoryManager.Add(category);

                if (categoryDTO == null)
                {
                    return BadRequest(ModelState);
                }

                return CreatedAtRoute("CategoryAdded", new { id = categoryDTO.Id }, categoryDTO);
            }

            return BadRequest(ModelState);
        }

        [ResponseType(typeof(CategoryDTO))]
        [Route("api/DeleteCategory/{Id}")]
        [HttpDelete]
        public IHttpActionResult DeleteCategory(int Id)
        {
            bool check = _categoryManager.Delete(Id);

            if (!check)
            {
                return Ok(check);
            }

            return NotFound();
        }

        [ResponseType(typeof(void))]
        [Route("api/UpdateCategory")]
        [HttpPut]
        public IHttpActionResult UpdateCategory(CategoryDTO category)
        {
            if (category == null)
            {
                return BadRequest();
            }

            CategoryDTO categoryDTO = _categoryManager.Update(category);

            if (categoryDTO != null)
            {
                return Ok(categoryDTO);
            }

            return BadRequest();
        }

    }
}