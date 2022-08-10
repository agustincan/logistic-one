using Service.Common.Collection;
using Service.Common.Mapping;
using Service.Common.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transport.Persistence;
using Transport.Service.Queries.Dtos;

namespace Transport.Service.Queries
{
    public interface ITransportQueries
    {
        Task<DataCollection<TransportDto>> GetAllAsync(int page, int take);
        Task<DataCollection<TransportDto>> GetByDescriptionAsync(IEnumerable<int> ids, int page = 1, int take = 20);
        Task<DataCollection<TransportDto>> GetByDescriptionAsync(string description, int page = 1, int take = 20);
        Task<DataCollection<TransportDto>> GetByLicenseAsync(string license, int page = 1, int take = 20);
        Task<TransportDto> GetByIdAsync(int id);
    }

    public class TransportQueries : ITransportQueries
    {
        private readonly AppDbContext context;

        public TransportQueries(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<DataCollection<TransportDto>> GetAllAsync(int page, int take)
        {
            var result = await context.Transports.GetPagedAsync(page, take);
            return result.MapTo<DataCollection<TransportDto>>();
        }
        public async Task<TransportDto> GetByIdAsync(int id)
        {
            var result = await context.Transports.FindAsync(id);
            return result.MapTo<TransportDto>();
        }
        public async Task<DataCollection<TransportDto>> GetByDescriptionAsync(IEnumerable<int> ids, int page = 1, int take = 20)
        {
            var result = await context.Transports.Where(t => ids.Contains(t.Id)).GetPagedAsync(page, take);
            return result.MapTo<DataCollection<TransportDto>>();
        }
        public async Task<DataCollection<TransportDto>> GetByDescriptionAsync(string description, int page = 1, int take = 20)
        {
            var result = await context.Transports.Where(t => t.Description.Contains(description)).GetPagedAsync(page, take);
            return result.MapTo<DataCollection<TransportDto>>();
        }

        public async Task<DataCollection<TransportDto>> GetByLicenseAsync(string license, int page = 1, int take = 20)
        {
            var result = await context.Transports.Where(t => t.License.Contains(license)).GetPagedAsync(page, take);
            return result.MapTo<DataCollection<TransportDto>>();
        }
    }
}
