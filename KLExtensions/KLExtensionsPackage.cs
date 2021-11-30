using Microsoft.VisualStudio.Shell;
using System;
using System.Runtime.InteropServices;
using System.Threading;
using Task = System.Threading.Tasks.Task;

namespace KLExtensions
{
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [Guid(PackageGuids.guidPackageString)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    public sealed class KLExtensionsPackage : AsyncPackage
    {
        protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            await this.JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);
            await RemoveCommentCommand.InitializeAsync(this);
            await RemoveRegionsCommand.InitializeAsync(this);
        }
    }
}
