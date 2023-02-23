using Bogus;


namespace UsersAppGrpcService.Models
{
    public class GeneratorUser
    {

        private static Faker<User> faker = new Faker<User>("ru")
            .RuleFor(x => x.UserName, f => f.Internet.UserName())
            .RuleFor(x => x.Email, f => f.Internet.Email())
            .RuleFor(x => x.PhoneNum, f => f.Phone.PhoneNumber("+375-##-###-##-##"))
            .RuleFor(x => x.AvatarUrl, f => f.Internet.Avatar())
            .RuleFor(x => x.Surname, f => f.Name.LastName())
            .RuleFor(x => x.Name, f => f.Name.FirstName());


        public static User GetRandomUser() => faker.Generate();
    }
}
