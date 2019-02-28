Add-Migration InitialCreate -Context InPortDbContext -OutputDir Migrations\
Add-Migration InitialCreate -Context EventStoreSQLContext -OutputDir Migrations\EventStoreSQL


Add-Migration InitialCreate.
Update-Database.
Add-Migration AddProductReviews.
Update-Database -Context EventStoreSQLContext
Remove-Migration.
Update-Database LastGoodMigration.


