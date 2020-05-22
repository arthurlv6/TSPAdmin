using Microsoft.AspNetCore.Mvc;
using TSP.Server.Repos;
using TSP.Shared;

namespace TSP.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubMenuItemController : ControllerBase
    {
        private readonly SubMenuItemRepo repo;
        public SubMenuItemController(SubMenuItemRepo _repo)
        {
            repo = _repo;
        }
        // GET: api/Requirement
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(repo.GetAll<SubMenuItem, SubMenuItemModel>());
        }
    }
}
