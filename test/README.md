# Test Project #

## How To Build And Test ##

> Using the `dotnet` CLI

```powershell
    dotnet restore ./Notifier.Tests
    dotnet build ./Notifier.Tests -c Release
    dotnet test ./Notifier.Tests -c Release --no-build
```
