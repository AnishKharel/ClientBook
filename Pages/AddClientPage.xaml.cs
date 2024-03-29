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
    /// Interaction logic for AddClientPage.xaml
    /// </summary>
    public partial class AddClientPage : Page
    {
        public AddClientPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ClientManagementSystemEntities1 db = new ClientManagementSystemEntities1();
            var clientName = NameEntry.Text;
            var clientAddress = AddressEntry.Text;
            var clientNumber = NumberEntry.Text;
            var clientEmail = EmailEntry.Text;

            Clientlist newclient = new Clientlist()
            {
                Name = clientName,
                Address = clientAddress,
                Number = clientNumber,
                Email = clientEmail


            };

            db.Clientlists.Add(newclient);
            db.SaveChanges();
            

            MessageBox.Show("Client Succesfully Added");

            
           

        }
    }
}
