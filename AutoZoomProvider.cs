using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Utilities;
using System;
using System.ComponentModel.Composition;

namespace AutoZoom
{
	[ContentType("code")]
	[Export(typeof(IWpfTextViewCreationListener))]
	[TextViewRole("ZOOMABLE")]
	internal class AutoZoomProvider : IWpfTextViewCreationListener
	{
		public AutoZoomProvider()
		{
		}

		private void OnTextViewGotAggregateFocus(object sender, EventArgs e)
		{
			(sender as IWpfTextView).ZoomLevel = 91;
		}

		public void TextViewCreated(IWpfTextView textView)
		{
			textView.GotAggregateFocus += new EventHandler(this.OnTextViewGotAggregateFocus);
		}
	}
}