using Karkathamizha.API.Common;
using Karkathamizha.API.IService.Common;
using Karkathamizha.API.Middlewares;
using Karkathamizha.API.Service.ServiceConfiguration;
using KarkaThamizha.API.Repository.SQLObject;
using Microsoft.Extensions.Caching.Memory;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<ICurrentSession, CurrentSession>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Cors
builder.Services.AddCors(x => {
    x.AddPolicy("KarkaPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:5173,http://localhost:5174")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
    });
});

// configure strongly typed settings object
builder.Services.Configure<ConnectionManager>(builder.Configuration.GetSection("ConnectionManager"));

builder.Services.AddHttpContextAccessor();
//builder.Services.AddScoped<ModelValidationAttribute>();

//Serilog
var _logger = new LoggerConfiguration()
            .ReadFrom.Configuration(builder.Configuration)
            .Enrich.FromLogContext()
            .CreateBootstrapLogger();
            //.CreateLogger();            
builder.Host.UseSerilog(_logger);

builder.Services.AddAuthentication(builder.Configuration);
builder.Services.AddServices(builder.Configuration);
builder.Services.AddSession();
builder.Services.AddDistributedMemoryCache();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseDeveloperExceptionPage();
    app.UseExceptionHandler("/Home/Error");
}

var cacheoption = new MemoryCacheEntryOptions()
{
    AbsoluteExpiration = DateTime.Now.AddMinutes(5)
};

//_cache.Set(cacheKey, products, cacheOptions);

app.UseCors("KarkaPolicy");
app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.UseSerilogRequestLogging();
app.MapControllers();
app.UseMiddleware<ExceptionHandling>();
app.Run();
