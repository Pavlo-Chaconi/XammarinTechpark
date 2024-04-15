using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XammarinTechpark.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MySqlConnector;

namespace XammarinTechpark
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Schedule_Page : ContentPage
    {
        private schedule _schedules;
        public Schedule_Page(schedule schedules)
        {
            _schedules = schedules;
            InitializeComponent();
            nameLabel.Text += schedules.Name;
            dateLabel.Text += schedules.Date;
            classroomLabel.Text += schedules.ClassRoomName;
            LastNameLabel.Text += schedules.LastName;
        }


        async private void action_button_Clicked(object sender, EventArgs e)
        {
            MSQL_DB conn_db = new MSQL_DB();


            conn_db.openConnection();

            string insert = $"insert into mysql_action_user values(NULL, {User.Id}, {_schedules.Id})";
            MySqlCommand ins_cmd = new MySqlCommand(insert, conn_db.getConnection());

            if (ins_cmd.ExecuteNonQuery() == 1)
                await DisplayAlert("Успешно!", "Вы записались на мероприятие!", "Ок");

            conn_db.closeConnection();
        }
    }
}