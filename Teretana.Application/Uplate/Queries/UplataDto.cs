using System;
using System.Collections.Generic;
using System.Text;
using Teretana.Domain.Entities;

namespace Teretana.Application.Uplate.Queries
{
    public record UplataDto(int Id, int ClanId, DateTime Datum, StatusUplate Status, decimal Iznos);
    
}
