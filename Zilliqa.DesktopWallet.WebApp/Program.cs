using Zillifriends.Shared.Common;
using Zilliqa.DesktopWallet.Core;
using Zilliqa.DesktopWallet.Server.Core.Services;

// setup ZilliqaDesktopWallet basic services
var rootPathEnvVariable = Environment.GetEnvironmentVariable("ZILSERVERPATH");
var rootPath = string.IsNullOrEmpty(rootPathEnvVariable)
    ? "ZilliqaDesktopWallet"
    : rootPathEnvVariable;
DataPathBuilder.Setup(Path.Combine(rootPath, "Server-Mainnet"), true);
Logging.Setup(Path.Combine(DataPathBuilder.UserDataRoot.FullPath, "Log"));

var archivePathEnvVariable = Environment.GetEnvironmentVariable("ZILARCHIVEPATH");
if (!string.IsNullOrEmpty(archivePathEnvVariable))
{
    SnapshotService.Instance.ArchiveRootFolder = new DataPathBuilder(archivePathEnvVariable);
}

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
