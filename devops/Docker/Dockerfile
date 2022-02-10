FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS build
EXPOSE 80
WORKDIR /app
COPY ./out .

#Config ENVS
ENV DB_SERVER=localhost 
ENV DB_USERNAME=sa
ENV DB_PASSWORD=Admin123 
ENV DB_PORT=1433 
ENV DB_DATABASE=ProfileManagementDB
ENV GRPC_PORT=666

ENTRYPOINT ["dotnet", "Infrastructure.dll"]