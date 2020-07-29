#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-nanoserver-1903 AS base
WORKDIR /app
EXPOSE 80
ENV ConnectionStrings:MagsConnectionMssql="Server=192.168.43.239,1433;Initial Catalog=AllInOne;Persist Security Info=False;User ID=sa;Password=March@123;MultipleActiveResultSets=False;TrustServerCertificate=False;Connection Timeout=30;"

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-nanoserver-1903 AS build
WORKDIR /src
COPY ["AllInOne/AllInOne.csproj", "AllInOne/"]
COPY ["AllInOne.API/AllInOne.API.csproj", "AllInOne.API/"]
COPY ["AllInOne.Data/AllInOne.Data.csproj", "AllInOne.Data/"]
RUN dotnet restore "AllInOne/AllInOne.csproj"
COPY . .
WORKDIR "/src/AllInOne"
RUN dotnet build "AllInOne.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AllInOne.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AllInOne.dll"]