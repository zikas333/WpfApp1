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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для ListCalls.xaml
    /// </summary>
    public partial class ListCalls : Window
    {
         gr671_kvsEntities  db;
        public string client { get; set; }
        public ListCalls()
        {
            InitializeComponent();
        }

       
        private void Btninsert_Click(object sender, RoutedEventArgs e)
        {
            Calls calls = new Calls
            {
                 DateCall = Convert.ToDateTime(txtdata.Text),
                idUser = Convert.ToInt32(pol.Text),
                idLead = Convert.ToInt32(lid.Text),
                LongCall = Convert.ToInt32(dlit.Text)
            };
            db.Calls.Add(calls);
            db.SaveChanges();
            ListGrid.ItemsSource = db.Calls.ToList();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            /*db = new gr671_kvsEntities();
            ListGrid.ItemsSource = db.Calls.ToList();
            txtclient.Content = client;
            var IdUser = db.User.Where(user => user.LoginUser == (string)txtclient.Content).Select(id => id.LoginUser).FirstOrDefault();
            int _id = IdUser;*/

            db = new gr671_kvsEntities();
            ListGrid.ItemsSource = db.Calls.ToList();
        }

        private void Btndelete_Click(object sender, RoutedEventArgs e)
        {
            int num = (ListGrid.SelectedItem as Calls).IdCalls;
            var dRow = db.Calls.Where(delete => delete.IdCalls == num).FirstOrDefault();
            db.Calls.Remove(dRow);
            db.SaveChanges();
            ListGrid.ItemsSource = db.Calls.ToList();
            //testing
        }

        private void Btnedit_Click(object sender, RoutedEventArgs e)
        {
            int num = (ListGrid.SelectedItem as Calls).IdCalls;
            var dRow = db.Calls.Where(edit => edit.IdCalls == num).FirstOrDefault();
            dRow.DateCall = Convert.ToDateTime(txtdata.Text);
            dRow.LongCall = Convert.ToInt32(dlit.Text);
            dRow.idUser = Convert.ToInt32(pol.Text);
            dRow.idLead = Convert.ToInt32(lid.Text);
            db.SaveChanges();
            ListGrid.ItemsSource = db.Calls.ToList();
        }
    }
}
