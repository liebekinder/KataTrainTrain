using Fleet.Infra.DbModels;
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

    public static LocomotiveViewModel MapToViewModel(DbLocomotive infra)
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
}

