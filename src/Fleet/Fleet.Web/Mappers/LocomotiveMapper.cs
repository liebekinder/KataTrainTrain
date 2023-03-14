using Fleet.Infra;
using Fleet.Infra.DbModels;
using Fleet.Web.Payloads;
using Fleet.Web.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Fleet.Web.Mappers;
public sealed class LocomotiveMapper
{
    public static IReadOnlyCollection<LocomotiveViewModel> MapToViewModel(IReadOnlyCollection<DbLocomotive> infra)
    {
        return infra.Select(x => MapToViewModel(x)).ToList();
    }

    internal static LocomotiveViewModel MapToViewModel(DbLocomotive infra)
    {
        return new LocomotiveViewModel
        {
            Name = infra.Name,
            Brand = infra.Brand,
            Id = infra.Id,
            MaxTractionInTons = infra.MaxTractionInTons,
            Model = (LocomotiveModelViewModel)infra.Model,
            WeightInTons = infra.WeightInTons
        };
    }

    internal static DbLocomotive MapToDbModel(LocomotivePayload payload)
    {
        return new DbLocomotive
        {
            Name = payload.Name!,
            Brand = payload.Brand!,
            MaxTractionInTons = payload.MaxTractionInTons!.Value,
            Model = (DbLocomotiveModel)payload.Model!,
            WeightInTons = payload.WeightInTons!.Value
        };
    }
}

