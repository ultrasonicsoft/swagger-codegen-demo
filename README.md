# Generate client code from Swagger file

## REST API setup

* This demo is built using .NET Core 2.2 version for building REST API. But you can use any other language/framework as long as you can generate OpenAPI/Swagger file from it.

* Add `Swashbuckle.AspNetCore` package for generating OpenAPI information
* In `startup.cs` file update `ConfigureServices()` method with below code:
```
services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "Demo API",
                    Version = "v1",
                    Description = "Demo API for swagger code generation",
                });
            });
```

* In `startup.cs` file update `Configure()` method with below code:
```
app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Crowd Analysts API V1");
            });
```
* Run project and navigate to `https://localhost:5001/swagger` URL and it will show your swagger API.