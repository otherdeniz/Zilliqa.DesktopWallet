using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zilliqa.DesktopWallet.Core.ZilligraphDb;

namespace Zilliqa.DesktopWallet.Core
{
    public class ApplicationRuntimeManager
    {
        public static ApplicationRuntimeManager Instance { get; } = new ApplicationRuntimeManager();

        public ZilliqaBlockchainDbRepository ZilliqaDbRepository { get; } = new ZilliqaBlockchainDbRepository();

        public void StartupBackgroundTasks()
        {

        }

        public void StopBackgroundTasks()
        {
            ZilliqaDbRepository.Database.Dispose();
        }
    }
}
