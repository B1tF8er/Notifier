# Notifier #

Notifications project to show S.O.L.I.D. and TDD principles in C#.

The main idea of this project is to show how these concepts are used together
to help us to write code that is easier to maintain, extend and test.

## Requirements ##

* .NET 5 SDK installed
* The IDE or Text Editor of your choice

## How To Run And Test ##

### Build And Run ###

> Using the `dotnet` CLI

```powershell
    dotnet restore ./src/Notifier
    dotnet build ./src/Notifier -c Release
    dotnet run -p ./src/Notifier -c Release --no-build
```

> Using the `docker` CLI

```powershell
    docker build -t notifier ./src/Notifier
    docker run --rm notifier
```

### Build And Test ###

> Using the `dotnet` CLI

```powershell
    dotnet restore ./test/Notifier.Tests
    dotnet build ./test/Notifier.Tests -c Release
    dotnet test ./test/Notifier.Tests -c Release --no-build --collect:"XPlat Code Coverage"
```
