using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using System.Threading.Tasks;
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
        [HttpGet]
        public async Task<IActionResult> Get(int submenuItemId = 0,int page = 1, int size = 20, string keyword = "")
        {
            if (page < 1) return BadRequest("page can't be negative.");
            if (size < 1) return BadRequest("Page size can't be negative");

            var temp = await repo.GetPageData<SubItemDetailModel>(submenuItemId,page, size, keyword);
            HttpContext.InsertPaginationParameterInResponse(temp.Item2);
            return Ok(temp.Item1);
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> PartiallyUpdate(int id, [FromBody] JsonPatchDocument<SubItemDetailModel> model)
        {
            if (id == 0)
                return BadRequest();

            var record = await repo.GetOneAsync<SubItemDetail,SubItemDetailModel>(id);
            if (record == null)
                return NotFound();

            model.ApplyTo(record, ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await repo.UpdateAsync<SubItemDetail, SubItemDetailModel>(record);
            return NoContent();
        }
    }
}
