using MediatR;
using Microsoft.EntityFrameworkCore;
using Teretana.Data;

namespace Teretana.Application.Uplate.Queries;

public class GetUplateQueryHandler : IRequestHandler<GetUplateQuery, List<UplataDto>>
{
    private readonly TeretanaDbContext _db;

    public GetUplateQueryHandler(TeretanaDbContext db) => _db = db;

    public async Task<List<UplataDto>> Handle(GetUplateQuery request, CancellationToken ct)
    {
        return await _db.Uplate
            .AsNoTracking()
            .Where(u => u.Status == request.Status
                     && u.Datum >= request.Od
                     && u.Datum < request.Do)
            .OrderBy(u => u.Datum)
            .Select(u => new UplataDto(u.Id, u.ClanId, u.Datum, u.Status, u.Iznos))
            .ToListAsync(ct);
    }
}