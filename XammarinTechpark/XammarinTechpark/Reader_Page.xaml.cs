using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XammarinTechpark.Models;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;
using MySqlConnector;

namespace XammarinTechpark
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Reader_Page : ContentPage
    {
        public Reader_Page()
        {
            InitializeComponent();

            List<schedule> actions = new List<schedule>();

            MSQL_DB conn_db = new MSQL_DB();

            conn_db.openConnection();

            string select = "select mysql_actions.ID, Name, Date, mysql_organizaton.Name_Org, " +
                "mysql_places.Name_Place from mysql_actions inner join mysql_places on mysql_places.ID =" +
                " mysql_actions.ID_place inner join mysql_organizaton on mysql_organizaton.ID = mysql_actions.ID_Org ";

            MySqlCommand reader_cmd = new MySqlCommand(select, conn_db.getConnection());
            MySqlDataReader data_reader_of_reader_page = reader_cmd.ExecuteReader();
            while (data_reader_of_reader_page.Read())
            {
                int Id_Action = data_reader_of_reader_page.GetInt32("ID");
                string Name_Action = data_reader_of_reader_page.GetString("Name");
                DateTime DateTime_Action = data_reader_of_reader_page.GetDateTime("Date");                                 
                string orgName = data_reader_of_reader_page.GetString("Name_Org");
                string placeName = data_reader_of_reader_page.GetString("Name_Place");               


                schedule action = new schedule()
                {
                    Id = Id_Action,
                    Name = Name_Action,
                    Date = DateTime_Action,
                    ClassRoomName = placeName,
                    LastName = orgName
                };
                actions.Add(action);
            }

            conn_db.closeConnection();

            reader_list_view.ItemsSource = actions;


        }

        private async void reader_list_view_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            schedule actions = e.Item as schedule;
            await Navigation.PushAsync(new Schedule_Page(actions));
        }
    }

}