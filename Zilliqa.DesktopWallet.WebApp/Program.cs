using Zillifriends.Shared.Common;
using Zilliqa.DesktopWallet.Core;

// setup ZilliqaDesktopWallet basic services
DataPathBuilder.Setup(Path.Combine("ZilliqaDesktopWallet", "Server-Mainnet"), true);
Logging.Setup(Path.Combine(DataPathBuilder.UserDataRoot.FullPath, "Log"));

// build WebApplication
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// build app
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// start app
app.Run();
