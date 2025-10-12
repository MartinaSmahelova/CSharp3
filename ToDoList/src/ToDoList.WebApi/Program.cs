var builder = WebApplication.CreateBuilder(args);
{
    //Configure Dependency injection
    builder.Services.AddControllers();
}

var app = builder.Build();
{
    //Configure Middleware (HTTP request pipeline)
    app.MapControllers();
}

//app.MapGet("/", () => "Hello World!");
//app.MapGet("/pozdrav/{jmeno}", (string jmeno) => $"Hello {jmeno}!");
//app.MapGet("/secti/{a:int}/{b:int}", (int a, int b) => $"Vysledek {a} + {b} = {a + b}!");
//app.MapGet("/NazdarSvete", () => "AHoj Svete");

app.Run();
