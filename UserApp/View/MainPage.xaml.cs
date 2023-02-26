using System.Threading.Channels;
using UserApp.ViewModel;
using UserApp.Model;
using UserGrpcClassLib;
using static UserGrpcClassLib.UserRandomA;

namespace UserApp
{
    public partial class MainPage : ContentPage
    {
        UserViewModel userViewModel;

        public MainPage()
        {
            InitializeComponent();

            string address = "http://localhost:5000";
             userViewModel = new UserViewModel(address);
            
            
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            List<User> users = new List<User>();
            foreach (var user in userViewModel.Users.Users)
            {
                User user1 = new User()
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    PhoneNum = user.PhoneNum,
                    AvatarUrl = user.AvatarUrl,
                    Surname = user.Surname,
                    Name = user.Name

                };
                users.Add(user1);
            }

            collectionViewUser.ItemsSource = users;
        }
    }
}