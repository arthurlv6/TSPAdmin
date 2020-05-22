using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System.Threading.Tasks;
using TSP.Client.Services;
using TSP.Shared;

namespace TSP.Client.Components
{
    [Authorize]
    public class TSPHomeBase: ParentComponentBase
    {
        [Inject]
        SubItemDetailService Service { get; set; }
        [Inject]
        IAccessTokenProvider AuthenticationService { get; set; }

        public PageDataModel<SubItemDetailModel> PageDataModel { get; set; }
        protected int currentPage = 1;
        protected string nameFilter = string.Empty;
        protected string categoryId = "0";
        private string token = string.Empty;
        protected override async Task OnInitializedAsync()
        {
            var tokenResult = await AuthenticationService.RequestAccessToken();
            tokenResult.TryGetToken(out var tokenReference);
            token = tokenReference.Value;
            await LoadProducts();
        }

        protected async Task SelectedPage(int page)
        {
            currentPage = page;
            await LoadProducts(page);
        }

        protected async Task Filter()
        {
            currentPage = 1;
            await LoadProducts();
        }

        protected async Task Clear()
        {
            nameFilter = string.Empty;
            currentPage = 1;
            await LoadProducts();
        }

        async Task LoadProducts(int page = 1, int quantityPerPage = 10)
        {
            try
            {
                PageDataModel = await Service.GetSubItemDetailAsync("1", page, quantityPerPage, nameFilter, token);
            }
            catch (System.Exception ex)
            {
                GlobalMsg.SetMessage(ex.Message, MessageLevel.Error);
            }
        }
    }
}
