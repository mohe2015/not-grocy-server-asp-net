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