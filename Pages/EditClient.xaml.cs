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
    /// Interaction logic for EditClient.xaml
    /// </summary>
    public partial class EditClient : Page
    {
        public EditClient(String name)
        {
            InitializeComponent();
            load_data(name);
            
        }

        private void Locked_Click(object sender, RoutedEventArgs e)
        {
            Icon.Source = new BitmapImage(new Uri(@"C:\Users\Kharela\source\repos\ClientBook\Resources\Edit_UnlockedIcon.png", UriKind.RelativeOrAbsolute)); ;

        }

        private void load_data(string name)
        {
            MessageBox.Show("Inside Load_Data");
            ClientManagementSystemEntities1 db = new ClientManagementSystemEntities1();
            var clients = from c in db.Clientlists
                          where c.Name.Equals("Anish Kharel")
                          select c;
                          
            foreach(var i in clients)
            {
                NameEntry.Text = i.Name;
                AddressEntry.Text = i.Address;
                NumberEntry.Text = i.Number;
                EmailEntry.Text = i.Email;

            }
           
        }
    }
}
