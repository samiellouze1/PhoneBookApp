using PerfectInstadee.Models;

namespace PerfectInstadee.Data.AppDb
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                if (!context.Users.Any())
                {
                    List<User> users = new List<User>();
                    users.Add(new User() { Email = "Alice@instadeep.com", FullName = "Alice", PhoneNumber = 111111, Contacts = new List<Contact>() });
                    users.Add(new User() { Email = "Bob@instadeep.com", FullName = "Bob", PhoneNumber = 111111, Contacts = new List<Contact>() });
                    users.Add(new User() { Email = "Charles@instadeep.com", FullName = "Charles", PhoneNumber = 111111, Contacts = new List<Contact>() });
                    context.Users.AddRange(users);
                    context.SaveChanges();
                }
            }
        }
    }
}
