namespace Tenancy.Controllers.Request.Tenant
{
    public class UpdateTenantRequest
    {
        public required string Name { get; set; } = string.Empty;
        public required string Email { get; set; } = string.Empty;
        public required string ContactNumber { get; set; } = string.Empty;
    }
}
