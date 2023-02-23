using Grpc.Net.Client;
using UserRandom;
using static UserRandom.UserRandomA;


Console.Write("Введите адрес: ");
string address = Console.ReadLine();
using var channel = GrpcChannel.ForAddress(address);

UserRandomAClient client = new UserRandomA.UserRandomAClient(channel);

while (true)
{
    ListReply users = await GetUsers(client);

    foreach (var user in users.Users)
    {
        Console.WriteLine($"User name: {user.UserName}\n" +
            $"Email: {user.Email}\n" +
            $"Phone number: {user.PhoneNum}\n" +
            $"Avatar url: {user.AvatarUrl}\n" +
            $"Surname: {user.Surname}\n" +
            $"Name: {user.Name}\n");
        Console.WriteLine();
    }
    Console.Write("Цикл завершился");
    Console.ReadLine();
}


async Task<ListReply> GetUsers(UserRandomAClient client)
{
    try
    {
        return await client.GetRandomUsersListAsync(new UserRequest { Count = 5 });
    }
    catch 
    {
        Console.WriteLine("Произошла ошибка!!!");
        return null;
    }
}
