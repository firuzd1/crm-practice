using Crm.BusinessLogic;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureCrmServices();

builder.Services.AddControllers();

WebApplication app = builder.Build();

app.MapControllers();

app.Run();
