# Entity Framework Core Commands

## Install Entity Framework Core CLI Tool
To install the `dotnet-ef` tool globally, use the following command:

```sh
dotnet tool install --global dotnet-ef
```

### Install a Specific Version
To install a specific version of the `dotnet-ef` tool (e.g., version 9.0), use:
```sh
dotnet tool install --global dotnet-ef --version="9.0"
```



## Managing Migrations

### Add a New Migration
To add a new migration, use the following command. Replace `Init` with the desired migration name:

```sh
dotnet ef migrations add Init  -context ShoppingBasketDbContext -o Migrations/ShoppingBasketDb
```

### Generate a Migration Script
To generate a SQL script for the migrations, use:
```sh
dotnet ef migrations script --context ShoppingBasketDbContext
```

### Updating the Database

### Apply Migrations to the Database
To apply the migrations to the database, use:

```sh
dotnet ef database update --context ShoppingBasketDbContext
```

## Package Manager Console

### Add a New Migration
To add a new migration using the Package Manager Console, use the following command. Replace `Initial-commit-Event` with the desired migration name:


```sh
add-migration Initial-commit-Event -Context ShoppingBasketDbContext -o Migrations/ShoppingBasketDb
```


### Generate a Migration Script
To generate a SQL script for the migrations, use:

```sh
Script-Migration -Context ShoppingBasketDbContext
```

### Apply Migrations to the Database
To apply the migrations to the database, use:

```sh
Update-Database -Context ShoppingBasketDbContext
```