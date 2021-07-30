{
  description = "not-grocy-server-asp-net's development flake";

  inputs.nixpkgs.url = "github:NixOS/nixpkgs/nixos-unstable";
  inputs.flake-utils.url = "github:numtide/flake-utils";

  outputs = { self, nixpkgs, flake-utils }:
    flake-utils.lib.eachDefaultSystem
      (system:
        let pkgs = nixpkgs.legacyPackages.${system}; in
        {
          devShell = pkgs.mkShell {
            packages = [
              (with pkgs.dotnetCorePackages; combinePackages [
                aspnetcore_5_0
                sdk_5_0
                net_5_0
              ])
              pkgs.mono
              #pkgs.vscode
              (pkgs.vscode-with-extensions.override {
                vscodeExtensions = (with pkgs.vscode-extensions; [
                  ms-dotnettools.csharp
                  bbenoist.Nix
                ]);
              })
              pkgs.msbuild
              pkgs.docker-compose
              pkgs.sqlitebrowser
            ];
          };
        }
      );
}
