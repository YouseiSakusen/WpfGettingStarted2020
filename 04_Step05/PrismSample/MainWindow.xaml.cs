using System;
using MahApps.Metro.Controls;

namespace PrismSample
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : MetroWindow
	{
		public MainWindow()
			=> InitializeComponent();

		///// <summary>Closedイベントハンドラ。</summary>
		///// <param name="sender">イベントのソース。</param>
		///// <param name="e">イベントデータを格納しているEventArgs。</param>
		//private void MetroWindow_Closed(object sender, System.EventArgs e)
		//	=> (this.DataContext as IDisposable)?.Dispose();
	}
}
