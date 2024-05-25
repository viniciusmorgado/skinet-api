{ pkgs ? import <nixpkgs> { } }:

{
  channel = "stable-23.11";
  services.docker.enable = true;

  packages = [
    pkgs.dotnet-sdk_8
    pkgs.docker
    pkgs.docker-compose
  ];

  env = { };
  idx = {
    extensions = [
      "ms-dotnettools.vscode-dotnet-runtime"
      "PKief.material-icon-theme"
      "ms-azuretools.vscode-docker"
      "ms-kubernetes-tools.vscode-kubernetes-tools"
      "redhat.vscode-yaml"
    ];

    previews = {
      enable = true;
      previews = { };
    };

    workspace = {
      onCreate = { };
      onStart = { };
    };
  };
}
