using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Teretana.Domain.Entities;

namespace Teretana.Application.Uplate.Queries
{
    public record GetUplateQuery(StatusUplate Status, DateTime Od, DateTime Do)
    : IRequest<List<UplataDto>>;
}
