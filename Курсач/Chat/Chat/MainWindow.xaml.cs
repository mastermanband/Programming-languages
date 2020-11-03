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

namespace Chat
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
    }
    private void LoginButton_Click(object sender, RoutedEventArgs e)
    {
        //Пока используем тестовые данные
        if (LoginBox.Text == "admin" && PasswordBox.Password == "12345")
        {
            //Если логин и пароль верные, то переходим на другой экран
            Open(ContactsScreen);
        }
        else
        {
            //Иначе выводим сообщение об ошибке авторизации
            LoginMessageBlock.Text = "Wrong login or password!";
            LoginMessageBlock.Visibility = Visibility.Visible;
        }
    }

    //Метод для открытия другого экрана
    private void Open(Border screen)
    {
        //Делаем все экраны невидимыми
        LoginScreen.Visibility = Visibility.Hidden;
        ContactsScreen.Visibility = Visibility.Hidden;
        ChatScreen.Visibility = Visibility.Hidden;

        //Делаем видимым необходимый экран
        screen.Visibility = Visibility.Visible;
    }
}
