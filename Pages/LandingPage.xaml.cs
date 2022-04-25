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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ClientBook.Database;

namespace ClientBook.Pages
{
    /// <summary>
    /// Interaction logic for LandingPage.xaml
    /// </summary>
    public partial class LandingPage : Page
    {
        public LandingPage(string name)
        {
           
            InitializeComponent();
            loadclientinfo(name);

        }
        private void loadclientinfo(string name)
        {
            ClientManagementSystemEntities1 db = new ClientManagementSystemEntities1();
            int clientnumber = 0;

            var client = from a in db.Clientlists
                         select a;
            foreach (var i in client)
            {
                clientnumber = i.Id;
            }

            WelcomeText.Text = "Welcome " + name +",";
            activeText.Text = clientnumber.ToString();

        }
    }

  

}
