using System.Windows.Controls;

namespace ManagerDB.Model
{
	public class MainWindowModel
	{
		public static void UpdateAllListView(View.MainWindow? window)
		{
			if (window is not  null)
			{
				UpdateListView(window.ListDepartmentsLV, DataWorker.GetAllDepartment());
				UpdateListView(window.ListPositionsLV, DataWorker.GetAllPosition());
				UpdateListView(window.ListUsersLV, DataWorker.GetAllUser());
			}
		}

		private static void UpdateListView(ListView listView, object context)
		{
			listView.ItemsSource = null;
			listView.Items.Clear();
			listView.ItemsSource = (System.Collections.IEnumerable?) context;
			listView.Items.Refresh();
		}
	}
}
