﻿using ManagerDB.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ManagerDB.View
{
    /// <summary>
    /// Логика взаимодействия для AddNewDepartmentWindow.xaml
    /// </summary>
    public partial class AddNewValueWindow : Window
    {
        public AddNewValueWindow()
        {
            InitializeComponent();
        }

        void typeAdditionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = TypeAdditionComboBox.Items[TypeAdditionComboBox.SelectedIndex].ToString();

            if (selectedItem != null && selectedItem.Contains("User"))
            {
				UserStackPanel.Visibility = Visibility.Visible;
				PositionStackPanel.Visibility = Visibility.Hidden;
				DepartmentStackPanel.Visibility = Visibility.Hidden;
			}

			if (selectedItem != null && selectedItem.Contains("Position"))
			{
				UserStackPanel.Visibility = Visibility.Hidden;
				PositionStackPanel.Visibility = Visibility.Visible;
				DepartmentStackPanel.Visibility = Visibility.Hidden;
			}

			if (selectedItem != null && selectedItem.Contains("Department"))
			{
                UserStackPanel.Visibility = Visibility.Hidden;
                PositionStackPanel.Visibility = Visibility.Hidden;
				DepartmentStackPanel.Visibility = Visibility.Visible;
			}
		}
    }
}
