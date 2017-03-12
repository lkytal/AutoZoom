using System.ComponentModel;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell;

namespace AutoZoom
{
	[ClassInterface(ClassInterfaceType.AutoDual)]
	public class OptionsPage : DialogPage
	{
		private int zoomLevel = 91;

		[Category("General")]
		[Description("Setup zoom level. Take effect after reopen editor")]
		[DisplayName("Default Zoom Level in percent")]
		public int ZoomLevel
		{
			get
			{
				return zoomLevel;
			}
			set
			{
				zoomLevel = value;
			}
		}
	}
}
