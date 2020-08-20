# Identity Server
start-process powershell.exe -argument `
  '-nologo
    -noprofile
    -executionpolicy bypass
    -NoExit
    -command dapr run `
      --app-id identityserver `
      --app-port 5000 `
      --log-level debug `
      dotnet run dotnet `
        -- -p src\Identity\IdentityServerAspNetIdentity.csproj'
Start-Sleep -Seconds 2

# Store Api
start-process powershell.exe -argument `
  '-nologo
    -noprofile
    -executionpolicy bypass
    -command dapr run `
      --app-id storeapi `
      --app-port 5020 `
      --log-level debug `
      dotnet run dotnet `
        -- -p src\Store\ModernArchitectureShop.StoreApi\ModernArchitectureShop.StoreApi.csproj'
Start-Sleep -Seconds 2

# Basket Api
start-process powershell.exe -argument `
  '-nologo
    -noprofile
    -executionpolicy bypass
    -command dapr run `
      --app-id basketapi `
      --app-port 5030 `
      --log-level debug `
      dotnet run dotnet `
        -- -p src/Basket/ModernArchitectureShop.BasketApi/ModernArchitectureShop.BasketApi.csproj'
Start-Sleep -Seconds 5

# BlazorUI
start-process powershell.exe -argument `
  '-nologo
    -noprofile
    -executionpolicy bypass
    -command dapr run `
      --app-id blazorui `
      --app-port 5010  `
      --log-level debug `
      dotnet run dotnet `
        -- -p src/UI/ModernArchitectureShop.BlazorUI.csproj'