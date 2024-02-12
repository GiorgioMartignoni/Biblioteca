//MODIFICA
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Gestionale_Libreria.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Database");
builder.Services.AddDbContext<Database>(option =>
option.UseSqlite(connectionString));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSqlite<Database>(connectionString);

//MODIFICA
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Gestionale Libreria API",
        Description = "Sito web della libreria di Busto Arsizio",
        Version = "v1"
    });
});


var app = builder.Build();

//MODIFICA
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Gestionale Libreria API V1");
});


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseStaticFiles();

app.MapControllers();





//MODIFICA
app.MapGet("/libri", async (Database db) => await db.Libri.ToListAsync());
//MODIFICA
app.MapGet("/libro/{id}", async (Database db, int id) => await db.Libri.FindAsync(id));
//MODIFICA
app.MapPost("/libro", async (Database db, Libro libro) =>
{
    await db.Libri.AddAsync(libro);
    await db.SaveChangesAsync();
    return Results.Created($"/libro/{libro.id}", libro);
});
//MODIFICA
app.MapPut("/libro/{id}", async (Database db, Libro newLibro, int id) =>
{
    var libro = await db.Libri.FindAsync(id);
    if (libro is null) return Results.NotFound();

    libro.id = newLibro.id;
    libro.titolo = newLibro.titolo;
    libro.prestito = newLibro.prestito;
    libro.idGenere = newLibro.idGenere;
    libro.idScaffale = newLibro.idScaffale;

    await db.SaveChangesAsync();
    return Results.NoContent();
});
//MODIFICA
app.MapDelete("/libro/{id}", async (Database db, int id) =>
{
    var libro = await db.Libri.FindAsync(id);
    if (libro is null)
    {
        return Results.NotFound();
    }
    db.Libri.Remove(libro);
    await db.SaveChangesAsync();
    return Results.Ok();
});





//MODIFICA
app.MapGet("/scaffale", async (Database db) => await db.Libreria.ToListAsync());
//MODIFICA
app.MapGet("/scaffale/{id}", async (Database db, int id) => await db.Libreria.FindAsync(id));
//MODIFICA
app.MapPost("/scaffale", async (Database db, Scaffale scaffale) =>
{
    await db.Libreria.AddAsync(scaffale);
    await db.SaveChangesAsync();
    return Results.Created($"/scaffale/{scaffale.id}", scaffale);
});
//MODIFICA
app.MapPut("/scaffale/{id}", async (Database db, Scaffale newScaffale, int id) =>
{
    var scaffale = await db.Libreria.FindAsync(id);
    if (scaffale is null) return Results.NotFound();

    scaffale.id = newScaffale.id;
    scaffale.code = newScaffale.code;
 
    await db.SaveChangesAsync();
    return Results.NoContent();
});
//MODIFICA
app.MapDelete("/scaffale/{id}", async (Database db, int id) =>
{
    var scaffale = await db.Libri.FindAsync(id);
    if (scaffale is null)
    {
        return Results.NotFound();
    }
    db.Libri.Remove(scaffale);
    await db.SaveChangesAsync();
    return Results.Ok();
});




//MODIFICA
app.MapGet("/genere", async (Database db) => await db.Libri.ToListAsync());
//MODIFICA
app.MapGet("/genere/{id}", async (Database db, int id) => await db.Libri.FindAsync(id));
//MODIFICA
app.MapPost("/genere", async (Database db, Genere genere) =>
{
    await db.Generi.AddAsync(genere);
    await db.SaveChangesAsync();
    return Results.Created($"/genere/{genere.id}", genere);
});
//MODIFICA
app.MapPut("/genere/{id}", async (Database db, Genere newGenere, int id) =>
{
    var genere = await db.Generi.FindAsync(id);
    if (genere is null) return Results.NotFound();

    genere.id = newGenere.id;
    genere.descrizione = newGenere.descrizione;
   
    await db.SaveChangesAsync();
    return Results.NoContent();
});
//MODIFICA
app.MapDelete("/genere/{id}", async (Database db, int id) =>
{
    var genere = await db.Libri.FindAsync(id);
    if (genere is null)
    {
        return Results.NotFound();
    }
    db.Libri.Remove(genere);
    await db.SaveChangesAsync();
    return Results.Ok();
});




app.Run();
