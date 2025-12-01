using SapIntegrationApi.DTOs;
using System.Text;
using System.Text.Json;

namespace SapIntegrationApi.Services
{
    public class SapServiceLayerClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;
        private string _sessionId;

        public SapServiceLayerClient(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _baseUrl = config["Sap:BaseUrl"] ?? "https://localhost:7028/b1s/v1"; //Mock Url
        }

        public async Task LoginAsync()
        {
            var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/Login", new { });
            response.EnsureSuccessStatusCode();

            var loginResult = await response.Content.ReadFromJsonAsync<LoginResponseDto>();
            _sessionId = loginResult.SessionId;
        }

        public async Task<string> CreateCustomer(CustomerDto dto)
        {
            await LoginAsync();
            var json = JsonSerializer.Serialize(new { CardCode = dto.CardCode, CardName = dto.CardName, CardType = "Customer" });
            var res = await _httpClient.PostAsync($"{_baseUrl}/BusinessPartners", new StringContent(json, Encoding.UTF8, "application/json"));
            return await res.Content.ReadAsStringAsync();
        }

        public async Task<string> CreateOrder(OrderDto dto)
        {
            await LoginAsync();
            var json = JsonSerializer.Serialize(dto);
            var res = await _httpClient.PostAsync($"{_baseUrl}/Orders", new StringContent(json, Encoding.UTF8, "application/json"));
            return await res.Content.ReadAsStringAsync();
        }
    }
}
