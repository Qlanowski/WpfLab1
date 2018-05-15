using System.Collections.ObjectModel;
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
            vm.Login(this);
            Application.Current.MainWindow.Opacity = 1;
            if(vm.loginContent=="Logout")
            {
                FirstColumn.MinWidth = 210;
                FirstColumn.Width = new GridLength(4, GridUnitType.Star);
            }
            else
            {
                FirstColumn.MinWidth = 0;  
                FirstColumn.Width = new GridLength(0, GridUnitType.Pixel);

            }
        }
        private void NewMailBtn(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Opacity = 0.5;
            vm.NewMail(this);
            Application.Current.MainWindow.Opacity = 1;
        }

        private void Searching(object sender, RoutedEventArgs e)
        {
            if (vm!=null)
              vm.UpdateList(TabCtrl.RecieveSelected);
        }

    }
}
