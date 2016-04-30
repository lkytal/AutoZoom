using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Utilities;
using System;
using System.Windows;
using System.ComponentModel.Composition;

namespace AutoZoom
{
	[ContentType("code")]
	[Export(typeof(IWpfTextViewCreationListener))]
	[TextViewRole("ZOOMABLE")]
	internal class AutoZoomProvider : IWpfTextViewCreationListener
	{
		IWpfTextView TextView;
		public AutoZoomProvider()
		{
		}

		private void OnTextViewGotAggregateFocus(object sender, EventArgs e)
		{
			(sender as IWpfTextView).ZoomLevel = 91;
		}

		public void TextViewCreated(IWpfTextView textView)
		{
			this.TextView = textView;

			textView.VisualElement.Loaded += VisualElement_Loaded;
			textView.GotAggregateFocus += new EventHandler(this.OnTextViewGotAggregateFocus);
		}

		private void VisualElement_Loaded(object sender, RoutedEventArgs e)
		{
			this.TextView.ZoomLevel = 91;
		}
	}
}