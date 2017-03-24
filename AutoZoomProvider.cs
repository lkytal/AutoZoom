using System;
using System.Windows;
using System.ComponentModel;
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
		const int defaultZoomLevel = 100;
		private IWpfTextView ThisTextView;

		private int GetZoomLevel()
		{
			if (AutoZoomPackage.OptionsPage != null)
			{
				return AutoZoomPackage.OptionsPage.ZoomLevel;
			}
			else
			{
				return defaultZoomLevel;
			}
		}

		private void SetZoomLevel(object sender)
		{
			if (sender is IWpfTextView wpfTextView)
			{
				System.Threading.Thread.Sleep(30);

				wpfTextView.ZoomLevel = GetZoomLevel();

				if (ThisTextView == null)
				{
					ThisTextView = sender as IWpfTextView;
				}

				RemoveEventHandler();
			}
		}

		private void RemoveEventHandler()
		{
			if (ThisTextView != null)
			{
				ThisTextView.GotAggregateFocus -= OnTextViewGotAggregateFocus;
				ThisTextView.VisualElement.Loaded -= VisualElement_Loaded;
			}

			ThisTextView = null;
		}

		private void OnTextViewGotAggregateFocus(object sender, EventArgs e)
		{
			SetZoomLevel(sender);
		}

		private void VisualElement_Loaded(object sender, RoutedEventArgs e)
		{
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
