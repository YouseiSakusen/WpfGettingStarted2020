using System;
using System.Windows;
using Microsoft.Xaml.Behaviors;

namespace PrismSample
{
	public class DataContextDisposeAction : TriggerAction<FrameworkElement>
    {
		protected override void Invoke(object parameter)
			=> (this.AssociatedObject?.DataContext as IDisposable)?.Dispose();
	}
}
