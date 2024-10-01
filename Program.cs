using Microsoft.OpenApi.Models;

// ... existing code ...

// Add these lines in the ConfigureServices section
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "LearnFromAI API", Version = "v1" });
});

var app = builder.Build();

// Add these lines after app.Build() but before app.Run()
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LearnFromAI API v1"));
}

// ... rest of your code ...
