﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Shared.Web;

public abstract class ProjectServiceCollection
{
    public abstract void Register(IServiceCollection services, IConfiguration configuration);
}