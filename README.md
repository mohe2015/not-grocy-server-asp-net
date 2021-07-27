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
```
dotnet ef dbcontext scaffold "Data Source=hello.db" Microsoft.EntityFrameworkCore.Sqlite --data-annotations --context NotGrocyContext --context-dir Data --output-dir Models --namespace NotGrocy.Models --context-namespace NotGrocy --force --verbose --table api_keys --table batteries --table battery_charge_cycles --table chores --table chores_log --table equipment --table locations --table meal_plan
```