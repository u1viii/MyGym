using FluentValidation.AspNetCore;
using MyGym.Application.Validators.Sports;
using MyGym.Persistance;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(conf =>
{
    conf.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:4200", "https://localhost:4200").AllowAnyHeader().AllowAnyMethod();
    });
});
builder.Services.AddPersistanceService();

builder.Services.AddControllers().AddFluentValidation(conf => conf.RegisterValidatorsFromAssemblyContaining<CreateSportValidator>())
    .ConfigureApiBehaviorOptions(conf => conf.SuppressModelStateInvalidFilter = true);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
