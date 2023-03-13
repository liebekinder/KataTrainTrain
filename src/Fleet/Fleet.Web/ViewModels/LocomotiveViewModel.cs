namespace Fleet.Web.ViewModels;
public sealed class LocomotiveViewModel
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Brand { get; set; } = string.Empty;

    public LocomotiveModelViewModel Model { get; set; }

    public decimal WeightInTons { get; set; }

    public decimal MaxTractionInTons { get; set; }
}

