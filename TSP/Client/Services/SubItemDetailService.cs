using TSP.Shared;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Linq;

namespace TSP.Client.Services
{
    
    public class SubItemDetailService : BaseService
    {
        private readonly HttpClient _httpClient;
        public SubItemDetailService(HttpClient httpClient):base(httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<PageDataModel<SubItemDetailModel>> GetSubItemDetailAsync(string submenuItemId,int page, int size, string keyword, string token)
        {
            if (!_httpClient.DefaultRequestHeaders.Contains("Authorization") && !string.IsNullOrEmpty(token))
                _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            string url = $"api/SubItemDetail?page={page}&size={size}&keyword={keyword}&subMenuItemId={submenuItemId}";
            var httpResponseMessage = await _httpClient.GetAsync(url);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var data = await httpResponseMessage.Content.ReadAsStreamAsync();
                var deserializedData = await JsonSerializer.DeserializeAsync<List<SubItemDetailModel>>(data, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                return new PageDataModel<SubItemDetailModel>
                {
                    Data = deserializedData,
                    PageQuantity = int.Parse(httpResponseMessage.Headers.GetValues("pagesQuantity").FirstOrDefault() ?? "0")
                };
            }
            else
            {
                throw new Exception(httpResponseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult());
            }
        }
        public async Task<bool> UpdateAsync(int id, string val, PatchUpdateItem patchUpdateItem)
        {
            PatchUpdate[] patchUpdates = new PatchUpdate[1];
            if (patchUpdateItem == PatchUpdateItem.Name)
            {
                patchUpdates[0] = new PatchUpdate { op = "replace", path = "Name", value = val };
            }
            if (patchUpdateItem == PatchUpdateItem.Style)
            {
                patchUpdates[0] = new PatchUpdate { op = "replace", path = "Style", value = val };
            }
            if (patchUpdateItem == PatchUpdateItem.Color)
            {
                patchUpdates[0] = new PatchUpdate { op = "replace", path = "Color", value = val };
            }
            if (patchUpdateItem == PatchUpdateItem.Size)
            {
                patchUpdates[0] = new PatchUpdate { op = "replace", path = "Size", value = val };
            }
            if (patchUpdateItem == PatchUpdateItem.Price)
            {
                patchUpdates[0] = new PatchUpdate { op = "replace", path = "Price", value = string.IsNullOrEmpty(val) ? "0" : val };
            }
            if (patchUpdateItem == PatchUpdateItem.Quatity)
            {
                patchUpdates[0] = new PatchUpdate { op = "replace", path = "Quatity", value = string.IsNullOrEmpty(val) ? "0" : val };
            }
            if (patchUpdateItem == PatchUpdateItem.Description)
            {
                patchUpdates[0] = new PatchUpdate { op = "replace", path = "Style", value = val };
            }

            var jsonData = JsonSerializer.Serialize(patchUpdates);
            var modelJson =
                new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _httpClient.PatchAsync("api/Product/" + id, modelJson);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;

        }
    }
}
