using Api.Gateway.WebClient.Proxy.Config;
using Common.Core.Collections;
using Microsoft.AspNetCore.Http;
using Transport.Domain.Dtos;

namespace Api.Gateway.WebClient.Proxy
{
    public interface ITransportProxy
    {
        Task<DataCollection<TransportDto>> GetAllAsync(int page, int take, IEnumerable<int>? clients);
    }

    public class TransportProxy : ITransportProxy
    {
        private readonly HttpClient httpClient;
        private readonly ITransportProxy transportProxy;
        //private readonly string apiGatewayUrl;

        //public TransportProxy(HttpClient client, ApiGatewayUrl apiGatewayUrl, ITransportApiProxy transportApiProxy)
        //{
        //    this.httpClient = client;
        //    this.transportApiProxy = transportApiProxy;
        //    this.apiGatewayUrl = apiGatewayUrl.Value;
        //}
        //public TransportProxy(HttpClient httpClient, ApiGatewayUrl apiGatewayUrl, IHttpContextAccessor httpContextAccesor)
        //{
        //    this.httpClient = httpClient;
        //    this.httpClient.AddBearerToken(httpContextAccesor);
        //    this.apiGatewayUrl = apiGatewayUrl.Value;
        //}

        public TransportProxy(HttpClient httpClient, ITransportProxy transportProxy, IHttpContextAccessor httpContextAccesor)
        {
            this.httpClient = httpClient;
            this.httpClient.AddBearerToken(httpContextAccesor);
            this.transportProxy = transportProxy;
            //this.apiGatewayUrl = apiGatewayUrl.Value;
        }

        public async Task<DataCollection<TransportDto>> GetAllAsync(int page, int take, IEnumerable<int>? clients)
        {
            return await transportProxy.GetAllAsync(page, take, clients);
        }

    }
}