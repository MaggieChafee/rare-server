
namespace RareServer.Models  
{  
    public class UserList
    {
      public static List<Users> users = new()
       {
           new Users
           {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@example.com",
                    Bio = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                    Username = "john_doe",
                    Password = "password123",
                    ProfileImageUrl = "https://example.com/profiles/1.jpg",
                    CreatedOn = DateTime.Now.AddDays(-30),
                    Active = true
           },
             new Users
           {
                    Id = 2,
                    FirstName = "Jane",
                    LastName = "Smith",
                    Email = "jane.smith@example.com",
                    Bio = "Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    Username = "jane_smith",
                    Password = "abc123",
                    ProfileImageUrl = "https://example.com/profiles/2.jpg",
                    CreatedOn = DateTime.Now.AddDays(-60),
                    Active = true

           },
               new Users
           {
                    Id = 3,
                    FirstName = "Alice",
                    LastName = "Johnson",
                    Email = "alice.johnson@example.com",
                    Bio = "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                    Username = "alice_johnson",
                    Password = "passw0rd",
                    ProfileImageUrl = "https://example.com/profiles/3.jpg",
                    CreatedOn = DateTime.Now.AddDays(-90),
                    Active = false
           },
       };

    }
}
