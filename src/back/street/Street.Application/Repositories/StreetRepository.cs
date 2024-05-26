using Common.Core.Repository;
using LanguageExt;
using Microsoft.EntityFrameworkCore;
using Streets.Persistence.Database;
using Streets.Persistence.Database.Models;

namespace Streets.Application.Repositories
{
    internal class StreetRepository : RepositoryBase<Street, int, AppDbContext>, IStreetRepository
    {
        

        public StreetRepository(AppDbContext context) : base(context)
        {
            
        }

        public async Task Insert7000()
        {
            var listSeeds = new List<Street>();
            for (int i = 1; i <= 7000; i++)
            {
                listSeeds.Add(new Street() { Name = $"Street name {i}", Number = i * i + 1 });
            }
            await DbContext.Streets.AddRangeAsync(listSeeds);
            await SaveChangesAsync();
            
        }
        public async Task Copy3000()
        {
            var q1 = DbContext.Streets
                .AsNoTracking()
                .AsSplitQuery()
                .Where(e => e.Id <= 3000)
                .Select(x => new StreetCopy()
                {
                    StreetId = x.Id,
                    Name = x.Name,
                    Number = x.Number,
                    Active = x.Active
                });

            await DbContext.StreetCopies.AddRangeAsync(await q1.ToListAsync());
            await SaveChangesAsync();
        }

        public async Task Copy3000Raw()
        {
            var par = new { Id = 3000 };
            var sql = $@"
                DECLARE @Id int
                INSERT INTO dbo.StreetCopies(StreetId, [Name], [Number], Active)
                SELECT Id, [Name] , [Number], Active FROM dbo.Streets(nolock)
                WHERE Id <= @Id
            ";

            string sql2 = $@"
                DECLARE @Id int
                INSERT INTO dbo.StreetCopies(StreetId, [Name], [Number], Active)
                SELECT Id, [Name] , [Number], Active FROM dbo.Streets(nolock)
                WHERE Id <= {par.Id}
            ";
            
            //await DbContext.Database.ExecuteSqlRawAsync(sql, par);
           
            await DbContext.Database.ExecuteSqlInterpolatedAsync(sql2);
        }
    }
}
