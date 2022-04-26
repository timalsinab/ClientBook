﻿using System;
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

            ClientManagementSystemEntities1 db = new ClientManagementSystemEntities1();
            var clients = from c in db.Clientlists
                          select new
                          {
                              Name = c.Name,
                              Address = c.Address,
                              Number = c.Number,
                              Email = c.Email
                          };
/*
            foreach(var item in clients)
            {
                Console.WriteLine(item.ClientName);
                Console.WriteLine(item.ClientAddress);
                Console.WriteLine(item.ClientNumber);
                Console.WriteLine(item.ClientEmail);
                Console.WriteLine("------------------");
            }*/

            this.ClientGrid.ItemsSource = clients.ToList();
            

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
    }
}
