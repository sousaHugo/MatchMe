using Mapster;
using MatchMe.Candidates.Application.Dto.Candidates;
using MatchMe.Candidates.Infrastructure.EF.Contexts;
using MatchMe.Candidates.Infrastructure.EF.Models;
using MatchMe.Common.Shared.Queries;
using Microsoft.EntityFrameworkCore;

namespace MatchMe.Candidates.Infrastructure.EF.Queries.Handlers
{
    public class SearchCandidateHandler : IQueryHandler<SearchCandidatesQuery, IEnumerable<CandidateGetDto>>
    {
        private readonly DbSet<CandidateReadModel> _readModel;

        public SearchCandidateHandler(ReadDbContext DbContext) => _readModel = DbContext.Candidate;


        public async Task<IEnumerable<CandidateGetDto>> Handle(SearchCandidatesQuery Request, CancellationToken CancellationToken)
        {
            var dbQuery = _readModel
                .Include(a => a.Skills)
                .AsQueryable();

            if (Request.Search_Phrase is not null)
            {
                dbQuery = dbQuery.Where(a => Microsoft.EntityFrameworkCore.EF.Functions.ILike(a.FirstName, $"%{Request.Search_Phrase}%"));
            }

            return await dbQuery.Select(a => a.Adapt<CandidateGetDto>()).AsNoTracking().ToListAsync();
        }
    }
}
