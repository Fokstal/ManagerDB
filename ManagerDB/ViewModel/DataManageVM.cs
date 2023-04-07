using ManagerDB.Model;
using System.Collections.Generic;
using System.ComponentModel;
using ManagerDB.View;
using System.Windows;
using System;

namespace ManagerDB.ViewModel
{
    class DataManageVM : INotifyPropertyChanged
    {

		#region CONTEXT OF DB FOR LISTVIEW

		private List<Department> allDepartments = DataWorker.GetAllDepartment();
        public List<Department> AllDepartments 
        { 
            get => allDepartments; 
            set
            {
				allDepartments = value;
                NotifyPropertyChanged("AppDepartments");
			}
        }

		private List<Position> allPositions = DataWorker.GetAllPosition();
		public List<Position> AllPositions
		{
			get => allPositions;
			set
			{
				allPositions = value;
				NotifyPropertyChanged("AllPositions");
			}
		}

		private List<User> allUsers = DataWorker.GetAllUser();
		public List<User> AllUsers
		{
			get => allUsers;
			set
			{
				allUsers = value;
				NotifyPropertyChanged("AllUsers");
			}
		}

		#endregion

		#region VALUE FOR FIELD VIEW
		public string DepartmentName { get => DepartmentName; set { if (value is not null) DepartmentName = value; } }

		public string PositionName { get => PositionName; set { if (value is not null) PositionName = value; } }
		public string Salary { get => Salary; set { if (value is not null) Salary = value; } }
		public string MaxOfVacancies { get => MaxOfVacancies; set { if (value is not null) MaxOfVacancies = value; } }


		public string Name { get => Name; set { if (value is not null) Name = value; } }
		public string Surname { get => Surname; set { if (value is not null) Surname = value; } }
		public string Phone { get => Phone; set { if (value is not null) Phone = value; } }

		#endregion

		#region

		private RelayCommand? addNewDepartment;
		public RelayCommand AddNewDepartment 
		{ 
			get => addNewDepartment ?? new RelayCommand(o => 
			{

				string resultStr = "";

				resultStr = DataWorker.CreateNewValue(DepartmentName);

			}); }

		#endregion

		#region COMMANDS FOR BUTTONS

		private RelayCommand? openAddValueWindowCommand;
		public RelayCommand OpenAddValueWindowCommand
		{
			get => openAddValueWindowCommand ?? new RelayCommand(o => { OpenWindowInCenterPosition(new AddNewValueWindow()); });
		}

		private RelayCommand? editValueWindowCommand;
		public RelayCommand EditValueWindowCommand
		{
			get => editValueWindowCommand ?? new RelayCommand(o => { OpenWindowInCenterPosition(new EditValueWindow()); });
		}

		#endregion


		#region METHODS THAT OPEN WINDOWS
		private void OpenWindowInCenterPosition(Window window)
		{
			window.Owner = Application.Current.MainWindow;
			window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
			window.ShowDialog();
		}

		#endregion


		#region INotifyPropertyChanged 

		public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

		#endregion
	}
}
