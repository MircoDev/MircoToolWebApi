using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MircoToolWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllToDos() 
        {
            return Ok();
        }


    }
}
