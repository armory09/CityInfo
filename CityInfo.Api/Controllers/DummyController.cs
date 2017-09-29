using Microsoft.AspNetCore.Mvc;

namespace CityInfo.Api.Controllers
{
    public class DummyController : Controller
    {
        private readonly CityInfoContext _ctx;

        public DummyController(CityInfoContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        [Route("api/testdatabase")]
        public IActionResult TestDatabase()
        {
            return Ok();
        }
    }
}
