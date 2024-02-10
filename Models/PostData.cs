namespace RareServer.Models
{
    public class PostData
    {
        public static List<Posts> posts = new()
        {
           new Posts
           {
            Id = 1 ,
            UserId = 2,
            CategoryId = 3,
            Title = "New cat",
            PublicationDate = DateTime.Now.AddDays(-60) ,
            ImageUrl = "https://hips.hearstapps.com/hmg-prod/images/beautiful-smooth-haired-red-cat-lies-on-the-sofa-royalty-free-image-1678488026.jpg",
            Content = "I got a new cat!",
            Approved = true,
           },
            new Posts
           {
            Id = 2,
            UserId = 1,
            CategoryId = 2,
            Title = "Its been a long day",
            PublicationDate = DateTime.Now.AddDays(-90),
            ImageUrl = "https://www.shutterstock.com/image-photo/car-accident-on-wet-road-600nw-2261506217.jpg",
            Content = "got in a bit of a fender bender today...",
            Approved = false,
           },
             new Posts
           {
            Id = 3,
            UserId = 2,
            CategoryId = 2,
            Title = "keeps getting longer",
            PublicationDate = DateTime.Now.AddDays(-90) ,
            ImageUrl = "https://hips.hearstapps.com/hmg-prod/images/vending-cup-on-side-spilling-coffee-onto-surface-royalty-free-image-1651507034.jpg",
            Content = "not my coffee!" ,
            Approved = true,
           }
        };

     
    }
}
