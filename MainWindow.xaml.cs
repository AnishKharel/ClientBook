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

namespace ClientBook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = EntryUsername.Text;
            string password = EntryPassword.Password.ToString();

            validator(username, password);
           
        }

        private void validator(string Pusername,string Ppassword)
        { 
            ClientManagementSystemEntities1 db = new ClientManagementSystemEntities1();
            string password = " ";
            string name = " ";

            try
            {
                var admins = from a in db.Admins
                             where a.Username.Equals(Pusername)
                             select a;
                foreach (var i in admins)
                {
                    password = i.Password;
                    name = i.Name;
                }

                if (password.Equals(Ppassword))
                {
                    var newForm = new HomePage(name);
                    newForm.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Incorrect Username or Password\n Please try again!");
                }

            }

            catch (Exception e)
            {
                MessageBox.Show("Incorrect Username or Password\n Please try again!");
            }
           
        }

    }
}
