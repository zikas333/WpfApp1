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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        testConectionEntities db = new testConectionEntities();
        public Registration()
        {
            InitializeComponent();
        }

        private void btnreg_Click(object sender, RoutedEventArgs e)
        {
            if (txtLogin.Text == "" || txPassword.Password == "" || txtLN.Text == "" || txtFN.Text == "" || txtMN.Text == "")
            {
                MessageBox.Show("Поля пустые");
                return;
            }
            if (db.User.Select(item => item.LoginUser).Contains(txtLogin.Text))
            {
                MessageBox.Show("Такой логин уже существует");
                return;
            }
            User Newuser = new User()
            {
                LoginUser = txtLogin.Text,
                PasswordUser = txPassword.Password,
                LastNameUser = txtLN.Text,
                FirstNameUser = txtFN.Text,
                MiddleNameUser = txtMN.Text

            };
            db.User.Add(Newuser);
            db.SaveChanges();
            MessageBox.Show("ВЫ успешнор зарегистрировались");
           
            this.Close();
       
        }
    }
}
