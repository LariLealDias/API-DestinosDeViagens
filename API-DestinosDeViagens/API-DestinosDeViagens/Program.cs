using API_DestinosDeViagens.Data;
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


#region Config Injection dependencies (Service and Repository)
builder.Services.AddScoped<TestimonialService>();
builder.Services.AddScoped<ITestimonialRepository, TestimonialRepository>();
#endregion
builder.Services.AddControllers();


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
