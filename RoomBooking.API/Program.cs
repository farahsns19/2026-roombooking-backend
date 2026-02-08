using Microsoft.EntityFrameworkCore;
using RoomBooking.API.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();

// Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=RoomBooking.db")); // Artinya db akan dibuat di dalam file RoomBooking.db
var app = builder.Build();

// Swagger middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    if (!db.PeminjamanRuangan.Any())
    {
        db.PeminjamanRuangan.Add(new RoomBooking.API.Models.PeminjamanRuangan
        {
            NamaPeminjam = "Farah Hasna",
            NRP = "3124600053",
            Ruangan = "HH-301",
            Tanggal = DateOnly.FromDateTime(DateTime.Now.AddDays(1)),
            JamMulai = "08:00",
            JamSelesai = "10:00",
            Keperluan = "UKM Karate",
            Status = "Menunggu"
        });

        db.SaveChanges();
    }
}
app.Run();
