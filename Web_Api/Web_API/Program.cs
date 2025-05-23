//using Mock;
//using Repository.Entities;
//using Repository.Interface;
//using Repository.Repositories;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//builder.Services.AddScoped<IRepository<User>, UserRepository>();
//builder.Services.AddScoped<IContext, Database>();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}


//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();








using Mock;
using Repository.Entities;
using Repository.Interface;
using Repository.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRepository<Survey>, SurveyRepository>();
builder.Services.AddScoped<IRepository<Question>, QuestionRepository>();
builder.Services.AddScoped<IRepository<Answer>, AnswerRepository>();
builder.Services.AddScoped<IRepository<User>, UserRepository>();
builder.Services.AddScoped<IContext, Database>();

// 🔧 הוספת CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// 🟢 להפעיל את מדיניות ה־CORS
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
