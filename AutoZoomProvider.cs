using System;
using System.Windows;
using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Utilities;

namespace AutoZoom
{
	[ContentType("code")]
	[Export(typeof(IWpfTextViewCreationListener))]
	[TextViewRole("ZOOMABLE")]
	internal class AutoZoomProvider : IWpfTextViewCreationListener
	{
		private IWpfTextView ThisTextView;

		private void SetZoomLevel(object sender)
		{
			System.Threading.Thread.Sleep(30);

			if (sender is IWpfTextView wpfTextView) wpfTextView.ZoomLevel = 91;
		}

		private void OnTextViewGotAggregateFocus(object sender, EventArgs e)
		{
			ThisTextView.GotAggregateFocus -= OnTextViewGotAggregateFocus;

			SetZoomLevel(sender);
		}

		private void VisualElement_Loaded(object sender, RoutedEventArgs e)
		{
			ThisTextView.VisualElement.Loaded -= VisualElement_Loaded;

			SetZoomLevel(sender);
		}

		public void TextViewCreated(IWpfTextView textView)
		{
			ThisTextView = textView;
			textView.VisualElement.Loaded += VisualElement_Loaded;
			textView.GotAggregateFocus += OnTextViewGotAggregateFocus;
		}
	}
}