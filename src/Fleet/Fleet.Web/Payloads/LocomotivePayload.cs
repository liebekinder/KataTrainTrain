namespace Fleet.Web.Payloads;

public sealed class LocomotivePayload
{
    public string? Name { get; set; }

    public string? Brand { get; set; }

    public LocomotiveModelViewModel? Model { get; set; }

    public decimal? WeightInTons { get; set; }

    public decimal? MaxTractionInTons { get; set; }
}

