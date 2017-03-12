using System;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

namespace AutoZoom
{
	[PackageRegistration(UseManagedResourcesOnly = true)]
	[InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)] // Info on this package for Help/About
	[Guid(AutoZoomPackage.PackageGuidString)]
	[ProvideAutoLoad(UIContextGuids80.NoSolution)]
	[ProvideOptionPage(typeof(OptionsPage), "AutoZoom", "General", 0, 0, true)]
	[SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "pkgdef, VS and vsixmanifest are valid VS terms")]
	public sealed class AutoZoomPackage : Package
	{
		public const string PackageGuidString = "ce0d448c-39ad-453e-aa64-1e250e43f594";

		public static OptionsPage OptionsPage;

		protected override void Initialize()
		{
			base.Initialize();

			OptionsPage = base.GetDialogPage(typeof(OptionsPage)) as OptionsPage;
		}
	}
}
