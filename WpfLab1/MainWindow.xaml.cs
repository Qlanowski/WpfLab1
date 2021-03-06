﻿using System.Collections.ObjectModel;
using System.Windows;
using WpfLab1.ViewModels;
using wpfTask1;

namespace WpfLab1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            vm = new MainWindowVM();
            this.DataContext = vm;
        }
        private MainWindowVM vm;
        private void LoginBtn(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Opacity = 0.5;
            vm.Login();
            Application.Current.MainWindow.Opacity = 1;
        }
    }
}
