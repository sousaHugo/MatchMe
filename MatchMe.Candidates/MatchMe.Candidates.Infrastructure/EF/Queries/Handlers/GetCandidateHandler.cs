using Mapster;
using MatchMe.Candidates.Application.Dto.Candidates;
using MatchMe.Candidates.Infrastructure.EF.Contexts;
using MatchMe.Candidates.Infrastructure.EF.Models;
using MatchMe.Common.Shared.Queries;
using Microsoft.EntityFrameworkCore;

namespace MatchMe.Candidates.Infrastructure.EF.Queries.Handlers
{
    public class GetCandidateHandler : IQueryHandler<GetCandidateQuery, CandidateGetDto>
    {
        private readonly DbSet<CandidateReadModel> _readModel;

        public GetCandidateHandler(ReadDbContext DbContext) => _readModel = DbContext.Candidate;
        public Task<CandidateGetDto> Handle(GetCandidateQuery Request, CancellationToken CancellationToken)
            => _readModel
            .Include(a => a.Skills)
            .Where(a => a.Id == Request.Id)
            .AsNoTracking()
            .Select(a => a.Adapt<CandidateGetDto>())
            .SingleOrDefaultAsync();
    }
}
