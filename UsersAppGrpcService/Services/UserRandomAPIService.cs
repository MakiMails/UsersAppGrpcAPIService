using Grpc.Core;
using UsersAppGrpcService.Models;
using UserRandom;

namespace UsersAppGrpcService.Services
{
    public class UserRandomAPIService: UserRandomA.UserRandomABase 
    {
        public override Task<ListReply> GetRandomUsersList(UserRequest request, ServerCallContext context)
        {
            
            List<User> users = new List<User>();
            for (int i = 0; i < request.Count; i++)
            {
                users.Add(GeneratorUser.GetRandomUser());
            }

            var userList = users.Select(item => new UserReply {
                UserName= item.UserName,
                Email= item.Email,
                PhoneNum = item.PhoneNum,
                AvatarUrl= item.AvatarUrl,
                Surname = item.Surname, 
                Name = item.Name}).ToList();
            var listReply = new ListReply();
            listReply.Users.AddRange(userList);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Данные успешно отправлены");
            Console.ForegroundColor = ConsoleColor.White;

            return Task.FromResult(listReply);
        }
    }
}
