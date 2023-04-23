using ManagerDB.Model;
using ManagerDB.View;

namespace ManagerDB.ViewModel
{
	public class MessageViewVM
	{
		private static string? _message;
		public string? Message { get => _message; set => _message = value; }

		private static MessageViewWindow? messageViewWindow;

		public static void ShowMessageView(string? message)
		{
			_message = message;

			OpenWindowM.OpenWindowInCenterPosition(new MessageViewWindow());
		}

		private RelayCommand _closeMessageViewWindow = new RelayCommand(o => 
		{
			messageViewWindow = o as MessageViewWindow ?? new MessageViewWindow();

			messageViewWindow.Close();
		});
		public RelayCommand CloseMessageViewCommand { get => _closeMessageViewWindow; set => _closeMessageViewWindow = value; }
	}
}
