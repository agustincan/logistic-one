using Microsoft.Extensions.Options;
using Service.Common.Collection;
using System.Text.Json;
using Transport.Service.Queries.Dtos;

namespace Api.Gateway.Proxies
{
    public interface ITransportApiProxy
    {
        Task<DataCollection<TransportDto>> GetAllAsync(int page, int take);
        Task<DataCollection<TransportDto>> GetAllAsync(int page, int take, IEnumerable<int>? clients);
    }

    public class TransportApiProxy : ITransportApiProxy
    {
        private readonly HttpClient httpClient;
        private ApiUrls apiUrls;

        public TransportApiProxy(HttpClient httpClient, IOptions<ApiUrls> apiUrls)
        {
            this.httpClient = httpClient;
            this.apiUrls = apiUrls.Value;
        }

        public async Task<DataCollection<TransportDto>> GetAllAsync(int page, int take)
        {
            //var ids = string.Join(',', clients ?? new List<int>());

            var request = await httpClient.GetAsync($"{apiUrls.TransportUrl}/transport?page={page}&take={take}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<DataCollection<TransportDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }
        public async Task<DataCollection<TransportDto>> GetAllAsync(int page, int take, IEnumerable<int>? clients)
        {
            var ids = string.Join(',', clients ?? new List<int>());

            var request = await httpClient.GetAsync($"{apiUrls.TransportUrl}/transport?page={page}&take={take}&ids={ids}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<DataCollection<TransportDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }
    }
}