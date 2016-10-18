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
		private bool Changed = false;
		private IWpfTextView ThisTextView = null;

		private void OnTextViewGotAggregateFocus(object sender, EventArgs e)
		{
			if (!Changed)
			{
				Changed = true;

				IWpfTextView wpfTextView = sender as IWpfTextView;
				if (wpfTextView != null) wpfTextView.ZoomLevel = 91;

				ThisTextView.GotAggregateFocus -= this.OnTextViewGotAggregateFocus;
			}
		}

		public void TextViewCreated(IWpfTextView textView)
		{
			ThisTextView = textView;
			textView.VisualElement.Loaded += VisualElement_Loaded;
			textView.GotAggregateFocus += this.OnTextViewGotAggregateFocus;
		}

		private void VisualElement_Loaded(object sender, RoutedEventArgs e)
		{
			System.Threading.Thread.Sleep(50);

			IWpfTextView wpfTextView = sender as IWpfTextView;
			if (wpfTextView != null) wpfTextView.ZoomLevel = 91;

			ThisTextView.VisualElement.Loaded -= VisualElement_Loaded;
		}
	}
}