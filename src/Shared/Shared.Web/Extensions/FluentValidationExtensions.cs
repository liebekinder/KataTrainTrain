using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Shared.Web.Extensions;
public static class FluentValidationExtensions
{
    public static ActionResult ValidationProblem(
        this ControllerBase source,
        ValidationResult validationResult
    )
    {
        validationResult.AddToModelState(source.ModelState);
        return source.ValidationProblem(
            modelStateDictionary: source.ModelState,
            statusCode: 400);
    }
}

