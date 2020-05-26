using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.JSInterop;
using System.Threading.Tasks;
using TSP.Client.Services;
using TSP.Shared;

namespace TSP.Client.Components
{
    [Authorize]
    public class SubSystemItemBase: ParentComponentBase
    {
        [Inject]
        SubItemDetailService Service { get; set; }
        
        [Parameter]
        public int SubMenuItemId { get; set; }

        public PageDataModel<SubItemDetailModel> PageDataModel { get; set; }
        protected int currentPage = 1;
        protected string title = string.Empty;
        protected string categoryId = "0";

        protected async Task Search(ChangeEventArgs e)
        {
            title = e.Value.ToString();
            currentPage = 1;
            await LoadDetails();
        }
        protected override async Task OnParametersSetAsync()
        {
            await LoadDetails();
        }
        protected async Task SelectedPage(int page)
        {
            currentPage = page;
            await LoadDetails(page);
        }

        protected async Task Filter()
        {
            currentPage = 1;
            await LoadDetails();
        }

        async Task LoadDetails(int page = 1, int quantityPerPage = 10)
        {
            try
            {
                PageDataModel = await Service.GetSubItemDetailAsync(SubMenuItemId.ToString(), page, quantityPerPage, title, Token);
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }
            catch (System.Exception ex)
            {
                GlobalMsg.SetMessage(ex.Message, MessageLevel.Error);
            }
        }
        
    }
}
