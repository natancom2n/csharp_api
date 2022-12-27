var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//endpoints
app.MapGet("/", () => "Hello World 3!");
app.MapGet("/user", () => "Natan");
app.MapPost("/user", () => new { Name = "Natan Alves", Age = 40 });

//modification Header and returno anything on the body
app.MapGet("/Add", (HttpResponse response) =>
{
    response.Headers.Add("Teste", "Natan Alves");
    return new 
    {
        Name = "Natan Alves",
        Age = 40
    };
});  

app.MapPost("/saveprod", (Product product) =>
{
    return product.Code + " - " + product.Name;
});

// send the data throught url = Query
//api.app.com/users?datastart={date}&dataend={date}

// send the data throught url = Route
//api.app.com/users/{code}
app.Run();

public class Product{
    public string Code { get; set; }
    public string Name { get; set; }
}
