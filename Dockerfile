

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ENV srcdir "RazorPageLeifExample"
ENV csproj "RazorPageLeifExample.csproj"
WORKDIR /src
COPY $srcdir/$csproj .
# install project dependencies before copying altered source code 
# to allow the image to build from cache to this point
RUN dotnet restore $csproj
COPY $srcdir .
RUN dotnet build $csproj -c Release -o /app/build
RUN dotnet publish $csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine AS final
ENV ASPNETCORE_URLS=http://*:3001
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 3001
ENTRYPOINT ["dotnet", "RazorPageLeifExample.dll"]
