using TSP.Shared;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TSP.Client.Services
{
    
    public class SubMenuItemService : BaseService
    {
        private readonly HttpClient _httpClient;
        public SubMenuItemService(HttpClient httpClient):base(httpClient)
        {
            _httpClient = httpClient;
        }
    }
}
