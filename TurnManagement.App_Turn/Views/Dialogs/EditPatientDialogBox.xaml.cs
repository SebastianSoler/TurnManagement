﻿using System.Windows;

namespace TurnManagement.App_Turn.Views.Dialogs
{
    /// <summary>
    /// Interaction logic for InputDialogBox.xaml
    /// </summary>
    public partial class EditPatientDialogBox : Window
    {
        public EditPatientDialogBox()
        {
            InitializeComponent();
        }

        private void ShotDownPage(object sender, RoutedEventArgs e)
        {
            Close();
            //Application.Current.MainWindow.DialogResult
        }

        private void Border_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtEditPatientName.Focus();
        }
    }
}
