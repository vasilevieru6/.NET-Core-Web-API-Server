using System.Collections.Generic;

namespace OnlineShop.Models.Domain
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Address> Addresses { get; set; }
        public ShoppingCart Cart { get; set; }
    }
}
