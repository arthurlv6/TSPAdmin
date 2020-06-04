using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using System.Threading.Tasks;
using TSP.Server.Repos;
using TSP.Shared;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using System;
using TSPServer.Services;

namespace TSP.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubItemDetailController : ControllerBase
    {
        private readonly SubItemDetailRepo repo;
        private readonly IWebHostEnvironment env;
        private readonly ImageStore imageStore;
        public SubItemDetailController(SubItemDetailRepo _repo, IWebHostEnvironment _env, ImageStore _imageStore)
        {
            repo = _repo;
            env = _env;
            imageStore = _imageStore;
        }
        [HttpGet]
        public async Task<IActionResult> Get(int submenuItemId = 0, int page = 1, int size = 20, string keyword = "")
        {
            if (page < 1) return BadRequest("page can't be negative.");
            if (size < 1) return BadRequest("Page size can't be negative");

            var temp = await repo.GetPageData<SubItemDetailModel>(submenuItemId, page, size, keyword);
            HttpContext.InsertPaginationParameterInResponse(temp.Item2);
            return Ok(temp.Item1);
        }
        [Authorize]
        [HttpPatch("{id}")]
        public async Task<IActionResult> PartiallyUpdate(int id, [FromBody] JsonPatchDocument<SubItemDetailModel> model)
        {
            if (id == 0)
                return BadRequest();

            var record = await repo.GetOneAsync<SubItemDetail, SubItemDetailModel>(id);
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
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> UploadFileAsync([FromForm] UploadProductLinkModel model)
        {
            if (model == null)
                return BadRequest();

            if (model.Id == 0)
            {
                ModelState.AddModelError("ProductId", "ProductId shouldn't be zero");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //
            string sasUrl=null;
            if (model.File != null)
            {
                using (var stream = model.File.OpenReadStream())
                {
                    var imageId = await imageStore.SaveImage(stream);
                    sasUrl = imageStore.UriFor(imageId);
                    //return RedirectToAction("Show", new { imageId });
                }
            }
            await repo.UpdateImageAsync(model.Id, sasUrl);
            return Ok(sasUrl);
        }
        [Authorize]
        [HttpPost("detail")]
        public async Task<IActionResult> Post([FromBody] AddDetailModel model)
        {
            if (model == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            SubItemDetailModel subItemDetailModel = new SubItemDetailModel()
            {
                Name = model.Name,
                SubMenuItemId = model.MenuId
            };

            var created = await repo.AddAsync(subItemDetailModel);

            return Created("SubItemDetail", new AddDetailModel() { Id=created.Id, MenuId=created.SubMenuItemId,Name=created.Name});
        }
    }
}
