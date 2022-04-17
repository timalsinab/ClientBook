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
    /// Interaction logic for SearchPage.xaml
    /// </summary>
    public partial class SearchPage : Page
    {
        public SearchPage()
        {
            InitializeComponent();

            ClientManagementSystemEntities db = new ClientManagementSystemEntities();
            var clients = from c in db.Clientlists
                          select new
                          {
                              ClientName = c.Name,
                              ClientAddress = c.Address,
                              ClientNumber = c.Number,
                              ClientEmail = c.Email
                          };

            foreach(var item in clients)
            {
                Console.WriteLine(item.ClientName);
                Console.WriteLine(item.ClientAddress);
                Console.WriteLine(item.ClientNumber);
                Console.WriteLine(item.ClientEmail);
                Console.WriteLine("------------------");
            }

            this.ClientGrid.ItemsSource = clients.ToList();
           

        }
    }
}
