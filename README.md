# Apartment Management - Learning Back-End (Exercise)

Add-Migration InitialTenancyMigration -Context TenancyDbContext
<br />
Update-Database -Context TenancyDbContext

Add-Migration InitialOwnershipMigration -Context OwnershipDbContext
<br />
Update-Database -Context OwnershipDbContext

Add-Migration InitialPropertyMigration -Context PropertyDbContext
<br />
Update-Database -Context PropertyDbContext

Add-Migration InitialLeasingMigration -Context LeasingDbContext
<br />
Update-Database -Context LeasingDbContext

Add-Migration InitialBillingMigration -Context BillingDbContext
<br />
Update-Database -Context BillingDbContext
