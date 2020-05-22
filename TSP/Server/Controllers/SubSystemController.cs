using Microsoft.AspNetCore.Mvc;
using TSP.Server.Repos;
using TSP.Shared;

namespace TSP.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubSystemController : ControllerBase
    {
        private readonly SubSystemRepo repo;
        public SubSystemController(SubSystemRepo _repo)
        {
            repo = _repo;
        }
        // GET: api/Requirement
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(repo.GetAll<SubSystem, SubSystemModel>());
        }
    }
}
