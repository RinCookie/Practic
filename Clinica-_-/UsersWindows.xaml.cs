﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace Clinica___
{
    /// <summary>
    /// Логика взаимодействия для UsersWindows.xaml
    /// </summary>
    public partial class UsersWindows : Window
    {
        DbService db;

        public UsersWindows()
        {
            InitializeComponent();

            db = new DbService();
            db.users.Load();
            usersTable.ItemsSource = db.users.Local.ToBindingList();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();

        }
    }
}
