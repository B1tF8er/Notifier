FROM mcr.microsoft.com/dotnet/nightly/sdk:5.0
WORKDIR /app

# copy csproj and restore as distinct layers
COPY ./*.csproj ./
#RUN dotnet restore

# copy and build everything else
COPY ./ ./
RUN dotnet publish -c Release -o out
ENTRYPOINT ["dotnet", "out/Notifier.dll"]
