using System;
using MahApps.Metro.Controls;

namespace ListBoxBindingSamle
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

		private void MetroWindow_Closed(object sender, System.EventArgs e)
		{
			if (this.DataContext is IDisposable)
				(this.DataContext as IDisposable).Dispose();
		}
	}
}
