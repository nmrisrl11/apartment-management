# Apartment Management - Learning Back-End (Exercise)

Add-Migration InitialTenancyMigration -Context TenancyDbContext
Update-Database -Context TenancyDbContext

Add-Migration InitialOwnershipMigration -Context OwnershipDbContext
Update-Database -Context OwnershipDbContext

Add-Migration InitialPropertyMigration -Context PropertyDbContext
Update-Database -Context PropertyDbContext

Add-Migration InitialLeasingMigration -Context LeasingDbContext
Update-Database -Context LeasingDbContext

Add-Migration InitialBillingMigration -Context BillingDbContext
Update-Database -Context BillingDbContext
