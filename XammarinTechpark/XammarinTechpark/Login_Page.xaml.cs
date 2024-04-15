using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XammarinTechpark.Models;
using MySqlConnector;

namespace XammarinTechpark
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login_Page : ContentPage
    {
        public Login_Page()
        {
            InitializeComponent();
        }

        private async void Registration_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Registration_Page());
        }

        private async void temp_btn_clck(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Reader_Page());
        }

        async private void Login_Button_Page_Clicked(object sender, EventArgs e)
        {
            string login = login_entry.Text;
            string pass = pass_entry.Text;
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(pass))
            {
                await DisplayAlert("Ошибка", "Не все поля заполнены", "Ок");
                return;
            }

            MSQL_DB conn_db = new MSQL_DB();

            conn_db.openConnection();

            string select = $"select * from mysql_users where Login = '{login}' and Password = '{pass}'";
            MySqlCommand log_cmd = new MySqlCommand(select, conn_db.getConnection());
            MySqlDataReader login_reader = log_cmd.ExecuteReader();
            while (login_reader.Read())
            {
                int Id_User = login_reader.GetInt32("ID");
                User.Id = Id_User;
                await Navigation.PushAsync(new Reader_Page());
                return;
            }
            await DisplayAlert("Ошибка", "Такой пользователь не найден", "Ок");
        }
    }
}