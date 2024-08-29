// See https://aka.ms/new-console-template for more information
using CodeSmells.Model;
using CodeSmells.Repositories;
using CodeSmells.Services;


namespace CodeSmells;

public class Program
{
    public static void Main(string[] args)
    {

        string url = "https://fake-json-api.mock.beeceptor.com/users";

        UserRepo userRepo = new UserRepo(new HttpClient(), url);

        UserService userService = new UserService(userRepo);

        var users = userService.GetUsers();

        string format = "{0,-20} {1,-20}";

        // Print table header
        Console.WriteLine(format, "Field", "Value");

        foreach (var user in users)
        {
            Console.WriteLine(new string('-', 40));
            // Print table rows
            Console.WriteLine(format, "ID", user.id);
            Console.WriteLine(format, "Name", user.name);
            Console.WriteLine(format, "Company", user.company);
            Console.WriteLine(format, "Username", user.username);
            Console.WriteLine(format, "Email", user.email);
            Console.WriteLine(format, "Address", user.address);
            Console.WriteLine(format, "Zip", user.zip);
            Console.WriteLine(format, "State", user.state);
            Console.WriteLine(format, "Country", user.country);
            Console.WriteLine(format, "Phone", user.phone);
            Console.WriteLine(format, "Photo", user.photo);
        }
    }

}

//Good structure of code
