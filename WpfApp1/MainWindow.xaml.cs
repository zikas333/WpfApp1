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


namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    { 

        gr671_kvsEntities db;
       
        public MainWindow()
        {
            InitializeComponent();
            db = new gr671_kvsEntities();
        }

        private void BtnSumbit_Click(object sender, RoutedEventArgs e)
        {
            if (txtUsername.Text == "" || txtPassword.Password == "")
            {
                MessageBox.Show("Пустые поля");
            }
            if (db.User.Select(item => item.LoginUser + "" + item.PasswordUser).Contains(txtUsername.Text + "" + txtPassword.Password))

            {
                ListCalls listCalls = new ListCalls();
                listCalls.client = txtUsername.Text;
                listCalls.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Данные не верны");
            }

        }

        private void Btnreg_Click(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
                this.Hide();
        }
    }
}
