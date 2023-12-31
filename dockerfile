FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /App

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /App

COPY --from=build-env /App/out .

COPY ./wait-for-it.sh .

RUN chmod +x ./wait-for-it.sh

CMD ["bash", "-c", "./wait-for-it.sh database:1433 -- dotnet BoardcampApiCS.dll"]