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

* Now to generate `swagger.json` file, go to url `https://localhost:5001/swagger/v1/swagger.json`. It should list swagger.json content. Copy the content from browser and save in new file `swagger.json` in solution directory.
* Install `swagger-codegen` package. Follow specific installation procedure based on your OS configuration. 
https://github.com/swagger-api/swagger-codegen#compatibility

* Create your client. For this example, Angular client is created `ng-client-demo` using `ng new ng-client-demo` command.
* Run below command to generate Angular client code from `swagger.json` file.

`swagger-codegen generate -i swagger.json -l typescript-angular -o ng-client-demo/backend`

It will generate models and Angular DI ready service in `backend` folder.

```
➜  backend git:(master) ✗ tree
.
├── api
│   ├── api.ts
│   └── todos.service.ts
├── api.module.ts
├── configuration.ts
├── encoder.ts
├── git_push.sh
├── index.ts
├── model
│   ├── models.ts
│   └── todoModel.ts
└── variables.ts
```

## Angular client code setup
* Install `rxjs-compat` package if required. `npm i rxjs-compat --save`
* Add `basePath` variable in `environment.ts` and `environment.prod.ts` file with REST API base path url.
* Import `HttpClientModule` module in `AppModule`
* Import `ApiModule` in `AppModule` component for using in Application and set `BASE_PATH` variable with `environment.basePath` value. All auto generated service(s) will use this variable for accessing services.
```
@NgModule({
  
  imports: [
    ApiModule
  ],
    providers: [{
    provide: BASE_PATH, useValue: environment.basePath
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
```

* You can inject auto generated services in your application component and start using its methods.

```
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'ng-client-demo';

  constructor(private service: TodosService) { }

  ngOnInit() {
    this.service.get().subscribe(allTodos => {
      console.log(allTodos);
    })
  }
}

```

Now you don't need to write Models and Services again and again for your REST API. Just start using it!