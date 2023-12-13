using En_YakınSatıcı.DataAccesLayer.Concrete.EntityFramework;
using EnYakınSatıcı.BusinessLayer.Abstract;
using EnYakınSatıcı.BusinessLayer.Concrete;
using EnYakınSatıcı.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnYakınSatıcıWebApİConsume.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //loosely couples gevşek bağlılık

        /// <Ioc Container--Inversion of Control
       
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
           // _productService = new ProductManager();
           //bunu verirsek bağımlı oluruz 
            _productService = productService;
      
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
           
           

            //Swagger
            //Dependency chain --
 //IProductService productService = new ProductManager(new EfProductDal());

            Thread.Sleep(1000);

            var result = _productService.GetAll();
            
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("GetAllAdmin/{id}")]
        public IActionResult GetAlladminıd(int id)
        {



            //Swagger
            //Dependency chain --
            //IProductService productService = new ProductManager(new EfProductDal());

            Thread.Sleep(1000);

            var result = _productService.GetAllByAdminId(id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

            [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("transaction")]
        public IActionResult TransactionTest(Product product)
        {
            var result = _productService.AddTransactionanTest(product);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }


    }
}
