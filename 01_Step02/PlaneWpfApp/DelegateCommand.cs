using System;
using System.Windows.Input;

namespace PlaneWpfApp
{
	/// <summary>Commandの実行をVMに委譲するためのCommand。</summary>
	public class DelegateCommand : ICommand
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
			=> this.canExecute();

		/// <summary>コマンドを実行します。</summary>
		/// <param name="parameter">コマンドのパラメータを表すobject。</param>
		public void Execute(object parameter)
			=> this.executeCommand();

		private Func<bool> canExecute = null;
		private Action executeCommand = null;

		/// <summary>コンストラクタ。</summary>
		/// <param name="execCmd">実行するAction。</param>
		public DelegateCommand(Action execCmd) : this(execCmd, () => true) { }

		/// <summary>
		/// コンストラクタ。
		/// </summary>
		/// <param name="execCmd">実行するAction。</param>
		/// <param name="canExec">実行可能かを判別するFunc<bool>。</param>
		public DelegateCommand(Action execCmd, Func<bool> canExec)
		{
			this.canExecute = canExec;
			this.executeCommand = execCmd;
		}
	}
}
