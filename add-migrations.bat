@echo off

REM Script to add migrations for Event Catalog, Ordering, Discount, and Shopping Basket services

REM Event Catalog Service
cd src\Eventick.Services.EventCatalog
if exist dotnet-ef (
    dotnet ef migrations add Init --context EventCatalogDbContext -o Migrations/EventCatalogDb
) else (
    echo "dotnet-ef tool is not installed. Please install it using 'dotnet tool install --global dotnet-ef'."
)

REM Ordering Service
cd ..\Eventick.Services.Ordering
if exist dotnet-ef (
    dotnet ef migrations add Init --context OrderDbContext -o Migrations/OrderDb
) else (
    echo "dotnet-ef tool is not installed. Please install it using 'dotnet tool install --global dotnet-ef'."
)

REM Discount Service
cd ..\Eventick.Services.Discount
if exist dotnet-ef (
    dotnet ef migrations add Init --context DiscountDbContext -o Migrations/DiscountDb
) else (
    echo "dotnet-ef tool is not installed. Please install it using 'dotnet tool install --global dotnet-ef'."
)

REM Shopping Basket Service
cd ..\Eventick.Services.ShoppingBasket
if exist dotnet-ef (
    dotnet ef migrations add Init --context ShoppingBasketDbContext -o Migrations/ShoppingBasketDb
) else (
    echo "dotnet-ef tool is not installed. Please install it using 'dotnet tool install --global dotnet-ef'."
)

REM Return to the parent directory
cd ..\..\..