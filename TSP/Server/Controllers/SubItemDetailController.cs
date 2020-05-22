using Microsoft.AspNetCore.Mvc;
using TSP.Server.Repos;
using TSP.Shared;

namespace TSP.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubItemDetailController : ControllerBase
    {
        private readonly SubItemDetailRepo repo;
        public SubItemDetailController(SubItemDetailRepo _repo)
        {
            repo = _repo;
        }
        // GET: api/Requirement
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(repo.GetAll<SubItemDetail, SubItemDetailModel>());
        }
    }
}
