using AutoMapper;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace TSP.Client.Components
{
    public class ParentComponentBase : ComponentBase
    {
        //[Inject]
        //public AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        public string UserEmail { get; set; }
        [Inject]
        public GlobalMessage GlobalMsg { get; set; }
        protected override async Task OnInitializedAsync()
        {
            //var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            //UserEmail = authState.User.Identity.Name;
            GlobalMsg.SetMessage();
        }
    }
}
