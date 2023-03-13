namespace Fleet.Domain;
public class Locomotive
{
    public int Id { get; private set; }

    public string Name { get; private set; } = string.Empty;

    public string Brand { get; private set; } = string.Empty;

    public LocomotiveModel Model { get; private set; } = LocomotiveModel.Invalid;

    public decimal WeightInTons { get; private set; }

    public decimal MaxTractionInTons { get; private set; }

    public Locomotive(string name, string brand, LocomotiveModel model)
    {
        Name = name;
        Brand = brand;
        Model = model;
    }
}
