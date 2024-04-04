using EnYakınSatıcı.BusinessLayer.Abstract;
using EnYakınSatıcı.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnYakınSatıcıWebApİConsume.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {



            //Swagger
            //Dependency chain --
            //IProductService productService = new ProductManager(new EfProductDal());


            Thread.Sleep(1000);

            var result = _categoryService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("add")]
        public IActionResult Add(Category category)
        {
            var result = _categoryService.Add(category);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbycategory/{id}")]
        public IActionResult GetById(int id)
        {
            var result = _categoryService.GetCategoryByProductId(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
