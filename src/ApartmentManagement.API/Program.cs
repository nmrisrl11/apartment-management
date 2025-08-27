using ApartmentManagement.Contracts.Services;
using Leasing.Application;
using Leasing.Controllers;
using Leasing.Infrastructure;
using Microsoft.OpenApi.Models;
using Ownership.Application;
using Ownership.Controllers;
using Ownership.Infrastructure;
using Scalar.AspNetCore;
using Tenancy.Application;
using Tenancy.Controllers;
using Tenancy.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddApplicationPart(typeof(LeasingAgreementsController).Assembly)
    .AddApplicationPart(typeof(OwnersController).Assembly)
    .AddApplicationPart(typeof(TenantsController).Assembly);

builder.Services.AddOpenApi(options =>
{
    options.AddDocumentTransformer((doc, ctx, ct) =>
    {
        doc.Components ??= new();
        doc.Components.SecuritySchemes["BearerAuth"] = new OpenApiSecurityScheme
        {
            Type = SecuritySchemeType.Http,
            Scheme = "bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Name = "Authorization"
        };
        return Task.CompletedTask;
    });

    options.AddOperationTransformer((op, ctx, ct) =>
    {
        var hasAuth = ctx.Description.ActionDescriptor?.EndpointMetadata?
            .OfType<Microsoft.AspNetCore.Authorization.IAuthorizeData>()
            .Any() == true;

        if (hasAuth)
        {
            op.Security ??= new List<OpenApiSecurityRequirement>();
            op.Security.Add(new OpenApiSecurityRequirement
            {
                [new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    { Type = ReferenceType.SecurityScheme, Id = "BearerAuth" }
                }] = Array.Empty<string>()
            });
        }
        return Task.CompletedTask;
    });
});

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(Leasing.Application.AssemblyReference).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(Ownership.Application.AssemblyReference).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(Tenancy.Application.AssemblyReference).Assembly);
});

// Leasing
builder.Services.AddLeasingApplication();
builder.Services.AddLeasingInfrastructure(builder.Configuration);

// Ownership
builder.Services.AddOwnershipApplication();
builder.Services.AddOwnershipInfrastructure(builder.Configuration);

// Tenancy
builder.Services.AddTenancyApplication();
builder.Services.AddTenancyInfrastructure(builder.Configuration);

builder.Services.AddScoped<IEventBus, EventBus>();
builder.Services.AddScoped<IDomainEventPublisher, DomainEventPublisher>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options.WithTitle("Apartment Management API");
        options.WithTheme(ScalarTheme.Kepler);
        options.WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.Http);
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
