using Microsoft.AspNetCore.Mvc;
using Zillifriends.Shared.Common;
using Zilliqa.DesktopWallet.Core;
using Zilliqa.DesktopWallet.Server.Core.Files;
using Zilliqa.DesktopWallet.WebContract;

namespace Zilliqa.DesktopWallet.WebApp.Controllers.Api
{
    [ApiController]
    [Route("api/snapshot")]
    public class SnapshotController : ControllerBase
    {
        [HttpGet("info")]
        public SnapshotInfo? GetSnapshotInfo()
        {
            Logging.LogInfo("GetSnapshotInfo()");
            return SnapshotVersionsFile.Load().Snapshots.Select(s => new SnapshotInfo
            {
                Id = s.Id,
                AppVersion = s.AppVersion,
                BlockHeight = s.BlockHeight,
                Size = s.ZipFileSize,
                TimestampUtc = s.TimestampUtc
            }).LastOrDefault();
        }

        [HttpGet("download")]
        public IActionResult GetSnapshotStream(string id)
        {
            Logging.LogInfo($"GetSnapshotStream({id})");
            var snapshotInfo = SnapshotVersionsFile.Load().Snapshots.FirstOrDefault(s => s.Id == id);
            if (snapshotInfo != null)
            {
                var zipStream = new FileInfo(DataPathBuilder.AppDataRoot.GetFilePath(snapshotInfo.ZipFilename))
                    .OpenRead();
                return File(zipStream, "application/zip", snapshotInfo.ZipFilename);
            }
            return NotFound();
        }

    }
}