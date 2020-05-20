<img align="left" width="116" height="116" src=".github/icon.png" />

# AspNetCore 2.1 Web API Layered Architecture
![.Net Core](https://travis-ci.com/rgulersen/aspnetcore-basic-architecture.svg?token=4sxkj6x5xLpp5vqQfYQk&branch=master)
___

## Database Initilaze (Code first approach)
```console
add-migration <migration name>
update-database
```
## Technologies & Integration
*   .NET Core 2.1
*    ASP.NET Core 2.1
*   Entity Framework Core 
*   Autofac (IoC container for Microsoft .NET)
*   AutoMapper
*   ASP.NET Core Identity 
*   Jwt Bearer 
*   Fluent Validation
*   Swashbuckle Swagger
### File structure
```
    |-- Program.cs
    |-- Startup.cs
    |-- Controllers
    |   |-- AuthenticationController.cs
    |   |-- ProductsController.cs
    |-- Infrastructure
    |   |-- AutoFac
    |   |   |-- RepositoryModule.cs
    |   |   |-- ServiceModule.cs
    |   |   |-- ValidationModule.cs
    |   |-- AutoMapper
    |   |   |-- ProductProfile.cs
    |   |-- ConfigurationModels
    |   |   |-- AutofacModuleConfiguration.cs
    |   |   |-- JwtTokenConfiguration.cs
    |   |   |-- SwaggerConfiguration.cs
    |   |-- Extensions
    |   |   |-- AutofacConfigurationServiceExtensions.cs
    |   |   |-- AutoMapperConfigurationServiceExtensions.cs
    |   |   |-- ConfigurationServiceExtensions.cs
    |   |   |-- DatabaseConfigurationServiceExtensions.cs
    |   |   |-- FluentValidationConfigurationServiceExtension.cs
    |   |   |-- IdentityConfigurationServiceExtension.cs
    |   |   |-- JwtConfigurationServiceExtensions.cs
    |   |   |-- SwaggerConfigurationServiceExtension.cs
    |   |-- Filters
    |       |-- ValidationFilter.cs
    |-- Model
    |   |-- BaseEntity.cs
    |   |-- Product.cs
    |-- Properties
    |   |-- launchSettings.json
    |-- Repositories
    |   |-- DatabaseContext.cs
    |   |-- DataSeeder.cs
    |   |-- IProductRepository.cs
    |   |-- IRepository.cs
    |   |-- ProductRepository.cs
    |   |-- Repository.cs
    |-- Services
    |   |-- IProductService.cs
    |   |-- IService.cs
    |   |-- IUserService.cs
    |   |-- ProductService.cs
    |   |-- Service.cs
    |   |-- UserService.cs
    |-- Validators
    |   |-- ProductViewModelValidator.cs
    |   |-- UserLoginViewModelValidator.cs
    |   |-- UserRegisterViewModelValidator.cs
    |-- ViewModel
    |   |-- ProductViewModel.cs
    |   |-- UserLoginViewModel.cs
    |   |-- UserManagerResponseViewModel.cs
    |   |-- UserRegisterViewModel.cs
``` 
[.Net Core 3.1 version](https://github.com/rgulersen/aspnetcore-web-api-architecture).
#### Thanks ([mddir](https://www.npmjs.com/package/mddir), [Jwt tutorial](https://bit.ly/2WZXBsN))
