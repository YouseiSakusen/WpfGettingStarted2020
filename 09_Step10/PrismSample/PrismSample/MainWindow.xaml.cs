using System;
using System.Windows;
using MahApps.Metro.Controls;

namespace PrismSample
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : MetroWindow
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void MetroWindow_Closed(object sender, EventArgs e)
		{
			if (this.DataContext is IDisposable)
				(this.DataContext as IDisposable)?.Dispose();
		}
	}
}
