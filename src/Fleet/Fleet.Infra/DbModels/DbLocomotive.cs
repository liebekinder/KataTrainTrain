namespace Fleet.Infra.DbModels;

public class DbLocomotive
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Brand { get; set; } = string.Empty;

    public DbLocomotiveModel Model { get; set; }

    public decimal WeightInTons { get; set; }

    public decimal MaxTractionInTons { get; set; }
}
