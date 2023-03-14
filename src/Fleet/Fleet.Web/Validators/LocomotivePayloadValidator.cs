using Fleet.Web.Payloads;
using FluentValidation;

namespace Fleet.Web.Validators;

public sealed class LocomotivePayloadValidator : AbstractValidator<LocomotivePayload>
{
    public LocomotivePayloadValidator()
    {
        RuleFor(t => t.Name)
            .Must(t => !string.IsNullOrWhiteSpace(t)).WithMessage("Name must not be null or empty")
            .MaximumLength(50).WithMessage("Name length must not exceed 50 characters");

        RuleFor(t => t.Brand)
            .Must(t => !string.IsNullOrWhiteSpace(t)).WithMessage("Brand must not be null or empty")
            .MaximumLength(50).WithMessage("Brand length must not exceed 50 characters");

        RuleFor(t => t.MaxTractionInTons)
            .Must(t => t.HasValue && t.Value >= 0).WithMessage("MaxTractionInTons must be positive");

        RuleFor(t => t.WeightInTons)
            .Must(t => t.HasValue && t.Value >= 0).WithMessage("WeightInTons must be positive");

        RuleFor(t => t.MaxTractionInTons)
            .GreaterThan(t => t.WeightInTons).WithMessage("MaxTraction must be greater than Weight")
                .When(t => (t.MaxTractionInTons.HasValue && t.MaxTractionInTons >= 0)
                        && (t.WeightInTons.HasValue && t.WeightInTons >= 0));
    }
}

