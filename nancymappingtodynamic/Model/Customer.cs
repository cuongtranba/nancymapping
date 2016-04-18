namespace nancymappingtodynamic.Model
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
    }

    public class Address
    {
        public string HomeTown { get; set; }
        public string Telephone { get; set; }
        public People People { get; set; }
    }

    public class People
    {
        public string PeopleName { get; set; }
    }
}
