using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;
using TMA.MVVM.Pages;
using TMACustomLib;

namespace TMA.MVVM.View
{
    /// <summary>
    /// Interaction logic for MainWin.xaml
    /// </summary>
    public partial class MainWin : Window
    {

        public MainWin()
        {
            InitializeComponent();
            
        }
        //allows window to be moved from anywhere
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }  

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }
        //changes whats displayed in the frame on each window
        private void rbAddMod_Checked(object sender, RoutedEventArgs e)
        {
            AddModulePage amp = new AddModulePage();
            if (HomePage.mc.NumWeeks == 999)
            {
                rbHome.IsChecked = true;
                MessageBox.Show("Please enter the number of weeks in a semester and the start date", "WARNING", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
            else
            {
                //MainFrame.NavigationService.Navigate(amp);
                MainFrame.Content = amp;
            }
        }
        //changes whats displayed in the frame on each window
        private void rbHome_Checked(object sender, RoutedEventArgs e)
        {
            rbHome.IsChecked = true;
            HomePage hmp = new HomePage();
            MainFrame.Content = hmp;
            txtcurr.Text = $"Welcome, {STS.currentUser}";

        }
        //changes whats displayed in the frame on each window
        private void rbTimeStudy_Checked(object sender, RoutedEventArgs e)
        {
            TimeStudiedPage tsp = new TimeStudiedPage();
            if (HomePage.mc.NumWeeks == 999)
            {
                rbHome.IsChecked = true;
                MessageBox.Show("Please enter the number of weeks in a semester and the start date", "WARNING", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
            else
            {


                MainFrame.Content = tsp;

            }

        }
        //changes whats displayed in the frame on each window
        private void rbReport_Checked(object sender, RoutedEventArgs e)
        {
            ReportPage rp = new ReportPage();
            if (HomePage.mc.NumWeeks == 999)
            {
                rbHome.IsChecked = true;
                MessageBox.Show("Please enter the number of weeks in a semester and the start date", "WARNING", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                
                MainFrame.Content = rp;

            }
        }
        //changes whats displayed in the frame on each window
        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            LoginView lv = new LoginView();
            lv.Show();
            this.Close();
        }
    }
}
