using System;
using System.Collections.Generic;
using System.Data;
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
using ClientBook.Pages;


namespace ClientBook.Pages
{
    /// <summary>
    /// Interaction logic for SearchPage.xaml
    /// </summary>
    public partial class SearchPage : Page
    {
        HomePage hp;
        public SearchPage(HomePage hp)
        {
            this.hp = hp;
            InitializeComponent();

            ClientManagementSystemEntities1 db = new ClientManagementSystemEntities1();
            var clients = from c in db.Clientlists
                          select new
                          {
                              id = c.Id,
                              Name = c.Name,
                              Address = c.Address,
                              Number = c.Number,
                              Email = c.Email
                          };

            this.ClientGrid.ItemsSource = db.Clientlists.ToList();
            

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Update_grid(searchMenu.Text, dataEntry.Text);
            
        }

       
        private void Update_grid(string menu_Selection, string data)
        {
            
            try
            {
                
                
                ClientManagementSystemEntities1 db = new ClientManagementSystemEntities1();
                var clients = from c in db.Clientlists
                              select new
                              {
                                  id = c.Id,
                                  Name = c.Name,
                                  Address = c.Address,
                                  Number = c.Number,
                                  Email = c.Email
                              };
                if (menu_Selection.Equals("Name"))
                {
                    clients = from c in db.Clientlists
                              where c.Name.StartsWith(data)
                              select new
                              {
                                  id = c.Id,
                                  Name = c.Name,
                                  Address = c.Address,
                                  Number = c.Number,
                                  Email = c.Email
                              };

                }
                else if (menu_Selection.Equals("Address"))
                {
                    clients = from c in db.Clientlists
                              where c.Address.StartsWith(data)
                              select new
                              {
                                  id = c.Id,
                                  Name = c.Name,
                                  Address = c.Address,
                                  Number = c.Number,
                                  Email = c.Email
                              };

                }
                else if (menu_Selection.Equals("Number"))
                {
                    clients = from c in db.Clientlists
                              where c.Number.StartsWith(data)
                              select new
                              {
                                  id = c.Id,
                                  Name = c.Name,
                                  Address = c.Address,
                                  Number = c.Number,
                                  Email = c.Email
                              };

                }
                else if (menu_Selection.Equals("Email"))
                {
                    clients = from c in db.Clientlists
                              where c.Email.StartsWith(data)
                              select new
                              {
                                  id = c.Id,
                                  Name = c.Name,
                                  Address = c.Address,
                                  Number = c.Number,
                                  Email = c.Email
                              };

                }



                this.ClientGrid.ItemsSource = clients.ToList();
            }
            catch(Exception e)
            {
                MessageBox.Show("No such clients were found! \n Please try again");
            }
        }

        private void ClientGrid_Selection(object sender, SelectionChangedEventArgs e)
        {
            int id = 1;
            if (this.ClientGrid.SelectedIndex >= 0)
            {
                if (this.ClientGrid.SelectedItems.Count >= 0)
                {

                    if (this.ClientGrid.SelectedItems[0].GetType() == typeof(Clientlist))
                    {

                        Clientlist selectedClient = (Clientlist)this.ClientGrid.SelectedItems[0];
                        id = selectedClient.Id;
                        EditClient acp = new EditClient(id);

                        this.hp.NEditClient(acp);
                    }
                }

            }
         


           /* if (data_selected != null)
                {
                MessageBox.Show("clicked");
                acp = new EditClient(data_selected[0].ToString());
                this.hp.NEditClient(acp);


                }*/
           

        }
      
    }
}
