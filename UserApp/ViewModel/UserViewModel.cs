using System.Diagnostics;
using Grpc.Net.Client;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UserGrpcClassLib;
using static UserGrpcClassLib.UserRandomA;

namespace UserApp.ViewModel
{
    public class UserViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        ListReply _users;

        public ListReply Users
        {
            get { return _users; }
            set
            {
                if (value != null && value != _users)
                {
                    Debug.WriteLine("Значение присвоено");
                    _users = value;
                    OnPropertyChanged();
                }
            }
        }
        UserRandomAClient _client;

        //public ICommand AddCommand { get; set; }

        public UserViewModel(string address)
        {
            var channel = GrpcChannel.ForAddress(address);
            _client = new UserRandomAClient(channel);
            GetUsers(_client);
        }


        private async void GetUsers(UserRandomAClient client)
        {
            try
            {
                var u = await client.GetRandomUsersListAsync(new UserRequest { Count = 50 });
                Users = u;
            }
            catch
            {
                Debug.Write("Ошибка");
            }
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

    }
}
