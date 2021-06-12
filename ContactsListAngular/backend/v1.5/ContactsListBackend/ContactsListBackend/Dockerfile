#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/aspnet:3.1
COPY bin/Release/netcoreapp3.1 app/
WORKDIR /app
ENTRYPOINT ["dotnet", "ContactsListBackend.dll"]