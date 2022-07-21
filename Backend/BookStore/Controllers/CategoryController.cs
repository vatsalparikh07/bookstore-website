using BookStore.Models.Models;
using BookStore.Models.ViewModels;
using BookStore.Respositary;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : Controller
    {
        CategoryRepository _categoryRepository = new CategoryRepository();
       
        [Route("list")]
        [HttpGet]
        [ProducesResponseType(typeof(ListResponse<CategoryModel>), (int)HttpStatusCode.OK)]
        public IActionResult GetCategories(int pageIndex = 1 ,int pageSize = 10, string keyword = "")
        {
           var categories = _categoryRepository.GetCategories(pageIndex, pageSize, keyword);
            ListResponse<CategoryModel> listResponse = new ListResponse<CategoryModel>()
            {
                Results = categories.Results.Select(c => new CategoryModel(c)),
                TotalRecords = categories.TotalRecords,
            };

            return Ok(listResponse);
        }

        [Route("{id}")]
        [HttpGet]
        [ProducesResponseType(typeof(CategoryModel), (int)HttpStatusCode.OK)]
        public IActionResult GetCategory(int id)
        {         
            var category = _categoryRepository.GetCategory(id);
            CategoryModel categoryModel = new CategoryModel(category);
           
            return Ok(categoryModel);
        }

        [Route("add")]
        [HttpPost]
        [ProducesResponseType(typeof(CategoryModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), (int)HttpStatusCode.BadRequest)]
        public IActionResult AddCategory(CategoryModel model)
        {
            if (model == null)
                return BadRequest("model is null");

            Category category = new Category()
            {
                Id = model.Id,
                Name = model.Name,
            };
            var response = _categoryRepository.AddCategory(category);
            CategoryModel categoryModel = new CategoryModel(response);

            return Ok(categoryModel);
        }

        [Route("update")]
        [HttpPut]
        [ProducesResponseType(typeof(CategoryModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), (int)HttpStatusCode.BadRequest)]
        public IActionResult UpdateCategory(CategoryModel model)
        {
            if (model == null)
                return BadRequest("model is null");

            Category category = new Category()
            {
                Id = model.Id,
                Name = model.Name,
            };
            var response = _categoryRepository.UpdateCategory(category);
            CategoryModel categoryModel = new CategoryModel(response);

            return Ok(categoryModel);
        }

        [Route("delete/{id}")]
        [HttpDelete]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), (int)HttpStatusCode.BadRequest)]
        public IActionResult DeleteCategory(int id)
        {
            if (id == 0)
                return BadRequest("Id is null");
            var response = _categoryRepository.DeleteCategory(id);
            return Ok(response);
        }
    }
}
