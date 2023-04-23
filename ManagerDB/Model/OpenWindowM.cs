using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ManagerDB.Model
{
	public class OpenWindowM
	{
		public static void OpenWindowInCenterPosition(Window window)
		{
			window.Owner = Application.Current.MainWindow;
			window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
			window.ShowDialog();
		}
	}
}
