# not-grocy-server-asp-net

```bash
export DOTNET_ROOT=$(dirname $(realpath $(which dotnet))) # /nix/store/iilqnmp2wq8xlk0d7bsvqi688w181g6n-dotnet-core-combined
export PATH="$PATH:$HOME/.dotnet/tools"

dotnet tool install dotnet-ef
dotnet tool install dotnet-aspnet-codegenerator

# run with dotnet dotnet-aspnet-codegenerator

dotnet user-secrets init
dotnet user-secrets set "Movies:ServiceApiKey" "12345"
```

## Development

### Run migrations

```
dotnet ef database update
```

### Running

```
dotnet watch run
```

### Testing

https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/providers?tabs=dotnet-core-cli

### Scaffold a controller

```bash
dotnet aspnet-codegenerator controller -name LocationsController -async -api -m Location -dc LocationContext -outDir Controllers
```

### Reverse engineer database

https://docs.microsoft.com/en-us/ef/core/managing-schemas/scaffolding?tabs=dotnet-core-cli
products table can not be scaffolded yet
```bash
dotnet ef dbcontext scaffold "Data Source=not-grocy.db" Microsoft.EntityFrameworkCore.Sqlite --data-annotations --context NotGrocyContext --context-dir Data --output-dir Models --namespace NotGrocy.Models --context-namespace NotGrocy --force --table api_keys --table batteries --table battery_charge_cycles --table chores --table chores_log --table equipment --table locations --table meal_plan --table permission_hierarchy --table product_barcodes --table product_groups --table quantity_unit_conversions --table quantity_units --table recipes --table recipes_nestings --table recipes_pos --table sessions --table shopping_list --table shopping_lists --table shopping_locations --table stock --table stock_log --table task_categories --table tasks --table user_permissions --table user_settings --table userentities --table userfield_values --table userfields --table userobjects --table users
```

### Migrations

```bash
dotnet ef migrations add MyMigration --project ../NotGrocy.SqliteMigrations -- --provider Sqlite
dotnet ef migrations add MyMigration --project ../NotGrocy.PostgresqlMigrations -- --provider Postgresql
dotnet ef migrations add MyMigration --project ../MysqlMigrations -- --provider Mysql

dotnet ef migrations remove --project ../NotGrocy.SqliteMigrations -- --provider Sqlite
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