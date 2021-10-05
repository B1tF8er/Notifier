# Main Project #

## How To Build And Run ##

> Using the `dotnet` CLI

```powershell
    dotnet restore ./Notifier
    dotnet build ./Notifier -c Release
    dotnet run -p ./Notifier -c Release --no-build
```

> Using the `docker` CLI

```powershell
    docker build -t notifier ./Notifier
    docker run --rm notifier
```
