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
    /// 

    
    public partial class EditClient : Page
    {
        int id;
        public EditClient(int id)
        {
            this.id = id;
            InitializeComponent();
            load_data();
            
            
        }

        private void Locked_Click(object sender, RoutedEventArgs e)
        {
            // Icon.Source = new BitmapImage(new Uri(@"C:\Users\Kharela\source\repos\ClientBook\Resources\Edit_UnlockedIcon.png", UriKind.RelativeOrAbsolute)); ;
            Locked.Visibility = Visibility.Hidden;
            unLocked.Visibility = Visibility.Visible;
            NameEntry.IsReadOnly = false;
            AddressEntry.IsReadOnly = false;
            NumberEntry.IsReadOnly = false;
            EmailEntry.IsReadOnly = false;


        }

        private void load_data()
        {
            ClientManagementSystemEntities1 db = new ClientManagementSystemEntities1();
            var clients = from c in db.Clientlists
                          where c.Id.Equals(this.id)
                          select c;
                          
            foreach(var i in clients)
            {
                NameEntry.Text = i.Name;
                AddressEntry.Text = i.Address;
                NumberEntry.Text = i.Number;
                EmailEntry.Text = i.Email;

            }
           
        }

        private void unLocked_Click(object sender, RoutedEventArgs e)
        {
            unLocked.Visibility = Visibility.Hidden;
            Locked.Visibility = Visibility.Visible;
            NameEntry.IsReadOnly = true;
            AddressEntry.IsReadOnly =true;
            NumberEntry.IsReadOnly = true;
            EmailEntry.IsReadOnly = true;

            ClientManagementSystemEntities1 db = new ClientManagementSystemEntities1();
            var clients = from c in db.Clientlists
                          where c.Id.Equals(this.id)
                          select c;

            foreach (var i in clients)
            {
                i.Name = NameEntry.Text;
                i.Address = AddressEntry.Text;
                i.Number = NumberEntry.Text;
                i.Email = EmailEntry.Text;

            }

            db.SaveChanges();

            






        }
    }
}
