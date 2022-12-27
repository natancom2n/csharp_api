using Microsoft.AspNetCore.Mvc;

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
app.MapGet("/getproduct", ([FromQuery] string dateStart, [FromQuery] string dateEnd)=> {
    return dateStart + " + " + dateEnd;
});
//url exemplo: http://localhost:3000/getproduct?datestart=x&dateend=y


// send the data throught url = Route
//api.app.com/users/{code}
app.MapGet("/getproduct{code}", ([FromRoute]string code)=> {
    return code;
});
//url exemplo: http://localhost:3000/getproduct{x}


app.MapGet("/getproducts", (HttpRequest req) =>  {

    return req.Headers["code"].ToString();
});


app.Run();

public class ProductRepo{
    public List<Product> Products  { get; set; }
    public void Add(Product product){
        if (Products == null )
            Products = new List<Product>();
        
        Products.Add(product); 
    }
    public Product GetBy(string code){
        return Products.First(p => p.Code == code);
    }

}

public class Product{
    public string Code { get; set; }
    public string Name { get; set; }
}
