using OnlineStore.Common.Requests.CompanyRequests;
using OnlineStore.Common.Responses.CompanyResponses;
using OnlineStore.Web.Infrastructure.Interfaces;
using System.Text.Json;

namespace OnlineStore.Web.Infrastructure.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _serializerOptions;
        public CompanyService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("api");

            _serializerOptions = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }


        public async Task<CompanyResponse> Create(CreateCompanyRequest request)
        {
            string requestJson = JsonSerializer.Serialize<CreateCompanyRequest>(request, _serializerOptions);

            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("/api/Companies/Create", requestJson);
            string responseContent = await response.Content.ReadAsStringAsync();

            CompanyResponse company = JsonSerializer.Deserialize<CompanyResponse>(responseContent, _serializerOptions);

            return company;
        }

        public async Task Delete(string id)
        {
            await _httpClient.DeleteAsync($"/api/Companies/Delete/{id}");
        }

        public async Task<IEnumerable<GetAllCompaniesResponse>> GetAll()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("/api/Companies/GetAll");
            string responseContent = await response.Content.ReadAsStringAsync();

            ICollection<GetAllCompaniesResponse> allCompanies = JsonSerializer.Deserialize<ICollection<GetAllCompaniesResponse>>(responseContent, _serializerOptions);
            
            return allCompanies;
        }

        public async Task<CompanyResponse> GetById(string id)
        {

            HttpResponseMessage response = await _httpClient.GetAsync($"/api/Companies/Details/{id}");
            string responseContent = await response.Content.ReadAsStringAsync();

            CompanyResponse company = JsonSerializer.Deserialize<CompanyResponse>(responseContent, _serializerOptions);

            return company;
        }

        public async Task<CompanyResponse> Update(UpdateCompanyRequest request)
        {
            string requestJson = JsonSerializer.Serialize<UpdateCompanyRequest>(request, _serializerOptions);

            HttpResponseMessage response = await _httpClient.PutAsJsonAsync("/api/Companies/Update", requestJson);
            string responseContent = await response.Content.ReadAsStringAsync();

            CompanyResponse company = JsonSerializer.Deserialize<CompanyResponse>(responseContent, _serializerOptions);

            return company;
        }
    }
}
