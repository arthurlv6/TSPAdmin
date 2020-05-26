using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
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
        [Inject]
        IJSRuntime JSRuntime { get; set; }




        protected async Task ShowDetail(SubItemDetailModel model)
        {
            if (model.IsShowClass == "d-block")
            {
                Item.IsShowClass = "d-none";
            }
            else
            {
                Item.IsShowClass = "d-block";
                await JSRuntime.InvokeVoidAsync("blazorInterop.initializeSummernote",model.Id,model.Paragraph);
            }
        }
        protected async Task SaveChanges(int id)
        {
            string paragraph = await JSRuntime.InvokeAsync<string>("blazorInterop.initializeSummernoteGet",id);
            await Change( new ChangeEventArgs() { Value=paragraph },PatchUpdateItem.Paragraph);
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
