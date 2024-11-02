using Newtonsoft.Json;

namespace RRS_Cloud_Service.Models
{
    public class Employee : Record
    {
        public required string UserName { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public int Age { get; set; }
    }


}
