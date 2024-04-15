using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XammarinTechpark
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registration_Page : ContentPage
    {
        public Registration_Page()
        {
            InitializeComponent();
        }

        async private void registerButton_Clicked(object sender, EventArgs e)
        {
            string mail = email_entry.Text;
            string login = registartion_form_login_entry.Text;
            string pass = registration_form_password_entry.Text;
            if (string.IsNullOrEmpty(mail) || string.IsNullOrEmpty(login) || string.IsNullOrEmpty(pass))
            {
                await DisplayAlert("Ошибка", "Не все поля заполнены", "Ок");
                return;
            }
            try
            {
                MSQL_DB conn_db = new MSQL_DB();

                conn_db.openConnection();

                string query = $"insert into mysql_users values (NULL, '{login}', '{pass}', '{mail}')";
                MySqlCommand reg_cmd = new MySqlCommand(query, conn_db.getConnection());



                if (reg_cmd.ExecuteNonQuery() == 1)
                    await DisplayAlert("Успешно!", "Аккаунт создан!", "Ок");

                else
                    await DisplayAlert("Провал!", "Аккаунт не создан!", "Ок");

                conn_db.closeConnection();

            }
            catch(Exception except)
            {
                await DisplayAlert("Провал!", $"Произошла ошибка в создании записи!\n{except.Message}", "Ок"); ;
            }

            
            await Navigation.PushAsync(new Login_Page());
        }
    }
}