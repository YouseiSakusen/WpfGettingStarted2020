using System;
using System.Windows.Input;

namespace PlaneWpfApp
{
	public class ClickCommand : ICommand
	{
		/// <summary>コマンドが実行可能かが変わった場合に発火するイベント。</summary>
		public event EventHandler CanExecuteChanged
		{
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}

		/// <summary>コマンドが実行可能かを返します。</summary>
		/// <param name="parameter">XAML上で'CommandParameter'に指定した値. default=null.</param>
		/// <returns>実行可能な場合はtrue、それ以外はfalse。</returns>
		public bool CanExecute(object parameter)
			=> !string.IsNullOrEmpty(parameter as string);

		/// <summary>コマンドを実行します。</summary>
		/// <param name="parameter">コマンドのパラメータを表すobject。</param>
		public void Execute(object parameter)
			// コマンドで実行する処理を書く（現在は未実装）
			=> throw new NotImplementedException();
	}
}
