# not-grocy-server-asp-net

```bash
export DOTNET_ROOT=$(dirname $(realpath $(which dotnet)))
export PATH="$PATH:$HOME/.dotnet/tools"

dotnet tool install --global dotnet-ef
dotnet tool install --global dotnet-aspnet-codegenerator
```

## Development

### Scaffold a controller

```
dotnet aspnet-codegenerator controller -name LocationsController -async -api -m Location -dc LocationContext -outDir Controllers
```

### Reverse engineer database

https://docs.microsoft.com/en-us/ef/core/managing-schemas/scaffolding?tabs=dotnet-core-cli
products table can not be scaffolded yet
```
dotnet ef dbcontext scaffold "Data Source=hello.db" Microsoft.EntityFrameworkCore.Sqlite --data-annotations --context NotGrocyContext --context-dir Data --output-dir Models --namespace NotGrocy.Models --context-namespace NotGrocy --force --table api_keys --table batteries --table battery_charge_cycles --table chores --table chores_log --table equipment --table locations --table meal_plan --table permission_hierarchy --table product_barcodes --table product_groups --table quantity_unit_conversions --table quantity_units --table recipes --table recipes_nestings --table recipes_pos --table sessions --table shopping_list --table shopping_lists --table shopping_locations --table stock --table stock_log --table task_categories --table tasks --table user_permissions --table user_settings --table userentities --table userfield_values --table userfields --table userobjects --table users
```