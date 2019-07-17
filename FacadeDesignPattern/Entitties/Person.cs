namespace FacadeDesignPattern.Entitties
{
    public class Person
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public Address Address { get; set; }
    }

    public class Address
    {
        public string Phone { get; set; }
        public string Province { get; set; }
    }
}
