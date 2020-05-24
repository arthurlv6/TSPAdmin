using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TSP.Client.Services;
using TSP.Shared;

namespace TSP.Client.Components
{
    public class SubItemDetailLineBase: ParentComponentBase
    {
        [Parameter]
        public SubItemDetailModel Item { get; set; }
        [Inject]
        protected SubItemDetailService Service { get; set; }
        protected override void OnInitialized()
        {
            //foreach (var item in Item.ProductLinks)
            //{
            //    if (!item.Address.Contains("http"))
            //        item.Address = "https://neartonztesting.oss-ap-southeast-2.aliyuncs.com/" + item.Address;
            //}
        }
        protected void ShowDetail(SubItemDetailModel model)
        {
            Item.IsShowDetail = !Item.IsShowDetail;
        }
        protected async Task Change(ChangeEventArgs e, PatchUpdateItem patchUpdateItem)
        {
            var val = e.Value.ToString();
            PatchUpdate[] patchUpdates = new PatchUpdate[1];
            if (patchUpdateItem == PatchUpdateItem.Title)
            {
                patchUpdates[0] = new PatchUpdate { op = "replace", path = "Title", value = val };
                Item.Title = val;
            }
            if (patchUpdateItem == PatchUpdateItem.Paragraph)
            {
                patchUpdates[0] = new PatchUpdate { op = "replace", path = "Paragraph", value = val };
            }
            var isDone = await Service.UpdateAsync(Item.Id, val, patchUpdates);
            if (!isDone)
                GlobalMsg.SetMessage("Failed to change the name");
        }
    }
}
