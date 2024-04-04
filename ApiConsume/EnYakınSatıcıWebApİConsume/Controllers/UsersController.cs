using EnYakınSatıcı.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnYakınSatıcıWebApİConsume.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getbyid/{id}")]
        public IActionResult GetById(int id)
        {
            var result = _userService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpGet("GetByMail/{email}")]
        public IActionResult GetByMail(string email)
        {
            var result = _userService.GetByMail(email);
          
                return Ok(result);
            

            
        }
    }
}
