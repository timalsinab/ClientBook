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
using ClientBook.Pages;

namespace ClientBook
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Window
    {
        public HomePage()
        {
            InitializeComponent();
            LandingPage lp = new LandingPage();
            mainFrame.Navigate(lp);
        }

        private void Search_Cick(object sender, RoutedEventArgs e)
        {
            button_Highlighter(2);
            mainFrame.Navigate(new SearchPage());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            button_Highlighter(1);
            mainFrame.Navigate(new LandingPage());
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            button_Highlighter(3);
            mainFrame.Navigate(new AddClientPage());
        }

        private void button_Highlighter(int buttonnum)
        {
            
            HomeButton.Background = Brushes.LightGray;
            SearchButton.Background = Brushes.LightGray;
            AddButton.Background = Brushes.LightGray;

            switch (buttonnum)
            {
                case 1: HomeButton.Background = Brushes.LightSkyBlue;
                    break;
                case 2: SearchButton.Background = Brushes.LightSkyBlue;
                    break;
                case 3: AddButton.Background = Brushes.LightSkyBlue;
                    break;
                default:
                    break;
            }


        }
    }
}
