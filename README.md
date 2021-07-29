# not-grocy-server-asp-net

```bash
#export DOTNET_ROOT=$(dirname $(realpath $(which dotnet))) # /nix/store/iilqnmp2wq8xlk0d7bsvqi688w181g6n-dotnet-core-combined
#export PATH="$PATH:$HOME/.dotnet/tools"

dotnet tool install dotnet-ef
dotnet tool install dotnet-aspnet-codegenerator

# run with dotnet dotnet-aspnet-codegenerator

dotnet user-secrets init
dotnet user-secrets set "Movies:ServiceApiKey" "12345"
```

## Development

In theory we need two migrations for sqlite (the grocy one and our one) and one for all other databases.

### Run migrations

```
dotnet ef database update
```

### DROP the database

```
dotnet ef database drop
```

### Running

```
cd NotGrocy
dotnet watch run
```

### Testing

https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/providers?tabs=dotnet-core-cli

### Scaffold a controller

```bash
cd NotGrocy
dotnet aspnet-codegenerator controller -name ApiKeysController -async -api -m ApiKey -dc NotGrocyContext -outDir Controllers
dotnet aspnet-codegenerator controller -name BatteriesController -async -api -m Battery -dc NotGrocyContext -outDir Controllers
dotnet aspnet-codegenerator controller -name BatteryChargeCyclesController -async -api -m BatteryChargeCycle -dc NotGrocyContext -outDir Controllers
dotnet aspnet-codegenerator controller -name ChoresController -async -api -m Chore -dc NotGrocyContext -outDir Controllers
dotnet aspnet-codegenerator controller -name EquipmentController -async -api -m Equipment -dc NotGrocyContext -outDir Controllers
dotnet aspnet-codegenerator controller -name LocationsController -async -api -m Location -dc NotGrocyContext -outDir Controllers
dotnet aspnet-codegenerator controller -name MealPlanController -async -api -m MealPlan -dc NotGrocyContext -outDir Controllers
dotnet aspnet-codegenerator controller -name PermissionHierarchyController -async -api -m PermissionHierarchy -dc NotGrocyContext -outDir Controllers
dotnet aspnet-codegenerator controller -name ProductsController -async -api -m Product -dc NotGrocyContext -outDir Controllers
dotnet aspnet-codegenerator controller -name ProductBarcodesController -async -api -m ProductBarcode -dc NotGrocyContext -outDir Controllers
dotnet aspnet-codegenerator controller -name ProductGroupsController -async -api -m ProductGroup -dc NotGrocyContext -outDir Controllers
dotnet aspnet-codegenerator controller -name QuantityUnitsController -async -api -m QuantityUnit -dc NotGrocyContext -outDir Controllers
dotnet aspnet-codegenerator controller -name QuantityUnitConversionsController -async -api -m QuantityUnitConversion -dc NotGrocyContext -outDir Controllers
dotnet aspnet-codegenerator controller -name RecipesController -async -api -m Recipe -dc NotGrocyContext -outDir Controllers
dotnet aspnet-codegenerator controller -name RecipesNestingsController -async -api -m RecipesNesting -dc NotGrocyContext -outDir Controllers
dotnet aspnet-codegenerator controller -name RecipesNestingsController -async -api -m RecipesNesting -dc NotGrocyContext -outDir Controllers
dotnet aspnet-codegenerator controller -name RecipesPositionsController -async -api -m RecipesPo -dc NotGrocyContext -outDir Controllers
dotnet aspnet-codegenerator controller -name SessionsController -async -api -m Session -dc NotGrocyContext -outDir Controllers
dotnet aspnet-codegenerator controller -name ShoppingListController -async -api -m ShoppingList -dc NotGrocyContext -outDir Controllers
dotnet aspnet-codegenerator controller -name ShoppingListsController -async -api -m ShoppingList1 -dc NotGrocyContext -outDir Controllers
dotnet aspnet-codegenerator controller -name ShoppingLocationsController -async -api -m ShoppingLocation -dc NotGrocyContext -outDir Controllers
dotnet aspnet-codegenerator controller -name StockController -async -api -m Stock -dc NotGrocyContext -outDir Controllers
dotnet aspnet-codegenerator controller -name StockLogController -async -api -m StockLog -dc NotGrocyContext -outDir Controllers
dotnet aspnet-codegenerator controller -name TasksController -async -api -m Task -dc NotGrocyContext -outDir Controllers
dotnet aspnet-codegenerator controller -name TaskCategoriesController -async -api -m TaskCategory -dc NotGrocyContext -outDir Controllers
dotnet aspnet-codegenerator controller -name UsersController -async -api -m User -dc NotGrocyContext -outDir Controllers
dotnet aspnet-codegenerator controller -name UserEntitiesController -async -api -m Userentity -dc NotGrocyContext -outDir Controllers
dotnet aspnet-codegenerator controller -name UserFieldsController -async -api -m Userfield -dc NotGrocyContext -outDir Controllers
dotnet aspnet-codegenerator controller -name UserFieldValuesController -async -api -m UserfieldValue -dc NotGrocyContext -outDir Controllers
dotnet aspnet-codegenerator controller -name UserobjectsController -async -api -m Userobject -dc NotGrocyContext -outDir Controllers
dotnet aspnet-codegenerator controller -name UserPermissionsController -async -api -m UserPermission -dc NotGrocyContext -outDir Controllers
dotnet aspnet-codegenerator controller -name UserSettingsController -async -api -m UserSetting -dc NotGrocyContext -outDir Controllers
```

### Reverse engineer database

https://docs.microsoft.com/en-us/ef/core/managing-schemas/scaffolding?tabs=dotnet-core-cli
products table can not be scaffolded yet
```bash
dotnet ef dbcontext scaffold "Data Source=not-grocy.db" Microsoft.EntityFrameworkCore.Sqlite --data-annotations --context NotGrocyContext --context-dir Data --output-dir Models --namespace NotGrocy.Models --context-namespace NotGrocy --force --table api_keys --table batteries --table battery_charge_cycles --table chores --table chores_log --table equipment --table locations --table meal_plan --table permission_hierarchy --table product_barcodes --table product_groups --table quantity_unit_conversions --table quantity_units --table recipes --table recipes_nestings --table recipes_pos --table sessions --table shopping_list --table shopping_lists --table shopping_locations --table stock --table stock_log --table task_categories --table tasks --table user_permissions --table user_settings --table userentities --table userfield_values --table userfields --table userobjects --table users
```

### Migrations

```bash
dotnet ef migrations add Fixes --project ../NotGrocy.SqliteMigrations -- --provider Sqlite
dotnet ef migrations add Init --project ../NotGrocy.PostgresqlMigrations -- --provider Postgresql
dotnet ef migrations add Init --project ../NotGrocy.MysqlMigrations -- --provider Mysql

dotnet ef migrations remove --project ../NotGrocy.SqliteMigrations -- --provider Sqlite
dotnet ef migrations remove --project ../NotGrocy.PostgresqlMigrations -- --provider Postgresql
dotnet ef migrations remove --project ../NotGrocy.MysqlMigrations -- --provider Mysql

```

### Adding database support for another database

https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/providers?tabs=dotnet-core-cli

```
dotnet new classlib --name NotGrocy.PostgresqlMigrations
cd NotGrocy.PostgresqlMigrations
dotnet add reference ../NotGrocy.Data
cd ../NotGrocy
dotnet add reference ../NotGrocy.PostgresqlMigrations
dotnet ef migrations add MyMigration --project ../NotGrocy.PostgresqlMigrations -- --provider Postgresql
```

https://docs.microsoft.com/en-us/ef/core/modeling/entity-properties?tabs=data-annotations%2Cwithout-nrt
also has notes on nullability

### Important documentation

https://www.npgsql.org/doc/types/datetime.html
https://github.com/PomeloFoundation/Pomelo.EntityFrameworkCore.MySql/wiki/Configuration-Options