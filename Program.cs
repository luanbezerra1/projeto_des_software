using Microsoft.EntityFrameworkCore;
using TrabalhoApi;

var builder = WebApplication.CreateBuilder(args);

var conn = builder
            .Configuration
            .GetConnectionString("ConnPadrao");

builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(conn, ServerVersion.AutoDetect(conn)));

//Criando politica de Cors
builder.Services.AddCors(options =>{
    options.AddPolicy("Liberado", policy => {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddControllers(); //Habilitar controllers MVC
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection(); //Força o redirecionado para https
app.UseCors("Liberado"); //Aplica a politica de Cors
app.UseAuthorization();
app.MapControllers(); // Publica as rotas dos controlelrs

app.Run();

