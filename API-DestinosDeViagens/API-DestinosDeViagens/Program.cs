using API_DestinosDeViagens.Data;
using API_DestinosDeViagens.Repository.RepositoryDestination;
using API_DestinosDeViagens.Repository.RepositoryRoadTrip;
using API_DestinosDeViagens.Repository.RepositoryTestimonial;
using API_DestinosDeViagens.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Services in the container.
#region mapper config
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
#endregion

#region db conection
var connectionString = builder.Configuration.GetConnectionString("DestinosDeViagensConnection");

builder.Services.AddDbContext<DestinosdeViagensContext>(opts =>
    opts.UseLazyLoadingProxies().UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);
#endregion

builder.Services.AddControllers();

#region Config Injection dependencies (Service and Repository)

//Testimonial config
builder.Services.AddScoped<TestimonialService>();
builder.Services.AddScoped<ITestimonialRepository, TestimonialRepository>();

//Destination config
builder.Services.AddScoped<DestinationService>();
builder.Services.AddScoped<IDestinationRepository, DestinationRepository>();

//RoadTrip
builder.Services.AddScoped<RoadTripService>();
builder.Services.AddScoped<IRoadTripRepository, RoadTripRepository>();

#endregion

#region config Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "_myAllowSpecificOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});
#endregion



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
