using ManagerDB.Model;
using ManagerDB.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ManagerDB.ViewModel
{
	public class DataManageVM : INotifyPropertyChanged
	{ 
		#region Data context for fields ListView

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

		#region Value for field of window AddNewValueWindow

		private AddNewValueWindow? _addNewValueWindow;

		#region Department field
		//Department
		private string? _departmentName;
		private bool _departmentNameValidate;

		public string? DepartmentName
		{
			get => _departmentName;
			set
			{
				_departmentName = value;
				_departmentNameValidate = _departmentName.RulesForName().IsNull().IsSpace().Length(5, 15).Validate();

				if (_departmentNameValidate) MarkIsValid(_addNewValueWindow, "DepartmentNameTextBox");
				else MarkIsInvalid(_addNewValueWindow, "DepartmentNameTextBox");
			}
		}
		#endregion

		#region Position field
		//Position
		private string? _positionName;
		private bool _positionNameValidate;
		public string? PositionName
		{
			get => _positionName;
			set
			{
				_positionName = value;
				_positionNameValidate = _positionName.RulesForName().IsNull().IsSpace().Length(5, 15).Validate();

				if (_positionNameValidate) MarkIsValid(_addNewValueWindow, "PositionNameTextBox");
				else MarkIsInvalid(_addNewValueWindow, "PositionNameTextBox");
			}
		}


		private string? _salary;
		private bool _salaryValidate;
		public string? Salary
		{
			get => _salary;
			set
			{
				_salary = value;
				_salaryValidate = _salary.RulesForNumber().IsNumber().Range(400, 2500).Validate();

				if (_salaryValidate) MarkIsValid(_addNewValueWindow, "SalaryTextBox");
				else MarkIsInvalid(_addNewValueWindow, "SalaryTextBox");
			}
		}


		private string? _maxOfVacansies;
		private bool _maxOfVacansiesValidate;
		public string? MaxOfVacansies
		{
			get => _maxOfVacansies;
			set
			{
				_maxOfVacansies = value;
				_maxOfVacansiesValidate = _maxOfVacansies.RulesForNumber().IsNumber().Range(3, 30).Validate();

				if (_maxOfVacansiesValidate) MarkIsValid(_addNewValueWindow, "MaxOfVacansiesTextBox");
				else MarkIsInvalid(_addNewValueWindow, "MaxOfVacansiesTextBox");
			}
		}


		private Department? _departmentOfPosition;
		public Department? DepartmentOfPosition { get => _departmentOfPosition; set =>	_departmentOfPosition = value; }
		#endregion

		#region User field
		//User
		private string? _userName;
		private bool _userNameValidate;
		public string? UserName
		{
			get => _userName;
			set
			{
				_userName = value;
				_userNameValidate = _userName.RulesForName().IsNull().IsSpace().Length(10, 20).Validate();

				if (_userNameValidate) MarkIsValid(_addNewValueWindow, "UserNameTextBox");
				else MarkIsInvalid(_addNewValueWindow, "UserNameTextBox");
			}
		}


		private string? _surname;
		private bool _surnameValidate;
		public string? Surname
		{
			get => _surname;
			set
			{
				_surname = value;
				_surnameValidate = _surname.RulesForName().IsNull().IsSpace().Length(15, 25).Validate();

				if (_surnameValidate) MarkIsValid(_addNewValueWindow, "SurnameTextBox");
				else MarkIsInvalid(_addNewValueWindow, "SurnameTextBox");
			}
		}


		private string? _phone;
		private bool _phoneValidate;
		public string? Phone
		{
			get => _phone;
			set
			{
				if (value?.Length == 1) value = "+";

				if (value?.Length < 18) _phone = value;
				_phoneValidate = _phone.RulesForPhone().IsNull().CheckMask().Validate();

				if (_phoneValidate) MarkIsValid(_addNewValueWindow, "PhoneTextBox");
				else MarkIsInvalid(_addNewValueWindow, "PhoneTextBox");
			}
		}


		private Position? _positionOfUser;
		public Position? PositionOfUser { get => _positionOfUser; set => _positionOfUser = value; }
		#endregion


		#endregion


		private void MarkIsInvalid(Window? window, string nameControl)
		{
			Control? controlBlock = window?.FindName(nameControl) as Control;

			if (controlBlock != null)
			{
				controlBlock.BorderBrush = Brushes.Red;
				controlBlock.BorderThickness = new Thickness(1);
			}
		}
		private void MarkIsValid(Window? window, string nameControl)
		{
			Control? controlBlock = window?.FindName(nameControl) as Control;

			if (controlBlock != null)
			{
				controlBlock.BorderBrush = Brushes.Green;
				controlBlock.BorderThickness = new Thickness(2);
			}
		}
		private void SetToolTip(AddNewValueWindow window)
		{
			ToolTip toolTip_DepartmentName = new ToolTip();

			ToolTip toolTip_PositionName = new ToolTip();
			ToolTip toolTip_Salary = new ToolTip();
			ToolTip toolTip_MaxOfVacansies = new ToolTip();

			ToolTip toolTip_UserName = new ToolTip();
			ToolTip toolTip_Surname = new ToolTip();
			ToolTip toolTip_Phone = new ToolTip();

			//Department ToolTip
			toolTip_DepartmentName.Content = "Length (5..15)";
			window.DepartmentNameTextBox.ToolTip = toolTip_DepartmentName;


			//Position ToolTip
			toolTip_PositionName.Content = "Length (5..15)";
			window.PositionNameTextBox.ToolTip = toolTip_PositionName;

			toolTip_Salary.Content = "Range (400..2500)";
			window.SalaryTextBox.ToolTip = toolTip_Salary;

			toolTip_MaxOfVacansies.Content = "Range (3..30)";
			window.MaxOfVacansiesTextBox.ToolTip = toolTip_MaxOfVacansies;


			//User ToolTip
			toolTip_UserName.Content = "Length (10..20)";
			window.UserNameTextBox.ToolTip = toolTip_UserName;

			toolTip_Surname.Content = "Length (15..25)";
			window.SurnameTextBox.ToolTip = toolTip_Surname;

			toolTip_Phone.Content = "Mask: +_.._ __|___|__|__";
			window.PhoneTextBox.ToolTip = toolTip_Phone;
		}


		#region Command for function DataWorker

		private static MainWindow? mainWindow;

		private RelayCommand? _addNewValueCommand;
		public RelayCommand AddNewValueCommand
		{
			get => _addNewValueCommand ?? new RelayCommand(o =>
			{
				string resultStr = "";

				_addNewValueWindow = o as AddNewValueWindow ?? new AddNewValueWindow();

				SetToolTip(_addNewValueWindow);

				object selectedItem = _addNewValueWindow.TypeAdditionComboBox.SelectedItem;
				string? selectedItemStr = null;

				if (selectedItem is not null) selectedItemStr = selectedItem.ToString();

				if (selectedItemStr is not null)
				{
					if (selectedItemStr.Contains("User")) resultStr = SubmitUserData();
					if (selectedItemStr.Contains("Position")) resultStr = SubmitPositionData();
					if (selectedItemStr.Contains("Department")) resultStr = SubmitDepartmentData();
				}

				if (resultStr == "")
				{
					_addNewValueWindow.Close();
					return;
				}

				if (!resultStr.Contains("not"))
				{
					MessageViewVM.ShowMessageView(resultStr);
					MainWindowModel.UpdateAllListView(mainWindow);
					_addNewValueWindow.Close();
				}
			});
		}

		private string SubmitUserData()
		{
			string resultStr = "Add new USER not success!";

			if (_userNameValidate && _surnameValidate && _phoneValidate)
			{
				resultStr = DataWorker.AddNewValue(_userName, _surname, _phone, _positionOfUser);

				return resultStr;
			}

			if (!_userNameValidate) MarkIsInvalid(_addNewValueWindow, "UserNameTextBox");
			if (!_surnameValidate) MarkIsInvalid(_addNewValueWindow, "SurnameTextBox");
			if (!_phoneValidate) MarkIsInvalid(_addNewValueWindow, "PhoneTextBox");
			if (_positionOfUser is null && _addNewValueWindow is not null) MessageViewVM.ShowMessageView("Please, select POSITION!");

			return resultStr;
		}
		private string SubmitPositionData()
		{
			string resultStr = "Add new POSITION not success!";

			if (_positionNameValidate && _salaryValidate && _maxOfVacansiesValidate)
			{
				resultStr = DataWorker.AddNewValue(_positionName, Convert.ToDecimal(_salary), Convert.ToInt32(_maxOfVacansies), _departmentOfPosition);

				return resultStr;
			}

			if (!_positionNameValidate) MarkIsInvalid(_addNewValueWindow, "PositionNameTextBox");
			if (!_salaryValidate) MarkIsInvalid(_addNewValueWindow, "SalaryTextBox");
			if (!_maxOfVacansiesValidate) MarkIsInvalid(_addNewValueWindow, "MaxOfVacansiesTextBox");
			if (_departmentOfPosition is null && _addNewValueWindow is not null) MessageViewVM.ShowMessageView("Please, select DEPARTMENT!");

			return resultStr;
		}
		private string SubmitDepartmentData()
		{
			string resultStr = "Add new DEPARTMENT not success!";

			if (_departmentNameValidate)
			{
				resultStr = DataWorker.AddNewValue(_departmentName);

				return resultStr;
			}

			if (!_departmentNameValidate) MarkIsInvalid(_addNewValueWindow, "DepartmentNameTextBox");

			return resultStr;
		}

		#endregion


		#region Command for open Window

		private RelayCommand? openAddValueWindowCommand;
		public RelayCommand OpenAddValueWindowCommand
		{
			get => openAddValueWindowCommand ?? new RelayCommand(o => { mainWindow = o as MainWindow ?? new MainWindow(); OpenWindowM.OpenWindowInCenterPosition(new AddNewValueWindow()); });
		}

		private RelayCommand? editValueWindowCommand;
		public RelayCommand EditValueWindowCommand
		{
			get => editValueWindowCommand ?? new RelayCommand(o => { mainWindow = o as MainWindow ?? new MainWindow(); OpenWindowM.OpenWindowInCenterPosition(new EditValueWindow()); });
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
