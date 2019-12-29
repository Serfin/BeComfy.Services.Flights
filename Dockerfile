FROM mcr.microsoft.com/dotnet/core/sdk:3.0
WORKDIR /app
COPY ./src/BeComfy.Services.Flights/bin/Release/netcoreapp3.0 .
ENV ASPNETCORE_URLS http://*:5005
ENV ASPNETCORE_ENVIRONMENT Release
EXPOSE 5005
ENTRYPOINT ["dotnet", "BeComfy.Services.Flights.dll"]