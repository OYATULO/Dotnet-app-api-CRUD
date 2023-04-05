using context;
using services;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "CORSPolicy";

builder.Services.AddCors(option=>{
    option.AddPolicy(MyAllowSpecificOrigins,
    builder=>builder.
    AllowAnyHeader().
    AllowAnyMethod().
    AllowCredentials());
    //.WithOrigins("http://localhost:3000","http://192.168.8.105:3000");}
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<dataContext>();
builder.Services.AddScoped<IServices,Services>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(

        swaggerUIOptions=>{
                    swaggerUIOptions.DocumentTitle="ASP.NET React Tutorial";
                    swaggerUIOptions.SwaggerEndpoint("/swagger/v1/swagger.json","Wep Api serving and ");
                    swaggerUIOptions.RoutePrefix= string.Empty;
                    }
    );
}

app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();

app.MapControllers();

app.Run();
