using Microsoft.AspNetCore.Mvc;

namespace MzsfApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MzsfController : ApiControllerBase
    {

        public MzsfController()
        {

        }



        [HttpGet]
        public string GetTest()
        {
            return "ok";
        }
    }
}
