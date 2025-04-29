@echo off

REM Script to remove migrations for Event Catalog, Ordering, Discount, and Shopping Basket services

REM Event Catalog Service
cd src\Eventick.Services.EventCatalog
if exist dotnet-ef (
    dotnet ef migrations remove --context EventCatalogDbContext
) else (
    echo "dotnet-ef tool is not installed. Please install it using 'dotnet tool install --global dotnet-ef'."
)

REM Ordering Service
cd ..\Eventick.Services.Ordering
if exist dotnet-ef (
    dotnet ef migrations remove --context OrderDbContext
) else (
    echo "dotnet-ef tool is not installed. Please install it using 'dotnet tool install --global dotnet-ef'."
)

REM Discount Service
cd ..\Eventick.Services.Discount
if exist dotnet-ef (
    dotnet ef migrations remove --context DiscountDbContext
) else (
    echo "dotnet-ef tool is not installed. Please install it using 'dotnet tool install --global dotnet-ef'."
)

REM Shopping Basket Service
cd ..\Eventick.Services.ShoppingBasket
if exist dotnet-ef (
    dotnet ef migrations remove --context ShoppingBasketDbContext
) else (
    echo "dotnet-ef tool is not installed. Please install it using 'dotnet tool install --global dotnet-ef'."
)

REM Return to the parent directory
cd ..\..\..