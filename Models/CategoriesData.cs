namespace RareServer.Models
{
    public class Category
    {
        public static List<Categories> categories = new()
        {
            new Categories()
            {
                Id = 1,
                Label = "Programming"
            },
            new Categories()
            {
                Id = 2,
                Label = "Front End Development"
            },
            new Categories()
            {
                Id = 3,
                Label = "Back End Development"
            }
        };
    }
}
