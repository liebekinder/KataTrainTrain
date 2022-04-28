using Lucca.Core.Shared.Domain;
using Lucca.Core.Shared.Domain.Context;
using Lucca.Core.Shared.Domain.Contracts.Principals;
using Lucca.Tests.Api.SpecFlowPlugin.Contexts;
using Lucca.Tests.Api.SpecFlowPlugin.Http;
using Microsoft.AspNetCore.Authentication;
using System.Collections.Generic;
using System.Security.Claims;

namespace Fleet.Web.Tests.Models.Contexts;

public class PrincipalContext : IPrincipalContext, IWithAuthenticationTicket
{
    public string ToAuthenticationHeader() => 
        $"lucca user=56FEC4B5-362E-4A5F-B464-F58F160BD066";

    public AuthenticationTicket BuildAuthenticationTicket(string authenticationScheme) =>
        new(new ClaimsPrincipal(new ClaimsIdentity(GetClaims(), AuthenticationTypes.Lucca)),
            authenticationScheme);

    private IReadOnlyCollection<Claim> GetClaims() =>
        new List<Claim>
        {
            new(ClaimTypes.Name, "DefaultUser"),
            new(nameof(IPrincipal.Type), PrincipalType.User.ToString()),
            new(nameof(ICultured.Culture), new Culture(1033).Code),
        };
}