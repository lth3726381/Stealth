using Squirrel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Stealth.WPF.Util
{
    public class Updater
    {
        public string updateUrl;

        //public UpdateManager mgr;

        public Updater()
        {
            updateUrl = Properties.Settings.Default.UpdateUrl;
        }

        public async Task UpdateApp()
        {
            UpdateManager mgr = null;
            //using (var mgr = await UpdateManager.GitHubUpdateManager(updateUrl))
            try
            {
                mgr = new UpdateManager(updateUrl);
                {
                    SquirrelAwareApp.HandleEvents(
                                      onInitialInstall: v => mgr.CreateShortcutForThisExe(),
                                      onAppUpdate: v => mgr.CreateShortcutForThisExe(),
                                      onAppUninstall: v => mgr.RemoveShortcutForThisExe(),
                                      onFirstRun: () => { });
                    var updates = await mgr.CheckForUpdate();
                    if (updates.ReleasesToApply.Any())
                    {
                        var lastVersion = updates.ReleasesToApply.OrderBy(x => x.Version).Last();
                        await mgr.DownloadReleases(new[] { lastVersion });
                        await mgr.ApplyReleases(updates);
                        await mgr.UpdateApp();
                        MessageBox.Show("The application has been updated - please close and restart.");
                    }
                    else
                    {
                        MessageBox.Show("No Updates are available at this time.");
                    }
                }
            }
            catch (Exception e)
            { }
            finally
            {
                if (mgr != null)
                    mgr.Dispose();
            }
        }
    }
}
